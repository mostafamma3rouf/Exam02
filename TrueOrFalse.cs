using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal class TrueOrFalse : Question
    {
        public TrueOrFalse() : base()
        {
        }

        public TrueOrFalse(string header, string body, int mark) : base(header, body, mark)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Question: {Body}");
            Console.WriteLine($"Mark: {Mark}");

            Console.WriteLine("1. True");
            Console.WriteLine("2. False");
        }

        public override Question Clone()
        {
            TrueOrFalse clonedQuestion = new TrueOrFalse(Header, Body, Mark);
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
            return $"True/False: {Body} - Mark: {Mark}";
        }
    }
}
