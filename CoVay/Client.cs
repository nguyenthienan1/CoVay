
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CoVay
{
    public class Client
    {
        public string username;
        public TcpClient tcpClient;
        public NetworkStream stream;
        public BinaryReader reader;
        public BinaryWriter writer;
        public FormBoard formBorad;
        public List<Message> ListMessage;

        public bool Connect(string usrname)
        {
            try
            {
                ListMessage = new List<Message>();
                tcpClient = new TcpClient();
                tcpClient.Connect(StarterForm.IP, StarterForm.PORT);
                stream = tcpClient.GetStream();
                reader = new BinaryReader(stream, new UTF8Encoding());
                writer = new BinaryWriter(stream, new UTF8Encoding());
                username = usrname;
                SendUserName();
                new Thread(SendMsg).Start();
                new Thread(ReceiveMsg).Start();
                return true;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến máy chủ, kiểm tra IP & PORT rồi thử lại!", "Kết nối thất bại");
                return false;
            }
        }

        public void SendMsg()
        {
            while (tcpClient.Connected)
            {
                if (ListMessage.Count > 0)
                {
                    try
                    {
                        Message m = ListMessage[0];
                        ListMessage.RemoveAt(0);
                        byte[] data = m.GetData();
                        writer.Write(data.Length);
                        writer.Write(m.cmd);
                        writer.Write(data);
                        writer.Flush();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Loi gui Msg");
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void SendMessage(Message m)
        {
            ListMessage.Add(m);
        }

        public void ReceiveMsg()
        {
            while (tcpClient.Connected)
            {
                try
                {
                    int length = reader.ReadInt32();
                    int cmd = reader.ReadInt32();
                    byte[] data = reader.ReadBytes(length);
                    Message m = new Message(cmd, data);
                    ProcessMsg(m);
                }
                catch (Exception e)
                {
                    tcpClient.Close();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Loi nhan Msg");
                }
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Gửi Message chat cho Server
        /// </summary>
        /// <param name="mess"></param>
        public void SendChat(string mess)
        {
            try
            {
                Message m = new Message(2);
                m.writer.Write(mess);
                SendMessage(m);
            }
            catch
            { }
        }

        /// <summary>
        /// Gửi vị trí quân cờ cho Server
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SendXYStone(int x, int y)
        {
            try
            {
                Message m = new Message(1);
                m.writer.Write(x);
                m.writer.Write(y);
                SendMessage(m);
            }
            catch { }
        }

        /// <summary>
        /// Gửi tên người chơi
        /// </summary>
        public void SendUserName()
        {
            try
            {
                Message m = new Message(0);
                m.writer.Write(username);
                SendMessage(m);
            }
            catch { }
        }

        /// <summary>
        /// Gửi lệnh sẵn sàng
        /// </summary>
        public void SendReadyFight()
        {
            try
            {
                Message m = new Message(5);
                SendMessage(m);
            }
            catch { }
        }

        /// <summary>
        /// Gửi lệnh bỏ lượt
        /// </summary>
        public void SendBoLuot()
        {
            try
            {
                Message m = new Message(3);
                SendMessage(m);
            }
            catch { }
        }

        /// <summary>
        /// Gửi lệnh tạo Room
        /// </summary>
        public void SendCreateRoom()
        {
            try
            {
                Message m = new Message(4);
                SendMessage(m);
            }
            catch
            { }
        }

        /// <summary>
        /// Gửi lệnh vào Room
        /// </summary>
        /// <param name="roomnumber"></param>
        public void SendJoinRoom(int roomnumber)
        {
            try
            {
                Message m = new Message(6);
                m.writer.Write(roomnumber);
                SendMessage(m);
            }
            catch
            { }
        }

        /// <summary>
        /// Gửi lệnh khi thoát Room
        /// </summary>
        public void SendCloseRoom()
        {
            try
            {
                Message m = new Message(7);
                SendMessage(m);
            }
            catch { }
        }

        public void SendUpdateListRoom()
        {
            try
            {
                Message m = new Message(8);
                SendMessage(m);
            }
            catch { }
        }



        /// <summary>
        /// Xử lý Msg từ Server
        /// </summary>
        /// <param name="msg"></param>
        public void ProcessMsg(Message m)
        {
            switch (m.cmd)
            {
                case 0: //Nhận lệnh hiển thị MessageBox
                    string notifi = m.reader.ReadString();
                    StarterForm.RF.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show(notifi, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));

                    break;

                case 1: //Nhận các vị trí quân cờ server gửi và hiện lên bàn cờ

                    formBorad.board.StoneNum = m.reader.ReadInt32(); //Nhận vị trí quân cờ mới đặt để đánh dấu
                    int n = ConstNumber.linenum + 1;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            formBorad.board.matrix[j, i] = m.reader.ReadInt16();
                        }
                    }
                    StarterForm.RF.BeginInvoke(new Action(() =>
                    {
                        //Draw lại picturebox
                        formBorad.pictureBox1.Invalidate();
                    }));

                    break;

                case 2: //Nhận chat từ server
                    string str2 = m.reader.ReadString() + "\n";
                    StarterForm.RF.BeginInvoke(new Action(() =>
                    {
                        //hiển thị lên khung chat
                        formBorad.richTextBox1.Text += str2;
                    }));

                    break;

                case 3: //Nhận listroom từ server
                    try
                    {
                        int roomcount = m.reader.ReadInt32();
                        StarterForm.RF.listViewRoom.BeginInvoke(new Action(() =>
                            {
                                StarterForm.RF.listViewRoom.Items.Clear();
                                for (int i1 = 0; i1 < roomcount; i1++)
                                {
                                    int roomnum = m.reader.ReadInt32();
                                    string mastername = m.reader.ReadString();
                                    int countplayer = m.reader.ReadInt32();
                                    ListViewItem item = new ListViewItem(new string[] { roomnum.ToString(), mastername, countplayer.ToString() });
                                    StarterForm.RF.listViewRoom.Items.Add(item);
                                }
                            }));
                    }
                    catch { }

                    break;

                case 4:
                    break;

                case 5:
                    //Nhận lệnh reset board
                    StarterForm.RF.BeginInvoke(new Action(() =>
                    {
                        formBorad.board = new Board();
                        //Draw lại picturebox
                        formBorad.pictureBox1.Invalidate();
                    }));
                    break;

                case 6: //Nhận lệnh tạo formboard
                    int rn = m.reader.ReadInt32();
                    StarterForm.RF.BeginInvoke(new Action(() =>
                        {
                            formBorad = new FormBoard
                            {
                                Text = "Room: " + rn
                            };
                            formBorad.Show();
                        }));
                    break;

                case 7:
                    bool inturn = m.reader.ReadBoolean();
                    bool dostop = m.reader.ReadBoolean();
                    formBorad.SetTimeOut(inturn, dostop);
                    break;
            }
        }
    }
}
