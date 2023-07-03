using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Threading;
using System.Collections.Specialized;

namespace filereader
{
    public class FileImp : IFile
    {
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

        public List<Questions> LoadDataFromFile(string fileName)
        {
            List<Questions> questions = new List<Questions>();
            try
            {
                var data = File.ReadAllText(fileName).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int pre = 4;
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].StartsWith("A."))
                    {
                        string tmp = "";

                        for (int j = pre; j < i; j++)
                        {
                            tmp += data[j] + '\n';
                        }
                        int post;
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
        
    }
}