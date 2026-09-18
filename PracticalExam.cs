using System;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal class PracticalExam : Exam
    {
        public PracticalExam() : base()
        {
        }

        public PracticalExam(TimeSpan time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("----- Practical Exam -----");

            Console.WriteLine($"Time: {Time}");
            Console.WriteLine($"Number Of Questions: {NumberOfQuestions}");

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
            }

            Console.Clear();

            Console.WriteLine("Correct Answers");

            foreach (Question question in Questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                if (question.RightAnswer != null)
                {
                    Console.WriteLine($"Correct Answer: " + $"{question.RightAnswer.AnswerId}. " + $"{question.RightAnswer.AnswerText}");
                }
            }
        }
    }
}