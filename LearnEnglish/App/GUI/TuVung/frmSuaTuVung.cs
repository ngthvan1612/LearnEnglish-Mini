using LearnEnglish.App.GUI.Support;
using LearnEnglish.App.Services;
using LearnEnglish.Domain.Entities;
using LearnEnglish.Infrastructure.Audio;
using LearnEnglish.Infrastructure.Audio.Fetching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEnglish.App.GUI.TuVung
{
    public partial class frmSuaTuVung : Form
    {
        private Vocab vocab;
        private VocabRepository vocabService;
        private bool hasAudio;

        public frmSuaTuVung(Vocab vocab, VocabRepository vocabService, bool hasAudio)
        {
            InitializeComponent();

            this.vocab = vocab;
            this.vocabService = vocabService;
            this.hasAudio = hasAudio;

            this.tbEng.Text = this.vocab.Eng;
            this.tbVie.Text = this.vocab.Vie;
        }

        private void btnOpenSelectionFileDialog_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.tbSelectedPath.Text = dlg.FileName;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string Eng = tbEng.Text.Trim();
            string Vie = tbVie.Text.Trim();

            if (Eng.Length == 0)
            {
                MessageBox.Show("Từ tiếng anh không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Eng.Length > 190)
            {
                MessageBox.Show("Từ tiếng anh quá dài (độ dài tối đa: 190)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Vie.Length == 0)
            {
                MessageBox.Show("Từ tiếng việt không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var test = this.vocabService.GetInTopic(this.vocab.TopicId, Eng, Vie);
            if (test != null && test.Id != this.vocab.Id)
            {
                MessageBox.Show("Cặp từ này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] audio = null;

            Action funcAudioProcessing = () =>
            {
                IFetchAudio engine = new RealCloudNet();
                engine.Prepare(Eng);
                if (Eng.ToLower() != this.vocab.Eng.ToLower() || !hasAudio)
                {
                    if (rbTaiFile.Checked)
                    {
                        try
                        {
                            audio = engine.DownloadWAV();
                        }
                        catch
                        {
                            MessageBox.Show("Tải file gặp lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            audio = AudioProcessing.ConvertMp3ToWAV(File.ReadAllBytes(this.tbSelectedPath.Text));
                        }
                        catch
                        {
                            MessageBox.Show("Không đọc được file mp3", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            };

            var loadingDlg = new frmLoading(funcAudioProcessing) { Text = "Đang cập nhật âm thanh"};
            loadingDlg.ShowDialog();

            this.vocabService.UpdateText(this.vocab.Id, Eng, Vie);
            if (Eng.ToLower() != this.vocab.Eng.ToLower() || !hasAudio)
            {
                this.vocabService.UpdateAudio(this.vocab.Id, audio);
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
