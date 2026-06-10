using System;
using System.Windows.Forms;
using WordCards;

namespace WordCards
{
    public partial class frmEditWord : Form
    {
        public WordItem Word { get; set; } = null;

        // 接收傳過來的單字資料
        public frmEditWord(WordItem word)
        {
            InitializeComponent();
            this.Word = word;
            txtWord.Text = word.Word;
            txtPhonogram.Text = word.Phonogram;
            txtSoundPath.Text = word.SoundPath;
            txtExplain.Text = word.Explain;
        }

        // 儲存按鈕
        private void btnSave_Click(object sender, EventArgs e)
        {
            Word.Word = txtWord.Text;
            Word.Phonogram = txtPhonogram.Text;
            Word.SoundPath = txtSoundPath.Text;
            Word.Explain = txtExplain.Text;

            this.DialogResult = DialogResult.Yes; // 告訴主視窗有存檔
            this.Close();
        }
    }
}