using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.exceptions;

namespace BulkPDF
{
    public class PDF
    {
        enum AcroFieldsTypes
        {
            BUTTON = 1,
            CHECK_BOX = 2,
            RADIO_BUTTON = 3,
            TEXT_FIELD = 4,
            LIST_BOX = 5,
            COMBO_BOX = 6
        }
        PdfReader pdfReader;
        List<FieldWriteData> writerFieldList = new List<FieldWriteData>();
        public bool IsXFA
        {
            get { return isXFA; }
        }
        bool isXFA = false;

        struct FieldWriteData
        {
            public string Name;
            public string Value;
            public bool MakeReadOnly;
        }
       
        public void Open(String filePath)
        {
            try
            {
                PdfReader.unethicalreading = true;
                pdfReader = new PdfReader(filePath);
                //pdfReader.RemoveUsageRights();
            }
            catch (InvalidPdfException e)
            {
                throw new Exception(e.ToString());
            }

            // XFA?
            XfaForm xfa = new XfaForm(pdfReader);
            if (xfa != null && xfa.XfaPresent)
            {
                isXFA = true;
            }
            else
            {
                isXFA = false;
            }
        }

        public void Close()
        {
            if (pdfReader != null)
                pdfReader.Close();
        }

        public void SaveFilledPDF(string filePath, bool finalize)
        {
            var copiedPdfReader = new PdfReader(pdfReader);
            var pdfStamperMemoryStream = new MemoryStream();
            PdfStamper pdfStamper = null;
            pdfStamper = new PdfStamper(copiedPdfReader, pdfStamperMemoryStream, '\0', true);

            // Fill
            foreach (var field in writerFieldList)
            {
                if (isXFA)
                {
                    XfaForm xfa = pdfStamper.AcroFields.Xfa;
                    var dataNodes = xfa.DatasetsNode;
                    var node = xfa.FindDatasetsNode(field.Name);
                    var text = node.OwnerDocument.CreateTextNode(field.Value);
                    node.AppendChild(text);                   

                    pdfStamper.AcroFields.Xfa.Changed = true;
                }
                else
                {
                    string value = field.Value;

                    // AcroFields radiobutton start by zero -> dataSourceIndex-1 
                    if (pdfStamper.AcroFields.GetFieldType(field.Name) == (int)AcroFieldsTypes.RADIO_BUTTON)
                    {
                        int radiobuttonIndex = 0;
                        if (int.TryParse(field.Value, out radiobuttonIndex))
                        {
                            radiobuttonIndex--;
                            value = radiobuttonIndex.ToString();
                        }
                    }

                    pdfStamper.AcroFields.SetField(field.Name, value);
                }

                if (field.MakeReadOnly)
                    pdfStamper.AcroFields.SetFieldProperty(field.Name, "setfflags", PdfFormField.FF_READ_ONLY, null);
            }
            

            // Global Finalize
            if (finalize)
                foreach(var field in ListFields())
                    pdfStamper.AcroFields.SetFieldProperty(field.Name, "setfflags", PdfFormField.FF_READ_ONLY, null);


            pdfStamper.Close();
            byte[] content = pdfStamperMemoryStream.ToArray();

            try
            {
                using (var fs = File.Create(filePath))
                {
                    fs.Write(content, 0, (int)content.Length);
                }
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SetFieldValue(string fieldname, string value, bool makeReadOnly = false)
        {
            var field = new FieldWriteData();
            field.Name = fieldname;
            field.Value = value;
            field.MakeReadOnly = makeReadOnly;

            writerFieldList.Add(field);
        }

        public void ResetFieldValue()
        {
            writerFieldList.Clear();
        }

        public List<PDFField> ListFields()
        {
            var fields = new List<PDFField>();
            var acroFields = pdfReader.AcroFields;

            foreach (var field in acroFields.Fields)
                if (acroFields.GetFieldType(field.Key.ToString()) != (int)AcroFieldsTypes.BUTTON)
                {
                    // If readonly, continue loop
                    var n = field.Value.GetMerged(0).GetAsNumber(PdfName.FF);
                    if (n != null && ((n.IntValue & (int)PdfFormField.FF_READ_ONLY) > 0))
                    {
                        continue;
                    }
                    else
                    {
                        var pdfField = new PDFField();
                        pdfField.Name = field.Key.ToString();
                        pdfField.CurrentValue = acroFields.GetField(field.Key.ToString());
                        try
                        {
                            pdfField.Typ = Convert.ToString((AcroFieldsTypes)acroFields.GetFieldType(pdfField.Name));
                        }
                        catch (Exception)
                        {
                            pdfField.Typ = "?";
                        }

                        fields.Add(pdfField);
                    }
                }


            return fields;
        }

        public bool CheckPDFCompatibility()
        {
            return false;
        }
    }
}
