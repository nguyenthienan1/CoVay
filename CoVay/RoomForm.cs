using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoVay
{
    public partial class RoomForm : Form
    {

        public RoomForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            StarterForm.client.SendCreateRoom();
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            if (listViewRoom.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phòng nào！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string str = listViewRoom.SelectedItems[0].SubItems[0].Text;
            int roomnb = int.Parse(str);
            StarterForm.client.SendJoinRoom(roomnb);
        }

        private void buttonUpdateListRoom_Click(object sender, EventArgs e)
        {
            StarterForm.client.SendUpdateListRoom();
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát game?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                StarterForm.client.tcpClient.Close();
                Dispose();
                Close();
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
