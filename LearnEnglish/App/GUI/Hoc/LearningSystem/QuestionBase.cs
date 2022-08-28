using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.GUI.Hoc.LearningSystem
{
    public abstract class QuestionBase : IQuestion
    {
        public abstract QuestionType QuestionType { get; }
        public string Id { get; set; }
        public virtual string Answer { get; }

        public bool CheckAnswer(string userAnswer)
        {
            userAnswer = userAnswer.ToLower().Trim();
            return Answer.ToLower().Trim() == userAnswer;
        }
    }
}
