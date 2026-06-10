using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WMPLib; 

namespace WordCards
{
    public partial class frmWordCards : Form
    {
        WordCollection _WordList = new WordCollection();
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        string strWordFile = "WordCards.txt";
        bool isPlay = false;

        public frmWordCards()
        {
            InitializeComponent();
        }

        private void frmWordCards_Load(object sender, EventArgs e)
        {
            if (File.Exists(strWordFile))
            {
                string[] lines = File.ReadAllLines(strWordFile, Encoding.UTF8);
                _WordList.LoadFromStringArray(lines);

                if (_WordList.Count > 0)
                {
                    UpdateWordList();
                    ShowWord(_WordList[0]);
                    tsslMessage.Text = $"單字數量: {_WordList.Count}";
                }
            }
            else
            {
                MessageBox.Show($"找不到單字檔\n{strWordFile}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        // 2. 更新左側清單
        private void UpdateWordList()
        {
            lstWordList.BeginUpdate();
            lstWordList.Items.Clear();
            foreach (WordItem item in _WordList)
            {
                lstWordList.Items.Add(item);
            }
            lstWordList.EndUpdate();
        }

        // 3. 顯示單字到右邊 TextBox
        private void ShowWord(WordItem word)
        {
            txtWord.Text = word.Word;
            txtPhonogram.Text = word.Phonogram;
            txtExplain.Text = word.Explain;
        }

        // 4. 播放音效
        public void PlayWord(WordItem word)
        {
            if (File.Exists(word.SoundPath))
            {
                wmp.URL = word.SoundPath;
                wmp.settings.autoStart = false;
                wmp.settings.mute = false;
                wmp.controls.play();
            }
            else
            {
                tsslMessage.Text = $"找無 {word.SoundPath} 音效檔";
            }
        }

        // 5. 結合顯示與播放
        private void PlaySelectedWord()
        {
            if (lstWordList.SelectedItem != null)
            {
                int idx = lstWordList.SelectedIndex;
                ShowWord(_WordList[idx]);
                PlayWord(_WordList[idx]);
            }
        }

        // 6. 左側清單點擊事件
        private void lstWordList_Click(object sender, EventArgs e)
        {
            if (isPlay) btnAutoPlay.PerformClick(); // 點擊清單就暫停自動播放
            if (lstWordList.SelectedItem != null && lstWordList.SelectedItem.ToString().Length != 0)
            {
                PlaySelectedWord();
            }
        }

        // 7. 跳到下一個單字 (Timer用)
        private void NextWordList()
        {
            lstWordList.Focus();
            if (lstWordList.SelectedIndex + 1 >= lstWordList.Items.Count)
                lstWordList.SelectedIndex = 0;
            else
                lstWordList.SelectedIndex++;

            int lstRows = lstWordList.Height / lstWordList.ItemHeight;
            if (lstWordList.SelectedIndex >= lstRows / 2)
            {
                lstWordList.TopIndex = lstWordList.SelectedIndex - lstRows / 2; // 讓選取的保持在中央
            }
        }

        // 8. Timer 觸發事件
        private void timPlayer_Tick(object sender, EventArgs e)
        {
            NextWordList();
            PlaySelectedWord();
        }

        // 9. Play 按鈕點擊
        private void btnAutoPlay_Click(object sender, EventArgs e)
        {
            lstWordList.Focus();
            if (!isPlay)
            {
                btnAutoPlay.Text = "Stop";
                isPlay = true;
                PlaySelectedWord();
                timPlayer.Start();
            }
            else
            {
                btnAutoPlay.Text = "Play";
                isPlay = false;
                timPlayer.Stop();
            }
        }

        // 10. 鍵盤捷徑 (Enter 下一個 / 空白鍵 重播)
        private void frmWordCards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isPlay) return; // 自動播放時不理會鍵盤

            if (e.KeyChar == (char)Keys.Return)
            {
                NextWordList();
                PlaySelectedWord();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Space)
            {
                if (lstWordList.SelectedIndex >= 0)
                {
                    PlaySelectedWord();
                    e.Handled = true;
                }
            }
        }

        // 11. 雙擊修改單字並存檔
        private void lstWordList_DoubleClick(object sender, EventArgs e)
        {
            lstWordList.Focus();
            int idx = lstWordList.SelectedIndex;
            frmEditWord edit = new frmEditWord(_WordList[idx]);

            if (edit.ShowDialog(this) == DialogResult.Yes)
            {
                PlaySelectedWord();
                _WordList.SaveToFile(strWordFile); // 存檔回 WordCards.txt
            }
        }
    }
}