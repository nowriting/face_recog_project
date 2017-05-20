namespace Salamander
{
    partial class f_open_camera
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
            this.cmd_startCapture = new System.Windows.Forms.Button();
            this.list_selectCamera = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picbox_preview1 = new System.Windows.Forms.PictureBox();
            this.picbox_preview2 = new System.Windows.Forms.PictureBox();
            this.cmd_capture = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmd_save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_preview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_preview2)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_startCapture
            // 
            this.cmd_startCapture.Location = new System.Drawing.Point(38, 12);
            this.cmd_startCapture.Name = "cmd_startCapture";
            this.cmd_startCapture.Size = new System.Drawing.Size(101, 23);
            this.cmd_startCapture.TabIndex = 0;
            this.cmd_startCapture.Text = "Ieslēgt kameru";
            this.cmd_startCapture.UseVisualStyleBackColor = true;
            this.cmd_startCapture.Click += new System.EventHandler(this.cmd_startCapture_Click);
            // 
            // list_selectCamera
            // 
            this.list_selectCamera.FormattingEnabled = true;
            this.list_selectCamera.Location = new System.Drawing.Point(156, 12);
            this.list_selectCamera.Name = "list_selectCamera";
            this.list_selectCamera.Size = new System.Drawing.Size(161, 21);
            this.list_selectCamera.TabIndex = 1;
            this.list_selectCamera.Text = "Izvēlēties kameru";
            this.list_selectCamera.SelectedIndexChanged += new System.EventHandler(this.list_selectCamera_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picbox_preview1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picbox_preview2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 216);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // picbox_preview1
            // 
            this.picbox_preview1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_preview1.Location = new System.Drawing.Point(3, 3);
            this.picbox_preview1.Name = "picbox_preview1";
            this.picbox_preview1.Size = new System.Drawing.Size(279, 210);
            this.picbox_preview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_preview1.TabIndex = 0;
            this.picbox_preview1.TabStop = false;
            // 
            // picbox_preview2
            // 
            this.picbox_preview2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_preview2.Location = new System.Drawing.Point(288, 3);
            this.picbox_preview2.Name = "picbox_preview2";
            this.picbox_preview2.Size = new System.Drawing.Size(280, 210);
            this.picbox_preview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox_preview2.TabIndex = 1;
            this.picbox_preview2.TabStop = false;
            // 
            // cmd_capture
            // 
            this.cmd_capture.Location = new System.Drawing.Point(323, 12);
            this.cmd_capture.Name = "cmd_capture";
            this.cmd_capture.Size = new System.Drawing.Size(118, 23);
            this.cmd_capture.TabIndex = 3;
            this.cmd_capture.Text = "Knipsēt";
            this.cmd_capture.UseVisualStyleBackColor = true;
            this.cmd_capture.Click += new System.EventHandler(this.cmd_capture_Click);
            // 
            // cmd_save
            // 
            this.cmd_save.Location = new System.Drawing.Point(485, 12);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(118, 23);
            this.cmd_save.TabIndex = 4;
            this.cmd_save.Text = "Saglabāt attēlu";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // f_open_camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 313);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.cmd_capture);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.list_selectCamera);
            this.Controls.Add(this.cmd_startCapture);
            this.Name = "f_open_camera";
            this.Text = "open_camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.open_camera_FormClosing);
            this.Load += new System.EventHandler(this.open_camera_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_preview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_preview2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_startCapture;
        private System.Windows.Forms.ComboBox list_selectCamera;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picbox_preview1;
        private System.Windows.Forms.PictureBox picbox_preview2;
        private System.Windows.Forms.Button cmd_capture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button cmd_save;
    }
}