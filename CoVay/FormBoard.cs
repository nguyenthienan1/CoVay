using System;
using System.Drawing;
using System.Windows.Forms;

namespace CoVay
{
    public partial class FormBoard : Form
    {
        public Board board;

        int TimeOut;

        System.Timers.Timer timer;

        public FormBoard()
        {
            InitializeComponent();
            board = new Board();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += timer_Tick;
            timer.AutoReset = true;
            timer.Stop();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            board.DrawBoard(g);
            board.DrawStones(g);
        }

        /// <summary>
        /// Sự kiện khi nhấn chuột trên bảng pictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //Nếu click chuột trái
                if (e.Button == MouseButtons.Left)
                {
                    int boardsize = ConstNumber.linenum;

                    double dbX = e.X * 1.0 / ConstNumber.cellSize - 0.5;

                    // Nếu không click chuẩn vào các điểm giao nhau thì hàm này sẽ cho tọa độ của điểm giao nhau gần nhất
                    int intX = GetUpperNum(dbX);

                    double dbY = e.Y * 1.0 / ConstNumber.cellSize - 0.5;
                    // Nếu không click chuẩn vào các điểm giao nhau thì hàm này sẽ cho tọa độ của điểm giao nhau gần nhất
                    int intY = GetUpperNum(dbY);

                    //Nếu click không ở trên bàn cờ sẽ return
                    if (intX > boardsize || intY > boardsize) return;
                    if (intX == 0 || intY == 0) return;

                    //Gửi tọa độ  đến cho Server
                    StarterForm.client.SendXYStone(intX, intY);
                }
            }
            catch
            {
            }
        }

        private int GetUpperNum(double a)
        {
            int b = (int)a;
            if (b < a)
            {
                b += 1;
            }
            return b;
        }

        /// <summary>
        /// Sự kiện nút Chat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSendMess_Click(object sender, EventArgs e)
        {
            StarterForm.client.SendChat(textBox_Chat.Text);
            textBox_Chat.Text = "";
        }

        /// <summary>
        /// Sự kiện nút sẵn sàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReady_Click(object sender, EventArgs e)
        {
            StarterForm.client.SendReadyFight();
        }

        /// <summary>
        /// Sự kiện nút bỏ lượt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBoLuot_Click(object sender, EventArgs e)
        {
            StarterForm.client.SendBoLuot();
        }

        public void SetTimeOut(bool inturn, bool dostop)
        {
            SetTime();
            if (dostop)
            {
                LabelTime.BeginInvoke(new Action(() =>
                {
                    LabelTime.Text = " ";
                }));
                labelInTurn.BeginInvoke(new Action(() =>
                {
                    labelInTurn.Text = "Chờ bắt đầu trận";
                    labelInTurn.ForeColor = Color.Black;
                }));
                timer.Stop();
                return;
            }
            timer.Stop();
            TimeOut = 60;
            timer.Start();
            labelInTurn.BeginInvoke(new Action(() =>
            {
                if (inturn)
                {
                    labelInTurn.Text = "Đến lượt bạn";
                    labelInTurn.ForeColor = Color.Green;
                }
                else
                {
                    labelInTurn.Text = "Chờ đối thủ đánh";
                    labelInTurn.ForeColor = Color.Red;
                }
            }));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeOut--;
            SetTime();
        }

        private void SetTime()
        {
            LabelTime.BeginInvoke(new Action(() =>
            {
                LabelTime.Text = TimeOut.ToString();
                if (TimeOut >= 30)
                {
                    LabelTime.ForeColor = Color.Green;
                }
                else if (TimeOut == 29)
                {
                    LabelTime.ForeColor = Color.Yellow;
                }
                else if (TimeOut == 9)
                {
                    LabelTime.ForeColor = Color.Red;
                }
            }));
        }

        /// <summary>
        /// Sự kiện bấm nút X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn rời phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                StarterForm.client.SendCloseRoom();
                timer.Dispose();
                Dispose();
                Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void textBox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StarterForm.client.SendChat(textBox_Chat.Text);
                textBox_Chat.Text = "";
                e.SuppressKeyPress = true;
            }
        }
    }
}
