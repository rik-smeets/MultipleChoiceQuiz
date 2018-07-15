using System.Collections.Generic;
using MultipleChoiceQuiz.Extensions;
using MultipleChoiceQuiz.Model;
using MultipleChoiceQuiz.OutputWriters;

namespace MultipleChoiceQuiz
{
    public class Program
    {
        private static readonly IOutputWriter outputWriter = new ConsoleOutputWriter();

        private static void Main()
        {
            outputWriter.WriteIntro();

            var questions = CreateShuffledQuestions();
            foreach (var question in questions)
            {
                question.Ask(outputWriter);
            }

            outputWriter.WriteResults(questions);
        }

        private static IEnumerable<Question> CreateShuffledQuestions()
        {
            var questions = new List<Question>
            {
                new Question(
                    "What is 9 + 9 * 9 - 1 ?",
                    correctAnswer: "89",
                    incorrectAnswers: new[]
                    {
                        "161",
                        "3",
                        "81"
                    }),
                new Question(
                    "Which one of these characters does Harry Potter know?",
                    correctAnswer: "Hermione Granger",
                    incorrectAnswers: new[]
                    {
                        "Ellen Ripley",
                        "Lyra Belacqua",
                        "Alyx Vance"
                    }),
                new Question(
                    "What was the tagline of the 1979 horror movie Alien?",
                    correctAnswer: "In space no one can hear you scream.",
                    incorrectAnswers: new[]
                    {
                        "Be afraid. Be very afraid.",
                        "They're here.",
                        "Humans are such easy prey."
                    }),
                new Question(
                    "What is the best-selling video game of all time?",
                    correctAnswer: "Tetris",
                    incorrectAnswers: new[]
                    {
                        "Minecraft",
                        "Grand Theft Auto V",
                        "Wii Sports",
                        "Super Mario Bros."
                    })
            };

            questions.Shuffle();

            return questions;
        }
    }
}