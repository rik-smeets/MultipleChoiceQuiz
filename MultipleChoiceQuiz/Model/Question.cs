using System.Collections.Generic;
using System.Linq;
using MultipleChoiceQuiz.Extensions;
using MultipleChoiceQuiz.OutputWriters;

namespace MultipleChoiceQuiz.Model
{
    public class Question
    {
        private readonly string _question;
        private readonly string _correctAnswer;
        private readonly char _correctAccessor;
        private readonly List<(char accessor, string answer)> _answers = new List<(char accessor, string answer)>();

        public bool IsCorrect { get; private set; }

        public Question(string question, string correctAnswer, IEnumerable<string> incorrectAnswers)
        {
            _question = question;
            _correctAnswer = correctAnswer;

            var allAnswers = new List<string>(incorrectAnswers) { correctAnswer };
            allAnswers.Shuffle();

            var firstAccessor = 'A';
            foreach (var answer in allAnswers)
            {
                _answers.Add((firstAccessor, answer));
                firstAccessor++;
            }

            _correctAccessor = _answers.First(s => s.answer == correctAnswer).accessor;
        }

        public void Ask(IOutputWriter outputWriter)
        {
            outputWriter.WriteQuestion(_question);
            outputWriter.WriteAnswers(_answers);

            var answer = outputWriter.GetAnswer();
            if (char.ToUpperInvariant(answer) == _correctAccessor)
            {
                IsCorrect = true;

                outputWriter.WriteAnswerIsCorrect();
            }
            else
            {
                IsCorrect = false;

                outputWriter.WriteAnswerIsIncorrect(_correctAnswer);
            }
        }
    }
}