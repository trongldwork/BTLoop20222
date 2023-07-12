using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using Aspose.Words;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace filereader
{
    public class FileImp : IFile
    {
        /// <summary>
        /// lưu các câu hỏi trong list vào địa chỉ fileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="questions"></param>
        public void SaveDataToFile(string fileName, List<Questions> questions)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var question in questions)
            {
                builder.AppendLine(question.Quest);
                for (int i = 0; i < question.Ans.Count; i++)
                {
                    builder.AppendLine(question.Ans[i]);
                }
                builder.AppendLine(question.Answer);
                builder.AppendLine(question.Mark.ToString());
            }
            File.AppendAllText(fileName, builder.ToString());
        }
        /// <summary>
        /// hàm đọc câu hỏi thành một list từ fileName
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// 
        public void ConvertTextToPdf(string textFilePath, string pdfFilePath)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();

            try
            {
                using (StreamReader sr = new StreamReader(textFilePath))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));
                    iTextSharp.text.Font vietnameseFontStyle = FontFactory.GetFont(FontFactory.TIMES, 12, BaseColor.BLACK);



                    document.Open();

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith(":<image>:"))
                        {
                            string imagePath = line.Substring(":<image>:".Length);
                            Image image = Image.GetInstance(imagePath);
                            float newWidth = 400f;
                            float newHeight = 300f;
                            image.ScaleAbsolute(newWidth, newHeight);
                            image.Alignment = Image.ALIGN_LEFT;

                            document.Add(image);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(line))
                            {
                                document.Add(new iTextSharp.text.Paragraph(line, vietnameseFontStyle));
                            }
                        }
                    }

                    document.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public List<Questions> LoadDataFromFile(string fileName)
        {
            List<Questions> questions = new List<Questions>();
            try
            {
                var data = File.ReadAllText(fileName).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int pre = 2;
                int post = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].StartsWith("A."))
                    {
                        string tmp = "";

                        for (int j = pre; j < i; j++)
                        {
                            tmp += data[j] + '\n';
                        }
                        for (post = i; !data[post].StartsWith("ANSWER"); post++) ;
                        List<string> tempList = new List<string>();
                        for (int k = i; k < post; k++)
                        {
                            tempList.Add(data[k]);
                        }
                        pre = post + 2;
                        Questions question = new Questions(tmp, tempList, data[post], double.Parse(data[post + 1]));
                        questions.Add(question);

                    }

                }
                if (post + 1 == data.Length)
                {
                    Console.WriteLine("ERROR at line " + post + 1);
                    return null;
                }
            }
            catch (Exception)
            {

            }
            return questions;
        }
        public void MakeQuizz(List<Questions> questions)
        {
            Random random = new Random();
            FileImp fileImp = new FileImp();
            List<Questions> questionsForQuizz = new List<Questions>();
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = random.Next(0, questions.Count);
                Questions randomElement = questions[randomIndex];
                questionsForQuizz.Add(randomElement);
            }
            fileImp.SaveDataToFile("Quizz.txt", questionsForQuizz);
        }
        public Categories AddCategory(Categories fatherCategory, string Name)
        {
            FileImp fileImp = new FileImp();
            Categories category = new Categories(fatherCategory, Name);
            if (fatherCategory != null)
            {
                string Path1 = fatherCategory.Name;
                string Path2 = Name;
                string fileName = Name;
                string parentFolderPath = System.IO.Path.Combine(Environment.CurrentDirectory, Path1);
                string childFolderPath = System.IO.Path.Combine(parentFolderPath, Path2);
                string filePath = System.IO.Path.Combine(parentFolderPath, fileName + ".txt");
                Directory.CreateDirectory(parentFolderPath);
                Directory.CreateDirectory(childFolderPath);
                List<Questions> questions = new List<Questions>();
                fileImp.SaveDataToFile(filePath, questions);
            }
            else
            {
                Directory.CreateDirectory(Name);
                List<Questions> questions = new List<Questions>();
                fileImp.SaveDataToFile(Name + ".txt", questions);
            }
            return category;
        }


        /// <summary>
        /// hàm chuyển file txt tại địa chỉ txtPath sang file docx tại địa chỉ docxPath
        /// </summary>
        /// <param name="txtPath"></param>
        /// <param name="docxPath"></param>
        public void ConvertTxtToDocx(string txtPath, string docxPath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(docxPath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();

                DocumentFormat.OpenXml.Wordprocessing.Body body = new DocumentFormat.OpenXml.Wordprocessing.Body();

                using (StreamReader sr = new StreamReader(txtPath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                        DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run(new Text(line));
                        run.RunProperties = new RunProperties();
                        run.RunProperties.Append(new RunFonts() { Ascii = "Arial", HighAnsi = "Arial" });
                        run.RunProperties.Append(new FontSize() { Val = "28" });

                        paragraph.Append(run);
                        body.Append(paragraph);
                    }
                }

                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }
        }
        /// <summary>
        /// hàm chuyển file docx tại địa chỉ docxFilePath sang file pdf tại địa chỉ pdfFilePath
        /// </summary>
        /// <param name="docxFilePath"></param>
        /// <param name="pdfFilePath"></param>
        public void ConvertDocxToPdf(string docxFilePath, string pdfFilePath)
        {

        }
        /// <summary>
        /// hàm chèn ảnh từ imageFilePath vào file docx tại docxFilePath tại dòng lineIndex
        /// </summary>
        /// <param name="docxFilePath"></param>
        /// <param name="imageFilePath"></param>
        /// <param name="lineIndex"></param>
        public void AddImageToDocx(string docxFilePath, string imageFilePath, int lineIndex)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(docxFilePath, true))
            {
                MainDocumentPart mainPart = doc.MainDocumentPart;
                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                using (var stream = new System.IO.FileStream(imageFilePath, System.IO.FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }
                AddImageToParagraph(doc, mainPart.GetIdOfPart(imagePart), lineIndex);
            }
        }

        public void splitImage(string textFilePath)
        {
            try
            {
                string content = File.ReadAllText(textFilePath);
                List<int> imagePositions = new List<int>();
                int index = content.IndexOf("<image>");
                while (index != -1)
                {
                    imagePositions.Add(index);
                    index = content.IndexOf("<image>", index + 1);
                }
                StringBuilder formattedContent = new StringBuilder();
                int startIndex = 0;
                foreach (int position in imagePositions)
                {
                    formattedContent.AppendLine(content.Substring(startIndex, position - startIndex));
                    startIndex = position;
                }
                formattedContent.Append(content.Substring(startIndex));
                File.WriteAllText(textFilePath, formattedContent.ToString());
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }


        public string ReplaceImageTags(string textFilePath)
        {
            string newFilePath = "";
            try
            {
                string content = File.ReadAllText(textFilePath);

                string modifiedContent = content.Replace("<image>", ":<image>");

                newFilePath = Path.GetFileNameWithoutExtension(textFilePath) + "new" + Path.GetExtension(textFilePath);
                File.WriteAllText(newFilePath, modifiedContent);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return newFilePath;
        }
        public void AddImageToParagraph(WordprocessingDocument doc, string relationshipId, int lineIndex)
        {
            var paragraphs = doc.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().ToList();
            if (lineIndex >= 0 && lineIndex < paragraphs.Count)
            {
                var paragraph = paragraphs[lineIndex];

                var run = new DocumentFormat.OpenXml.Wordprocessing.Run();

                var element =
                    new Drawing(
                        new DW.Inline(
                            new DW.Extent() { Cx = 990000L, Cy = 792000L },
                            new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                            new DW.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
                            new DW.NonVisualGraphicFrameDrawingProperties(
                                new A.GraphicFrameLocks() { NoChangeAspect = true }),
                            new A.Graphic(
                                new A.GraphicData(
                                    new PIC.Picture(
                                        new PIC.NonVisualPictureProperties(
                                            new PIC.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "New Bitmap Image.jpg" },
                                            new PIC.NonVisualPictureDrawingProperties()),
                                        new PIC.BlipFill(
                                            new A.Blip() { Embed = relationshipId },
                                            new A.Stretch(new A.FillRectangle())),
                                        new PIC.ShapeProperties(
                                            new A.Transform2D(
                                                new A.Offset() { X = 0L, Y = 0L },
                                                new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                            new A.PresetGeometry(
                                                new A.AdjustValueList()
                                            )
                                            { Preset = A.ShapeTypeValues.Rectangle }))
                                )
                                { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                        )
                        { DistanceFromTop = (UInt32Value)0U, DistanceFromBottom = (UInt32Value)0U, DistanceFromLeft = (UInt32Value)0U, DistanceFromRight = (UInt32Value)0U, EditId = "50D07946" });

                run.AppendChild(new RunProperties(new Justification() { Val = JustificationValues.Center }));
                run.AppendChild(element);

                paragraph.InsertBeforeSelf(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new ParagraphProperties(new ParagraphStyleId() { Val = "Heading1" }), run));
            }
            else
            {
                Console.WriteLine("Invalid paragraph index!");
            }
        }
        public List<string> GetImagePaths(string folderPath)
        {
            List<string> imagePaths = new List<string>();

            try
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file);
                    if (IsImageExtension(extension))
                    {
                        imagePaths.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return imagePaths;
        }

        public bool IsImageExtension(string extension)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif" }; // Thêm phần mở rộng khác nếu cần
            return Array.IndexOf(imageExtensions, extension.ToLower()) >= 0;
        }

        public (string, string) SplitStringByImage(string input)
        {
            string beforeImage = string.Empty;
            string afterImage = string.Empty;

            int index = input.IndexOf("<image>:");
            if (index >= 0)
            {
                beforeImage = input.Substring(0, index);
                afterImage = input.Substring(index + "<image>:".Length);
            }
            else
            {
                beforeImage = input;
            }

            return (beforeImage, afterImage);
        }

        public List<string> GetImagePath(string filePath)
        {
            List<string> imagePaths = new List<string>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (line.Contains(":<image>:"))
                    {
                        int startIndex = line.IndexOf(":<image>:") + 9;
                        string imagePath = line.Substring(startIndex);
                        imagePaths.Add(imagePath);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return imagePaths;
        }

        public List<int> GetImageLine(string filePath)
        {
            List<int> imageLine = new List<int>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(":<image>:"))
                    {
                        imageLine.Add(i + 1);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            return imageLine;
        }
        Microsoft.Office.Interop.Word.Application app;

        
    }
}
