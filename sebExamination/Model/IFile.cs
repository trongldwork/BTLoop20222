using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filereader
{
    internal interface IFile
    {
        void SaveDataToFile(string fileName, List<Questions> questions);
        List<Questions> LoadDataFromFile(string fileName);
        void MakeQuizz(List<Questions> questions);
        Categories AddCategory(Categories fatherCategory, string name);
        void ConvertDocxToPdf(string txtPath, string pdfPath);
        void ConvertTxtToDocx(string txtPath, string pdfPath);
        void AddImageToDocx(WordprocessingDocument doc, string relationshipId, int lineIndex);
    }
}
