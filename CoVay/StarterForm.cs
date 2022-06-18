using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoVay
{
    public partial class StarterForm : Form
    {
        public static Client client;
        public static RoomForm RF;
        public static string IP = "127.0.0.1";
        public static int PORT = 8888;

        public StarterForm()
        {
            InitializeComponent();
        }

        //Sự kiện nút Connect
        private void button_Connect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        public void Connect()
        {
            // Kiểm tra nếu Username rỗng thì thông báo
            if (textBox_UserName.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập Player name!");
                return;
            }

            int.TryParse(textBoxPort.Text, out PORT);
            IP = textBoxIP.Text;

            //Tạo client gửi, nhận dữ liệu từ server
            client = new Client();

            //Nếu client không connect được thì sẽ hiện lên thông báo
            if (!client.Connect(textBox_UserName.Text))
            {
                return;
            }

            //Tạo RoomForm
            RF = new RoomForm
            {
                Text = client.username
            };
            //Hiển thị RoomForm
            RF.Show();

            Hide();
        }
    }
}
