﻿using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.DTO.Vocabs
{
    public class VocabRowView
    {
        [DisplayName("STT")]
        public int Order { get; set; }

        [DisplayName("Anh")]
        public string? Eng { get; set; }

        [DisplayName("Việt")]
        public string? Vie { get; set; }

        [Browsable(false)]
        public byte[] Audio { get; set; }

        [DisplayName("Âm thanh")]
        public bool HasAudio { get; set; }

        [Browsable(false)]
        public Vocab? RefVocab { get; set; }

        public VocabRowView() { }

        public VocabRowView(Vocab vocab)
        {
            if (vocab != null)
            {
                this.Eng = vocab.Eng;
                this.Vie = vocab.Vie;
                this.RefVocab = vocab;
                this.Audio = vocab.Audio;
                //
            }
        }
    }
}
