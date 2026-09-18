using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal abstract class Question : ICloneable, IComparable<Question> // Abstract class with ICloneable and IComparable<Question> interfaces
    {
        // Private fields
        private string _header;
        private string _body;
        private int _mark;
        private ArrayList _answerList;
        private Answers _rightAnswer;

        // Public properties with validation
        public string Header
        {
            get { return _header; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Header cannot be empty.");
                    return;
                }

                _header = value;
            }
        }

        public string Body
        {
            get { return _body; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Body cannot be empty.");
                    return;
                }

                _body = value;
            }
        }

        public int Mark
        {
            get { return _mark; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Mark cannot be negative.");
                    return;
                }

                _mark = value;
            }
        }

        public ArrayList AnswerList
        {
            get { return _answerList; }
            set { _answerList = value; }
        }

        public Answers RightAnswer
        {
            get { return _rightAnswer; }
            set { _rightAnswer = value; }
        }

        // Constructors chaining to allow for different ways of creating a Question object
        protected Question()
        {
            _answerList = new ArrayList();
        }

        protected Question(string header, string body, int mark) : this()
        {
            Header = header;
            Body = body;
            Mark = mark;
        }

        public abstract void Display(); // Abstract method to be implemented by derived class

        public abstract object Clone();

        public int CompareTo(Question other)
        {
            if (other == null)
            {
                return 1;
            }

            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"{Header} - {Body} - Mark: {Mark}";
        }
    }
}
