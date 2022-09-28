using LearnEnglish.App.Extensions;
using LearnEnglish.App.Services;
using LearnEnglish.App.Views.Vocabs;
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

namespace LearnEnglish.App.GUI.TuVung
{
    public partial class frmQuanLyTuVung : Form
    {
        private VocabRepository vocabService;
        private TopicRepository topicService;
        private BindingList<VocabRowView> dtSource_Vocab;

        public frmQuanLyTuVung()
        {
            InitializeComponent();

            this.vocabService = new VocabRepository();
            this.topicService = new TopicRepository();

            this.dtSource_Vocab = new BindingList<VocabRowView>();
            this.dgvVocabs.DataSource = this.dtSource_Vocab;

            this.reloadListTopic();
        }

        private void reloadListTopic()
        {
            this.cbTopics.DataSource = this.topicService.GetTopics();
        }

        private void reloadListVocab(bool resetAtEnd = false)
        {
            if (this.cbTopics.SelectedItem != null)
            {

                int pushSelectedId = -2;
                if (this.dgvVocabs.SelectedRows.Count == 1)
                {
                    pushSelectedId = this.dgvVocabs.SelectedRows[0].Index;
                }
                var topic = this.cbTopics.SelectedItem as Topic;
                this.dtSource_Vocab.Clear();
                this.dtSource_Vocab.AddRange(this.vocabService.ListVocabOfTopicWithoutAudio(topic.Id));

                this.dgvVocabs.Columns[nameof(VocabRowView.Vie)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dgvVocabs.Columns[nameof(VocabRowView.Eng)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (resetAtEnd)
                {
                    pushSelectedId = this.dgvVocabs.Rows.Count - 1;
                }
                if (pushSelectedId > -2 && pushSelectedId <= this.dgvVocabs.Rows.Count - 1)
                {
                    this.dgvVocabs.ClearSelection();
                    this.dgvVocabs.Rows[pushSelectedId].Selected = true;
                    this.dgvVocabs.CurrentCell = this.dgvVocabs.Rows[pushSelectedId].Cells[0];
                }
            }
        }

        private void cbTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reloadListVocab();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.cbTopics.SelectedItem != null)
            {
                var topic = this.cbTopics.SelectedItem as Topic;
                if (new frmThemTuVung(topic.Id, this.vocabService).ShowDialog() == DialogResult.OK)
                {
                    this.reloadListVocab(true);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (dgvVocabs.SelectedRows.Count == 1)
            {
                VocabRowView row = dgvVocabs.SelectedRows[0].DataBoundItem as VocabRowView;
                if (row.HasAudio)
                {
                    byte[] audio = this.vocabService.GetWithAudio(row.RefVocab.Id).Audio;
                    new SoundPlayer(new MemoryStream(audio)).Play();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvVocabs.SelectedRows.Count == 1)
            {
                VocabRowView row = dgvVocabs.SelectedRows[0].DataBoundItem as VocabRowView;
                var frm = new frmSuaTuVung(row.RefVocab, this.vocabService, row.HasAudio);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.reloadListVocab();
                }
            }
        }

        private void menuEditVocab_Click(object sender, EventArgs e)
        {
            this.btnSua_Click(null, null);
        }

        private void menuRemoveAudio_Click(object sender, EventArgs e)
        {
            if (dgvVocabs.SelectedRows.Count == 1)
            {
                VocabRowView row = dgvVocabs.SelectedRows[0].DataBoundItem as VocabRowView;
                this.vocabService.UpdateAudio(row.RefVocab.Id, null);
                this.reloadListVocab();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dgvVocabs.SelectedRows.Count == 1)
            {
                var topic = this.dgvVocabs.SelectedRows[0].DataBoundItem as VocabRowView;

                var answer = MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    this.vocabService.DeleteVocab(topic.RefVocab.Id);
                    this.reloadListVocab();
                }
            }
        }
    }
}
