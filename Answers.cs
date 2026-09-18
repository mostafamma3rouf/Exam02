using System;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal class Answers
    {
        // Private fields
        private int _answerId;
        private string _answerText;

        // Public properties with validation
        public int AnswerId
        {
            get { return _answerId; }
            set { _answerId = value; }
        }

        public string AnswerText
        {
            get { return _answerText; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Answer text cannot be empty.");
                    return;
                }

                _answerText = value;
            }
        }

        // Constructors chaining to allow for different ways of creating an Answers object
        public Answers()
        {
        }

        public Answers(int answerId, string answerText) : this()
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        // Override ToString method to provide a string representation of the Answers object
        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }
    }
}
