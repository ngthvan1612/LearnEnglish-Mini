using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.GUI.Hoc.LearningSystem
{
    public enum QuestionType
    {
        Meaning, Listening
    }

    public interface IQuestion
    {
        QuestionType QuestionType { get; }
    }
}
