namespace Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Subject
            Console.WriteLine("----- Subject -----");
            Console.Write("Enter Subject ID: ");
            int subjectId = int.Parse(Console.ReadLine());

            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();

            Subject subject = new Subject(subjectId, subjectName);

            Console.Clear();

            // Create Exam
            Console.Write("----- Exam -----");

            Console.WriteLine("\nChoose Exam Type: 1 for Final Exam, 2 for Practical Exam");

            Console.Write("Enter Choice: ");
            int examType = int.Parse(Console.ReadLine());

            Console.Write("Enter Exam Duration in Minutes: ");
            int minutes = int.Parse(Console.ReadLine());
            TimeSpan examTime = TimeSpan.FromMinutes(minutes);

            Console.Write("Enter Number Of Questions: ");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            Exam exam;

            if (examType == 1)
            {
                exam = new FinalExam(examTime, numberOfQuestions);
            }
            else if (examType == 2)
            {
                exam = new PracticalExam(examTime, numberOfQuestions);
            }
            else
            {
                Console.WriteLine("Invalid Exam Type.");
                return;
            }

            Console.Clear();

            // Add Questions
            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"----- Question {i + 1} -----");

                Question question;

                // Final Exam
                if (examType == 1)
                {
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1. MCQ");
                    Console.WriteLine("2. True / False");

                    Console.Write("Enter Choice: ");
                    int questionType = int.Parse(Console.ReadLine());

                    if (questionType == 1)
                    {
                        question = CreateMCQQuestion();
                    }
                    else if (questionType == 2)
                    {
                        question = CreateTrueFalseQuestion();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Question Type.");
                        i--;
                        continue;
                    }
                }
                // Practical Exam
                else
                {
                    Console.WriteLine("Practical Exam uses MCQ questions.");
                    question = CreateMCQQuestion();
                }

                exam.AddQuestion(question);
            }

            Console.Clear();

            // Connect Exam With Subject

            subject.CreateExam(exam);
            // Show Exam
            Console.WriteLine("----- EXAM INFORMATION -----");

            Console.WriteLine($"Subject ID: {subject.SubjectId}");
            Console.WriteLine($"Subject Name: {subject.SubjectName} \n");

            subject.Exam.ShowExam();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

            Console.Clear();
        }



        // Create MCQ Question
        static Question CreateMCQQuestion()
        {
            Console.Write("Enter Header: ");
            string header = Console.ReadLine();

            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Mark: ");
            int mark = int.Parse(Console.ReadLine());

            MCQ question = new MCQ(header, body, mark);

            Console.Write("Enter Number Of Answers: ");
            int numberOfAnswers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAnswers; i++)
            {
                Console.Write($"Enter Answer {i + 1}: ");
                string answerText = Console.ReadLine();
                Answers answer = new Answers(i + 1, answerText);
                question.AnswerList.Add(answer);
            }

            Console.Write("Enter Correct Answer ID: ");
            int rightAnswerId = int.Parse(Console.ReadLine());

            foreach (Answers answer in question.AnswerList)
            {
                if (answer.AnswerId == rightAnswerId)
                {
                    question.RightAnswer = answer;
                    break;
                }
            }

            return question;
        }

        // Create True / False Question
        static Question CreateTrueFalseQuestion()
        {
            Console.Write("Enter Header: ");
            string header = Console.ReadLine();

            Console.Write("Enter Question Body: ");
            string body = Console.ReadLine();

            Console.Write("Enter Mark: ");
            int mark = int.Parse(Console.ReadLine());

            TrueOrFalse question = new TrueOrFalse(header, body, mark);
            Answers trueAnswer = new Answers(1, "True");
            Answers falseAnswer = new Answers(2, "False");
            question.AnswerList.Add(trueAnswer);
            question.AnswerList.Add(falseAnswer);
            Console.WriteLine("1. True");
            Console.WriteLine("2. False");

            Console.Write("Enter Correct Answer ID: ");
            int rightAnswerId = int.Parse(Console.ReadLine());

            if (rightAnswerId == 1)
            {
                question.RightAnswer = trueAnswer;
            }
            else if (rightAnswerId == 2)
            {
                question.RightAnswer = falseAnswer;
            }
            else
            {
                Console.WriteLine("Invalid Answer ID.");
            }

            return question;
        }
    }
}