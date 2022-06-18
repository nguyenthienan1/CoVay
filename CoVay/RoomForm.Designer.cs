
namespace CoVay
{
    partial class RoomForm
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
            this.listViewRoom = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.buttonUpdateListRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewRoom
            // 
            this.listViewRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewRoom.FullRowSelect = true;
            this.listViewRoom.HideSelection = false;
            this.listViewRoom.Location = new System.Drawing.Point(25, 122);
            this.listViewRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewRoom.Name = "listViewRoom";
            this.listViewRoom.Size = new System.Drawing.Size(507, 420);
            this.listViewRoom.TabIndex = 7;
            this.listViewRoom.UseCompatibleStateImageBehavior = false;
            this.listViewRoom.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số phòng";
            this.columnHeader1.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Chủ phòng";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số người chơi trong phòng";
            this.columnHeader3.Width = 225;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(427, 47);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(104, 25);
            this.buttonCreate.TabIndex = 8;
            this.buttonCreate.Text = "Tạo phòng";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(427, 84);
            this.buttonJoin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(104, 25);
            this.buttonJoin.TabIndex = 9;
            this.buttonJoin.Text = "Vào phòng";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // buttonUpdateListRoom
            // 
            this.buttonUpdateListRoom.Location = new System.Drawing.Point(25, 84);
            this.buttonUpdateListRoom.Name = "buttonUpdateListRoom";
            this.buttonUpdateListRoom.Size = new System.Drawing.Size(178, 24);
            this.buttonUpdateListRoom.TabIndex = 12;
            this.buttonUpdateListRoom.Text = "Cập nhật DS phòng";
            this.buttonUpdateListRoom.UseVisualStyleBackColor = true;
            this.buttonUpdateListRoom.Click += new System.EventHandler(this.buttonUpdateListRoom_Click);
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 550);
            this.Controls.Add(this.buttonUpdateListRoom);
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.listViewRoom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RoomForm";
            this.Text = "Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listViewRoom;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.Button buttonUpdateListRoom;
    }
}