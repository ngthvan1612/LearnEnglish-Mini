using LearnEnglish.App.Services;
using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEnglish.App.GUI.ChuDe
{
    public partial class frmSuaChuDe : Form
    {
        private TopicRepository topicService;
        private Topic topic;

        public frmSuaChuDe(TopicRepository topicService, Topic topic)
        {
            InitializeComponent();
            this.topicService = topicService;
            this.topic = topic;
            this.textBox1.Text = this.topic.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newTopicName = this.textBox1.Text.Trim();
            if (newTopicName.Length == 0)
            {
                MessageBox.Show("Tên chủ đề không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var testTopic = this.topicService.GetTopic(newTopicName);
            if (testTopic != null && testTopic.Id != this.topic.Id)
            {
                MessageBox.Show("Tên chủ đề đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.topic.Name = newTopicName;
            this.topicService.Update(this.topic.Id, this.topic.Name);
            this.DialogResult = DialogResult.OK;
        }
    }
}
