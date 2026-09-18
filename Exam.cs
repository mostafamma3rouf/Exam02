using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal abstract class Exam
    {
        private TimeSpan _time;
        private int _numberOfQuestions;
        private Subject _subject;
        private ArrayList _questions;

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public int NumberOfQuestions
        {
            get { return _numberOfQuestions; }
            set { _numberOfQuestions = value; }
        }

        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public ArrayList Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        protected Exam()
        {
            _questions = new ArrayList();
        }

        protected Exam(TimeSpan time, int numberOfQuestions) : this()
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
        }

        public void AddQuestion(Question question)
        {
            if (question != null)
            {
                Questions.Add(question);
            }
        }

        public abstract void ShowExam();
    }
}
