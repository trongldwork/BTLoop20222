
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace filereader
{
    public class Categories
    {
        public Categories() { }

        List<Categories> categories = new List<Categories>();
        public string Name { get; set; }
        public string CategoryInfo { get; set; }
        public List<Questions> questions { get; set; }
        public Categories(string Name, string CategoryInfo)
        {
            this.Name = Name;
            this.CategoryInfo = CategoryInfo;
        }
        public Categories(string Name, string CategoryInfo, List<Questions> questions)
        {
            this.Name = Name;
            this.CategoryInfo = CategoryInfo;
            this.questions = questions;
        }
    }
    public class Questions
    {
        public Questions() { }

        List<Questions> questions = new List<Questions>();
        public Categories Category { get; set; }
        public string Quest { get; set; }
        public List<string> Ans { get; set; }
        public string Answer { get; set; }
        public double Mark { get; set; }
        public string PngPath { get; set; }
        public string GifPath { get; set; }
        public Questions(string Quest, List<string> Ans, string Answer, double Mark)
        {
            this.Quest = Quest;
            this.Ans = Ans;
            this.Answer = Answer;
            this.Mark = Mark;
        }
        public override string ToString()
        {
            String message = Quest;
            for (int i = 0; i < Ans.Count; i++)
            {
                message += Ans[i] + "\n";
            }
            message += Answer + "\n" + Mark + "\n";
            return message.ToString();
        }
    }
}