using LearnEnglish.App.GUI.Support;
using LearnEnglish.App.Services;
using LearnEnglish.Infrastructure.Audio;
using LearnEnglish.Infrastructure.Audio.Fetching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnEnglish.App.GUI.TuVung
{
    public partial class frmThemTuVung : Form
    {
        public string Eng { get; set; }
        public string Vie { get; set; }

        private VocabRepository vocabService;
        private int topicId;

        public frmThemTuVung(int topicId, VocabRepository vocabService)
        {
            InitializeComponent();

            this.vocabService = vocabService;
            this.topicId = topicId;

            this.rbChonFile_CheckedChanged(null, null);
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

        private void rbChonFile_CheckedChanged(object sender, EventArgs e)
        {
            this.tbSelectedPath.Enabled = this.rbChonFile.Checked;
            this.btnOpenSelectionFileDialog.Enabled = this.rbChonFile.Checked;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Eng = tbEng.Text.Trim();
            this.Vie = tbVie.Text.Trim();

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

            if (this.vocabService.GetInTopic(this.topicId, Eng, Vie) != null)
            {
                MessageBox.Show("Cặp từ này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] audio = null;

            Action funcAudioProcessing = () =>
            {
                IFetchAudio engine = new RealCloudNet();
                engine.Prepare(Eng);
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
            };

            var loadingDlg = new frmLoading(funcAudioProcessing) { Text = "Đang cập nhật âm thanh" };
            loadingDlg.ShowDialog();

            this.vocabService.Create(this.topicId, Eng, Vie, audio);
            this.DialogResult = DialogResult.OK;
        }
    }
}
