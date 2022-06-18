
namespace CoVay
{
    partial class FormBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.buttonSendMess = new System.Windows.Forms.Button();
            this.buttonReady = new System.Windows.Forms.Button();
            this.buttonBoLuot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.LabelTime = new System.Windows.Forms.Label();
            this.labelInTurn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 67);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chat:";
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Location = new System.Drawing.Point(497, 433);
            this.textBox_Chat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.Size = new System.Drawing.Size(179, 23);
            this.textBox_Chat.TabIndex = 7;
            this.textBox_Chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Chat_KeyDown);
            // 
            // buttonSendMess
            // 
            this.buttonSendMess.Location = new System.Drawing.Point(497, 492);
            this.buttonSendMess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSendMess.Name = "buttonSendMess";
            this.buttonSendMess.Size = new System.Drawing.Size(100, 25);
            this.buttonSendMess.TabIndex = 8;
            this.buttonSendMess.Text = "Gửi tin nhắn";
            this.buttonSendMess.UseVisualStyleBackColor = true;
            this.buttonSendMess.Click += new System.EventHandler(this.buttonSendMess_Click);
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(12, 23);
            this.buttonReady.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(100, 25);
            this.buttonReady.TabIndex = 10;
            this.buttonReady.Text = "Sẵn sàng";
            this.buttonReady.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // buttonBoLuot
            // 
            this.buttonBoLuot.Location = new System.Drawing.Point(387, 25);
            this.buttonBoLuot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBoLuot.Name = "buttonBoLuot";
            this.buttonBoLuot.Size = new System.Drawing.Size(75, 23);
            this.buttonBoLuot.TabIndex = 11;
            this.buttonBoLuot.Text = "Bỏ lượt";
            this.buttonBoLuot.UseVisualStyleBackColor = true;
            this.buttonBoLuot.Click += new System.EventHandler(this.buttonBoLuot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(494, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Thời gian còn lại:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(497, 217);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(264, 186);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LabelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.LabelTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LabelTime.Location = new System.Drawing.Point(659, 31);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(17, 25);
            this.LabelTime.TabIndex = 16;
            this.LabelTime.Text = " ";
            // 
            // labelInTurn
            // 
            this.labelInTurn.AutoSize = true;
            this.labelInTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.labelInTurn.ForeColor = System.Drawing.Color.Black;
            this.labelInTurn.Location = new System.Drawing.Point(492, 67);
            this.labelInTurn.Name = "labelInTurn";
            this.labelInTurn.Size = new System.Drawing.Size(173, 25);
            this.labelInTurn.TabIndex = 17;
            this.labelInTurn.Text = "Chờ bắt đầu trận";
            // 
            // FormBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 592);
            this.Controls.Add(this.labelInTurn);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBoLuot);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.buttonSendMess);
            this.Controls.Add(this.textBox_Chat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "FormBoard";
            this.Text = "FormBorad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBoard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.Button buttonSendMess;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.Button buttonBoLuot;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label labelInTurn;
    }
}

