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

namespace LearnEnglish.App.GUI.ChuDe
{
    public partial class frmThemChuDe : Form
    {
        public string TopicName { get; set; }
        private TopicRepository topicService;

        public frmThemChuDe(TopicRepository topicService)
        {
            InitializeComponent();
            this.topicService = topicService;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.TopicName = this.tbName.Text.Trim();
            if (this.TopicName.Length == 0)
            {
                MessageBox.Show("Tên chủ đề không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.topicService.GetTopic(this.TopicName) != null)
            {
                MessageBox.Show("Tên chủ đề đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
