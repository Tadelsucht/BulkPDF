using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using IronPdf;

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
        PdfDocument pdfReader;
        List<FieldWriteData> writerFieldList = new List<FieldWriteData>();
        public bool IsXFA
        {
            get { return isXFA; }
        }
        bool isXFA = false;
        bool isDynamicXFA = false;

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
                pdfReader = PdfDocument.FromFile(filePath);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void Close()
        {
            if (pdfReader != null)
                pdfReader.Dispose();
        }

        public void SaveFilledPDF(string filePath, bool finalize, bool unicode, bool customFont, string customFontPath)
        {
            var copiedPdfReader = pdfReader;
            var pdfStamper = copiedPdfReader.Form;
            
            // Fill
            foreach (var field in writerFieldList)
            {
                // Write
                    string value = field.Value;

                    //// AcroFields radiobutton start by zero -> dataSourceIndex-1 
                    //if (pdfStamper.AcroFields.GetFieldType(field.Name) == (int)AcroFieldsTypes.RADIO_BUTTON)
                    //{
                    //    int radiobuttonIndex = 0;
                    //    if (int.TryParse(field.Value, out radiobuttonIndex))
                    //    {
                    //        radiobuttonIndex--;
                    //        value = radiobuttonIndex.ToString();
                    //    }
                    //}

                    // Different font
                    var fontPath = (customFont) ? customFontPath : Path.Combine(Directory.GetCurrentDirectory(), "unifont.ttf");
                    if(unicode || customFont)
                    {
                        //BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //pdfStamper.AcroFields.AddSubstitutionFont(bf);
                        //pdfStamper.AcroFields.SetFieldProperty(field.Name, "textfont", bf, null);
                        //pdfStamper.AcroFields.RegenerateField(field.Name);
                    }

                    // Write text
                    pdfStamper.GetFieldByName(field.Name).Value = value;

                // Read Only
                if (field.MakeReadOnly)
                {

                    pdfStamper.GetFieldByName(field.Name).ReadOnly = true;
                }
            }

            // Global Finalize
            if (finalize)
            {
                copiedPdfReader.Flatten();
            }

            // Write to file
            pdfReader.SaveAs(filePath);
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
                return ListGenericFields();
        }

        private List<PDFField> ListGenericFields()
        {
            var fields = new List<PDFField>();
            var acroFields = pdfReader.Form;

            foreach (var field in acroFields.Fields)
            {
                // If readonly, continue loop
                if (field.ReadOnly)
                {
                    continue;
                }
                else
                {
                    var pdfField = new PDFField();
                    pdfField.Name = field.Name;
                    try
                    {
                        pdfField.CurrentValue = field.Value;
                    }
                    catch (Exception)
                    {
                        pdfField.CurrentValue = "";
                    }
                    try
                    {
                        pdfField.Typ = Convert.ToString(field.GetType());
                    }
                    catch (Exception)
                    {
                        pdfField.Typ = "";
                    }

                    fields.Add(pdfField);
                }
            }

            return fields;
        }
    }
}
