using LearnEnglish.App.GUI.ChuDe;
using LearnEnglish.App.GUI.Hoc;
using LearnEnglish.App.GUI.Support;
using LearnEnglish.App.GUI.TuVung;
using LearnEnglish.App.Services;

namespace LearnEnglish.App.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void menuDsChuDe_Click(object sender, EventArgs e)
        {
            new frmQuanLyChuDe().ShowDialog();
        }

        private void menuTuVung_Click(object sender, EventArgs e)
        {
            new frmQuanLyTuVung().ShowDialog();
        }

        private void menuLearning_Click(object sender, EventArgs e)
        {
            var frm = new frmChonTopic();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var frmS = new frmHoc(frm.SelectedTopicIds, frm.NumMeaning, frm.NumListening);
                try
                {
                    frmS.ShowDialog();
                }
                catch { }
            }
        }

        private void menuExport_Click(object sender, EventArgs e)
        {
            new frmXuat().ShowDialog();
        }

        private void menuImport_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Eng file (*.eng)|*.eng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TopicRepository topicRepository = new TopicRepository();
                    try
                    {
                        topicRepository.ImportTopics(dlg.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}