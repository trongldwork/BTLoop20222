using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filereader
{
    internal class QuestionsImp : IQuestions
    {
        public void addCategory()
        {
            
        }

        public void sortByCategory(List<Categories> categories, List<Questions> questions)
        {   
            foreach (var category in categories)
            {
                foreach(var question in questions)
                {
                    if (question.Category == category)
                    {
                        category.questions.Add(question);
                    }
                }
            }
        }

    }
}
