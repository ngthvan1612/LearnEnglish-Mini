using LearnEnglish.App.DTO.Topics;
using LearnEnglish.App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEnglish.App.GUI.Hoc
{
    public partial class frmChonTopic : Form
    {
        private TopicRepository topicService;
        private VocabRepository vocabService;
        private BindingList<TopicStudySelectionItem> dataSource;
        
        public List<int> SelectedTopicIds { get; set; }
        public int NumMeaning { get; set; }
        public int NumListening { get; set; }

        public frmChonTopic()
        {
            InitializeComponent();

            this.topicService = new TopicRepository();
            this.dataSource = new BindingList<TopicStudySelectionItem>();
            this.dgvSelectTopic.DataSource = this.dataSource;

            this.vocabService = new VocabRepository();

            this.loadTopics();
        }

        private void loadTopics()
        {
            this.dataSource.Clear();
            var listTopics = this.topicService.GetTopics()
                .Select((u, id) => new TopicStudySelectionItem()
                {
                    Order = id + 1,
                    Name = u.Name,
                    Selected = false,
                    Ref = u
                });
            this.dgvSelectTopic.Columns[nameof(TopicStudySelectionItem.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvSelectTopic.Columns[nameof(TopicStudySelectionItem.Order)].ReadOnly = true;
            this.dgvSelectTopic.Columns[nameof(TopicStudySelectionItem.Name)].ReadOnly = true;
            foreach (var topic in listTopics)
            {
                this.dataSource.Add(topic);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            foreach (var topic in this.dataSource)
            {
                if (topic.Selected)
                {
                    cnt += this.vocabService.ListVocabOfTopicWithoutAudio(topic.Ref.Id).Count();
                }
            }
            if (cnt < 5)
            {
                MessageBox.Show("Cần ít nhất 5 từ vựng để bắt đầu học", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.NumMeaning = (int)this.numMeaning.Value;
            this.NumListening = (int)this.numListening.Value;

            if (this.NumMeaning + this.NumListening <= 0)
            {
                MessageBox.Show("Tổng số lần học nghĩa và nghe phải lớn hơn 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.SelectedTopicIds = this.dataSource.Where(u => u.Selected).Select(u => u.Ref.Id).ToList();
            this.DialogResult = DialogResult.OK;
        }
    }
}
