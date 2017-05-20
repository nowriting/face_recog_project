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
            this.box_openpic = new System.Windows.Forms.PictureBox();
            this.cmd_open = new System.Windows.Forms.Button();
            this.cmd_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.box_openpic)).BeginInit();
            this.SuspendLayout();
            // 
            // box_openpic
            // 
            this.box_openpic.Location = new System.Drawing.Point(12, 12);
            this.box_openpic.Name = "box_openpic";
            this.box_openpic.Size = new System.Drawing.Size(400, 400);
            this.box_openpic.TabIndex = 0;
            this.box_openpic.TabStop = false;
            // 
            // cmd_open
            // 
            this.cmd_open.Location = new System.Drawing.Point(425, 34);
            this.cmd_open.Name = "cmd_open";
            this.cmd_open.Size = new System.Drawing.Size(200, 50);
            this.cmd_open.TabIndex = 1;
            this.cmd_open.Text = "Atvērt";
            this.cmd_open.UseVisualStyleBackColor = true;
            this.cmd_open.Click += new System.EventHandler(this.cmd_open_Click);
            // 
            // cmd_save
            // 
            this.cmd_save.Location = new System.Drawing.Point(425, 103);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(200, 50);
            this.cmd_save.TabIndex = 2;
            this.cmd_save.Text = "Saglabāt";
            this.cmd_save.UseVisualStyleBackColor = true;
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
            // f_open_resave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.cmd_open);
            this.Controls.Add(this.box_openpic);
            this.Name = "f_open_resave";
            this.RightToLeftLayout = true;
            this.Text = "Open-Save Existing Pic";
            ((System.ComponentModel.ISupportInitialize)(this.box_openpic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox box_openpic;
        private System.Windows.Forms.Button cmd_open;
        private System.Windows.Forms.Button cmd_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

