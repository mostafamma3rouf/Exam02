using System;
using System.Collections.Generic;
using System.Text;

namespace Exam02
{
    internal class Subject
    {
        private int _subjectId;
        private string _subjectName;
        private Exam _exam;

        public int SubjectId
        {
            get { return _subjectId; }
            set { _subjectId = value; }
        }

        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Subject name cannot be empty.");
                    return;
                }

                _subjectName = value;
            }
        }

        public Exam Exam
        {
            get { return _exam; }
            set { _exam = value; }
        }

        public Subject()
        {
        }

        public Subject(int subjectId, string subjectName) : this()
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam(Exam exam)
        {
            Exam = exam;
            Exam.Subject = this;
        }
    }
}
