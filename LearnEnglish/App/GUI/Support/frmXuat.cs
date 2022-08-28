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

namespace LearnEnglish.App.GUI.Support
{
    public partial class frmXuat : Form
    {
        private TopicRepository topicService;
        private VocabRepository vocabService;
        private BindingList<TopicStudySelectionItem> dataSource;

        public frmXuat()
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
            int cnt = this.dataSource.Where(u => u.Selected).Count();
            if (cnt <= 0)
            {
                MessageBox.Show("Bạn phải chọn ít nhất 1 chủ đề để xuất");
                return;
            }

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Eng file (*.eng)|*.eng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.topicService.ExportTopics(this.dataSource.Where(u => u.Selected).Select(u => u.Ref).ToList(), dlg.FileName);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
