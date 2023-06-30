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
    }
}
