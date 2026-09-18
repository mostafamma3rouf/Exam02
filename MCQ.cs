using System;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal class MCQ : Question
    {
        public MCQ() : base()
        {
        }

        public MCQ(string header, string body, int mark) : base(header, body, mark)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Question: {Body}");
            Console.WriteLine($"Mark: {Mark}");

            Console.WriteLine("Answers:");

            foreach (Answers answer in AnswerList)
            {
                Console.WriteLine(answer);
            }
        }

        public override Question Clone()
        {
            MCQ clonedQuestion = new MCQ(Header, Body, Mark);

            foreach (Answers answer in AnswerList)
            {
                Answers clonedAnswer = new Answers(answer.AnswerId, answer.AnswerText);

                clonedQuestion.AnswerList.Add(clonedAnswer);
            }

            if (RightAnswer != null)
            {
                clonedQuestion.RightAnswer = new Answers(RightAnswer.AnswerId, RightAnswer.AnswerText);
            }

            return clonedQuestion;
        }

        public override string ToString()
        {
            return $"MCQ: {Body} - Mark: {Mark}";
        }
    }
}
