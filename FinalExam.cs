using System;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal class FinalExam : Exam
    {
        public FinalExam() : base()
        {
        }

        public FinalExam(TimeSpan time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("----- Final Exam -----");
            Console.WriteLine($"Time: {Time}");
            Console.WriteLine($"Number Of Questions: {NumberOfQuestions}");

            int grade = 0;
            foreach (Question question in Questions)
            {
                Console.WriteLine("\n--------------------------");
                question.Display();
                Console.Write("Enter your answer ID: ");

                int userAnswerId;
                while (!int.TryParse(Console.ReadLine(), out userAnswerId))
                {
                    Console.Write("Invalid input. Enter answer ID: ");
                }

                if (question.RightAnswer != null && userAnswerId == question.RightAnswer.AnswerId)
                {
                    grade += question.Mark;
                }
            }

            Console.WriteLine($"Your Grade: {grade}");
        }
    }
}

