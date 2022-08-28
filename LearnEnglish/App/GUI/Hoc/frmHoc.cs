using LearnEnglish.App.GUI.Hoc.LearningSystem;
using LearnEnglish.App.Services;
using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEnglish.App.GUI.Hoc
{
    public partial class frmHoc : Form
    {

        private int totalQuestion = 0;
        public int TotalQuestion
        {
            get => this.totalQuestion;
            set
            {
                this.totalQuestion = value;
                this.redrawLabelStatus();
            }
        }

        private int currentQuestion = 0;
        public int CurrentQuestion
        {
            get => this.currentQuestion;
            set
            {
                this.currentQuestion = value;
                this.redrawLabelStatus();
            }
        }

        public string QuestionContent
        {
            get => this.lbQuestionContent.Text;
            set => this.lbQuestionContent.Text = value;
        }

        public string Answer
        {
            get => this.tbAnswer.Text;
            set => this.tbAnswer.Text = value;
        }

        private void redrawLabelStatus()
        {
            this.lbStatus.Text = $"Câu hỏi {this.CurrentQuestion}/{this.TotalQuestion}";
        }

        private List<QuestionBase> QuestionsQueue;
        private VocabRepository vocabService;

        private int numMean, numLis;

        public frmHoc(List<int> listTopicIds, int numMean, int numLis)
        {
            InitializeComponent();

            this.numMean = numMean;
            this.numLis = numLis;

            vocabService = new VocabRepository();
            this.QuestionsQueue = new List<QuestionBase>();

            this.redrawLabelStatus();
            this.buildQuestionsQueue(listTopicIds);

            this.Answer = "";
        }

        private void resetCurrentQuestion()
        {
            if (this.CurrentQuestion <= this.TotalQuestion)
            {
                if (this.QuestionsQueue[this.CurrentQuestion - 1] is ListeningQuestion)
                {
                    var qLis = this.QuestionsQueue[this.CurrentQuestion - 1] as ListeningQuestion;
                    try
                    {
                        new SoundPlayer(new MemoryStream(qLis.Audio)).Play();
                    }
                    catch { }
                }
            }
        }
        
        private void prepareNextQuestion()
        {
            if (this.CurrentQuestion == this.TotalQuestion)
            {
                MessageBox.Show("Học xong!");
                this.Close();
                return;
            }
            this.tbAnswer.Text = "";
            this.CurrentQuestion++;
            var q = this.QuestionsQueue[this.CurrentQuestion - 1];
            if (q is MeaningQuestion)
            {
                var qMean = q as MeaningQuestion;
                //this.QuestionContent = qMean.Vie;
                this.lbQuestionContent.Text = qMean.Vie;
            }
            else
            {
                //var qLis = q as ListeningQuestion;
                //this.QuestionContent = "Listen...";
                this.lbQuestionContent.Text = "Listen...";
            }
            this.resetCurrentQuestion();
            //MessageBox.Show(this.QuestionContent);
        }

        private void buildQuestionsQueue(List<int> listTopicIds)
        {
            this.QuestionsQueue.Clear();
            List<Vocab> vocabs = new List<Vocab>();
            foreach (var topic in listTopicIds)
            {
                vocabs.AddRange(this.vocabService.ListVocabOfTopicWithAudio(topic).Select(u => u.RefVocab));
            }
            foreach (var vocab in vocabs)
            {
                string uuid = Guid.NewGuid().ToString();
                for (int i = 0; i < this.numMean; ++i)
                {
                    this.QuestionsQueue.Add(new MeaningQuestion(vocab) { Id = uuid });
                }

                if (vocab.Audio != null)
                {
                    for (int i = 0; i < this.numLis; ++i)
                    {
                        this.QuestionsQueue.Add(new ListeningQuestion(vocab) { Id = uuid });
                    }
                }
            }
            Random randomEngine = new Random(Guid.NewGuid().GetHashCode());
            for (int gido = 0; gido < 64; ++gido)
            {
                for (int i = 1; i < this.QuestionsQueue.Count; ++i)
                {
                    int j = randomEngine.Next(0, i - 1);
                    var temp = this.QuestionsQueue[i];
                    this.QuestionsQueue[i] = this.QuestionsQueue[j];
                    this.QuestionsQueue[j] = temp;
                }
            }
            while (true)
            {
                bool ok = true;
                for (int i = 0; i + 1 < this.QuestionsQueue.Count; ++i)
                {
                    ok &= (this.QuestionsQueue[i].Id != this.QuestionsQueue[i + 1].Id);
                }
                if (ok) break;
                for (int i = 1; i < this.QuestionsQueue.Count; ++i)
                {
                    int j = randomEngine.Next(0, i - 1);
                    var temp = this.QuestionsQueue[i];
                    this.QuestionsQueue[i] = this.QuestionsQueue[j];
                    this.QuestionsQueue[j] = temp;
                }
            }
            this.TotalQuestion = this.QuestionsQueue.Count;
            this.CurrentQuestion = 0;
            this.prepareNextQuestion();
        }

        private void tbAnswer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void tbAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                string userAnswer = this.tbAnswer.Text;
                if (!this.QuestionsQueue[this.CurrentQuestion - 1].CheckAnswer(userAnswer))
                {
                    this.tbAnswer.Text = "";
                    MessageBox.Show("Sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.resetCurrentQuestion();
                }
                else
                {
                    if (this.QuestionsQueue[this.CurrentQuestion - 1] is MeaningQuestion)
                    {
                        var qMean = this.QuestionsQueue[this.CurrentQuestion - 1] as MeaningQuestion;
                        if (qMean.Audio != null)
                        {
                            new SoundPlayer(new MemoryStream(qMean.Audio)).PlaySync();
                        }
                    }
                    else
                    {
                        var qLis = this.QuestionsQueue[this.currentQuestion - 1] as ListeningQuestion;
                        var temp = this.lbQuestionContent.ForeColor;
                        this.lbQuestionContent.ForeColor = Color.Red;
                        this.lbQuestionContent.Text = qLis.Ref.Vie;
                        Application.DoEvents();
                        new SoundPlayer(new MemoryStream(qLis.Audio)).PlaySync();
                        this.lbQuestionContent.ForeColor = temp;
                    }
                    prepareNextQuestion();
                }
                e.Handled = true;
            }
        }
    }
}
