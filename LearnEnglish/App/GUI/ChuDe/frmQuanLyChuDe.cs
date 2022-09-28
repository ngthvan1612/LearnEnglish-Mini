using LearnEnglish.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LearnEnglish.App.Services;
using LearnEnglish.App.Views.Topics;

namespace LearnEnglish.App.GUI.ChuDe
{
    public partial class frmQuanLyChuDe : Form
    {
        private readonly TopicRepository topicService;
        private readonly BindingList<TopicRowView> dataSource;

        public frmQuanLyChuDe()
        {
            InitializeComponent();
            this.topicService = new TopicRepository();
            this.dataSource = new BindingList<TopicRowView>();
            this.dgvChuDe.DataSource = this.dataSource;
            this.reloadListTopic();
        }

        private void reloadListTopic()
        {
            this.dataSource.Clear();
            this.dataSource.AddRange(this.topicService.GetTopicDataGridView());
            this.dgvChuDe.Columns[nameof(TopicRowView.Name)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var frm = new frmThemChuDe(this.topicService);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.topicService.Create(frm.TopicName);
                this.reloadListTopic();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.dgvChuDe.SelectedRows.Count == 1)
            {
                var refData = this.dgvChuDe.SelectedRows[0].DataBoundItem as TopicRowView;
                var frm = new frmSuaChuDe(this.topicService, refData.RefTopic);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.reloadListTopic();
                }
            }
        }

        private void dgvChuDe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dgvChuDe.SelectedRows.Count == 1)
            {
                var topic = this.dgvChuDe.SelectedRows[0].DataBoundItem as TopicRowView;

                var answer = MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    this.topicService.DeleteTopic(topic.RefTopic.Id);
                    this.reloadListTopic();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
