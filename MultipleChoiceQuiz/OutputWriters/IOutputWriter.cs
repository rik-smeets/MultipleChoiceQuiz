using System.Collections.Generic;
using MultipleChoiceQuiz.Model;

namespace MultipleChoiceQuiz.OutputWriters
{
    public interface IOutputWriter
    {
        void WriteIntro();

        void WriteQuestion(string question);

        void WriteAnswers(IEnumerable<(char accessor, string answer)> answers);

        char GetAnswer();

        void WriteAnswerIsCorrect();

        void WriteAnswerIsIncorrect(string correctAnswer);

        void WriteResults(IEnumerable<Question> questions);
    }
}