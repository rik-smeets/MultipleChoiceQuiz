using System;
using System.Collections.Generic;
using System.Linq;
using MultipleChoiceQuiz.Model;

namespace MultipleChoiceQuiz.OutputWriters
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        private const string BreakLine = "--------------------------------";

        public void WriteIntro()
        {
            Console.WriteLine(BreakLine);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to this quiz!");
            Console.WriteLine("Are you ready?");
            Console.ResetColor();
            Console.WriteLine(BreakLine);

            PressAnyKeyToContinue();
        }

        public void WriteQuestion(string question)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(question);
            Console.ResetColor();
        }

        public void WriteAnswers(IEnumerable<(char accessor, string answer)> answers)
        {
            foreach (var answer in answers)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{answer.accessor}: ");
                Console.ResetColor();
                Console.WriteLine(answer.answer);
            }

            Console.ResetColor();
        }

        public char GetAnswer()
        {
            Console.WriteLine(BreakLine);
            Console.WriteLine("Enter only the accessor, i.e. 'A', 'B', 'C' etc.:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var answer = Console.ReadKey().KeyChar;
            Console.ResetColor();

            return answer;
        }

        public void WriteAnswerIsCorrect()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ResetColor();

            PressAnyKeyToContinue();
        }

        public void WriteAnswerIsIncorrect(string correctAnswer)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect answer!");
            Console.ResetColor();
            Console.WriteLine("The correct answer was:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(correctAnswer);
            Console.ResetColor();

            PressAnyKeyToContinue();
        }

        public void WriteResults(IEnumerable<Question> questions)
        {
            Console.Clear();
            Console.WriteLine(BreakLine);
            Console.WriteLine("End of the quiz!");

            var totalQuestions = questions.Count();
            var amountOfRightAnswers = questions.Count(x => x.IsCorrect);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You answered {amountOfRightAnswers} / {totalQuestions} questions correctly!");
            Console.ResetColor();
            Console.WriteLine(BreakLine);

            PressAnyKeyToContinue();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Thanks for playing!");
            Console.ResetColor();
            Console.WriteLine(BreakLine);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Console.WriteLine();
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}