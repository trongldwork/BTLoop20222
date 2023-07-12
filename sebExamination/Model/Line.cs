using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sebExamination.Model
{
    public class Line
    {
        // khai bao cac thuoc tinh va phuong thuc khoi tao
        public int LineNumber { get; set; }
        public string LineContent { get; set; }
        public string Type { get; set; }
        public Line(string text, int location)
        {
            LineNumber = location;
            LineContent = text;
            Type = Check_type(text);
        }
        // ham kiem tra dinh dang choice
        public static bool CheckChoice(string inputString)
        {
            // chieu dai phai lon hon 3
            if (inputString.Length < 3)
                return false;
            // ki tu dau viet hoa
            if (!char.IsUpper(inputString[0]))
                return false;
            // tiep theo la dau .
            if (inputString[1] != '.')
                return false;
            // tiep theo la khoang trang ' '
            if (inputString[2] != ' ')
                return false;
            // sau khoang trang phai co it nhat mot ki tu khac ' '
            for (int i = 3; i < inputString.Length; i++)
            {
                if (inputString[i] != ' ')
                    return true;
            }

            return false;
        }
        // hàm kiểm tra định dạng 'answer', cần có list các đáp án thu được từ các choice trc đó
        public static bool CheckAnswer(string inputString)
        {
            string answerPrefix = "ANSWER: ";
            // check bắt đầu bằng "ANSWER: "
            if (!inputString.StartsWith(answerPrefix))
                return false;
            //láy vị trí của ':' để đọc kí tự đáp án
            int colonIndex = inputString.IndexOf(":");
            if (colonIndex == -1)
                return false;
            if (inputString.Length < 9) return false;
            // không viết hoa đáp án là sai định dạng
            string answer = inputString.Substring(colonIndex + 2);
            if (!char.IsUpper(answer[0]))
                return false;
            return true;
        }
        // kiem tra dinh dang text
        public string Check_type(string text)
        {
            // check xem phải các lựa chọn không ('choice')
            if (CheckChoice(text))
            {
                return "choice";
            }
            // check xem phải đáp án không ('answer')
            if (CheckAnswer(text))
            {
                return "answer";

            }
            // check xem phai dong ki tu trang khong
            if (string.IsNullOrWhiteSpace(text))
            {
                return "none";
            }
            // không có định dạng cho câu hỏi nên mặc định type sẽ là 'question'
            return "question";

        }
    }
}
