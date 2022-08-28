using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.GUI.Hoc.LearningSystem
{
    public class ListeningQuestion : QuestionBase
    {
        public override QuestionType QuestionType => QuestionType.Listening;

        public string Eng { get; set; }
        public byte[] Audio { get; set; }
        public override string Answer => this.Eng;

        public Vocab Ref;

        public ListeningQuestion(Vocab vocab)
        {
            this.Ref = vocab;
            if (vocab.Audio is null)
                throw new ArgumentNullException();
            this.Eng = vocab.Eng;
            this.Audio = vocab.Audio;
        }
    }
}
