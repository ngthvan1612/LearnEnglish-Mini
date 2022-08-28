using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.GUI.Hoc.LearningSystem
{
    public class MeaningQuestion : QuestionBase
    {
        public override QuestionType QuestionType => QuestionType.Meaning;

        public string Eng { get; set; }
        public string Vie { get; set; }

        public override string Answer => this.Eng;
        public byte[] Audio;

        public MeaningQuestion(Vocab vocab)
        {
            this.Eng = vocab.Eng;
            this.Vie = vocab.Vie;
            if (vocab.Audio != null)
            {
                this.Audio = vocab.Audio;
            }
        }
    }
}
