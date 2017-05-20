namespace Salamander
{
    partial class f_open_resave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_open_resave));
            this.box_openpic = new System.Windows.Forms.PictureBox();
            this.cmd_open = new System.Windows.Forms.Button();
            this.cmd_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmd_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.box_openpic)).BeginInit();
            this.SuspendLayout();
            // 
            // box_openpic
            // 
            this.box_openpic.Location = new System.Drawing.Point(28, 24);
            this.box_openpic.Margin = new System.Windows.Forms.Padding(20);
            this.box_openpic.Name = "box_openpic";
            this.box_openpic.Padding = new System.Windows.Forms.Padding(20);
            this.box_openpic.Size = new System.Drawing.Size(370, 370);
            this.box_openpic.TabIndex = 0;
            this.box_openpic.TabStop = false;
            // 
            // cmd_open
            // 
            this.cmd_open.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_open.FlatAppearance.BorderSize = 0;
            this.cmd_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_open.Location = new System.Drawing.Point(423, 116);
            this.cmd_open.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmd_open.Name = "cmd_open";
            this.cmd_open.Size = new System.Drawing.Size(240, 45);
            this.cmd_open.TabIndex = 1;
            this.cmd_open.Text = "Atvērt";
            this.cmd_open.UseVisualStyleBackColor = false;
            this.cmd_open.Click += new System.EventHandler(this.cmd_open_Click);
            // 
            // cmd_save
            // 
            this.cmd_save.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_save.FlatAppearance.BorderSize = 0;
            this.cmd_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_save.Location = new System.Drawing.Point(423, 185);
            this.cmd_save.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(240, 45);
            this.cmd_save.TabIndex = 2;
            this.cmd_save.Text = "Saglabāt";
            this.cmd_save.UseVisualStyleBackColor = false;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "r3r";
            // 
            // cmd_back
            // 
            this.cmd_back.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_back.FlatAppearance.BorderSize = 0;
            this.cmd_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_back.Location = new System.Drawing.Point(423, 250);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(240, 45);
            this.cmd_back.TabIndex = 3;
            this.cmd_back.Text = "Atpakaļ";
            this.cmd_back.UseVisualStyleBackColor = false;
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // f_open_resave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.cmd_back);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.cmd_open);
            this.Controls.Add(this.box_openpic);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.AliceBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "f_open_resave";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atvērt - Saglabāt attēlu";
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.box_openpic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox box_openpic;
        private System.Windows.Forms.Button cmd_open;
        private System.Windows.Forms.Button cmd_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button cmd_back;
    }
}

