using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using BitMiracle.Docotic.Pdf;

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
        string pdfReaderFilePath;
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
                pdfReaderFilePath = filePath;
                pdfReader = new PdfDocument(filePath);
                //pdfReader.RemoveUsageRights();
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
            //var copiedPdfReader = new PdfDocument(filePath);

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
                PdfFont font = null;
                if (unicode || customFont)
                {
                    //BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //pdfStamper.AcroFields.AddSubstitutionFont(bf);
                    //pdfStamper.AcroFields.SetFieldProperty(field.Name, "textfont", bf, null);
                    //pdfStamper.AcroFields.RegenerateField(field.Name);
                    font = pdfReader.AddFontFromFile(fontPath);
                }

                // Write text
                PdfControl formField = pdfReader.GetControl(field.Name);
                    if (formField?.Type == PdfWidgetType.TextBox)
                {
                    if (font != null) ((PdfTextBox)formField).Font = font;
                    ((PdfTextBox)formField).Text = value;
                }

                // Read Only
                if (field.MakeReadOnly)
                {
                    formField.Flatten();
                }
            }

            // Global Finalize
            if (finalize)
            {
                pdfReader.FlattenControls();
            }

            try
            {
                pdfReader.Save(filePath);
            }
            catch (Exception e)
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
                return ListGenericFields();
        }

        private List<PDFField> ListGenericFields()
        {
            var fields = new List<PDFField>();
            var acroFields = pdfReader.GetControls();

            var counter = 0;
            foreach (PdfControl field in acroFields)
                if (field.Type != PdfWidgetType.Button && field.Type != PdfWidgetType.RadioButton)
                {
                    // If readonly, continue loop
                    //var n = field.Value.GetMerged(0).GetAsNumber(PdfName.FF);
                    //if (n != null && ((n.IntValue & (int)PdfFormField.FF_READ_ONLY) > 0))
                    //{
                    //    continue;
                    //}
                    //else
                    //{
                        var pdfField = new PDFField();
                        pdfField.Name = field.FullName;
                    try
                    {
                        pdfField.CurrentValue = ((PdfTextBox)field).Text;
                        }
                    catch (Exception)
                    {
                        pdfField.Typ = "";
                    }
                    try
                        {
                            pdfField.Typ = Convert.ToString(field.Type);
                        }
                        catch (Exception)
                        {
                            pdfField.Typ = "";
                        }

                        fields.Add(pdfField);
                    //}
                }

            return fields;
        }
    }
}
