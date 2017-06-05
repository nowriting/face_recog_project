namespace Salamander
{
    partial class f_results
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_results));
            this.cmd_back = new System.Windows.Forms.Button();
            this.txtBox_info = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picBox_input = new System.Windows.Forms.PictureBox();
            this.picBox_output1 = new System.Windows.Forms.PictureBox();
            this.picBox_output2 = new System.Windows.Forms.PictureBox();
            this.lbl_error = new System.Windows.Forms.Label();
            this.lbl_iteration = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.cmd_loadNet = new System.Windows.Forms.Button();
            this.cmd_saveNet = new System.Windows.Forms.Button();
            this.cmd_trainNet = new System.Windows.Forms.Button();
            this.cmd_stopTraining = new System.Windows.Forms.Button();
            this.cmd_recognize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_output1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_output2)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_back
            // 
            this.cmd_back.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_back.FlatAppearance.BorderSize = 0;
            this.cmd_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_back.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_back.Location = new System.Drawing.Point(411, 29);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(240, 45);
            this.cmd_back.TabIndex = 0;
            this.cmd_back.Text = "Atpakaļ";
            this.cmd_back.UseVisualStyleBackColor = false;
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // txtBox_info
            // 
            this.txtBox_info.Location = new System.Drawing.Point(41, 175);
            this.txtBox_info.Multiline = true;
            this.txtBox_info.Name = "txtBox_info";
            this.txtBox_info.Size = new System.Drawing.Size(275, 128);
            this.txtBox_info.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Controls.Add(this.picBox_input, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picBox_output1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picBox_output2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(44, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(275, 122);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // picBox_input
            // 
            this.picBox_input.Location = new System.Drawing.Point(3, 3);
            this.picBox_input.Name = "picBox_input";
            this.picBox_input.Size = new System.Drawing.Size(84, 84);
            this.picBox_input.TabIndex = 0;
            this.picBox_input.TabStop = false;
            // 
            // picBox_output1
            // 
            this.picBox_output1.Location = new System.Drawing.Point(93, 3);
            this.picBox_output1.Name = "picBox_output1";
            this.picBox_output1.Size = new System.Drawing.Size(84, 84);
            this.picBox_output1.TabIndex = 1;
            this.picBox_output1.TabStop = false;
            // 
            // picBox_output2
            // 
            this.picBox_output2.Location = new System.Drawing.Point(183, 3);
            this.picBox_output2.Name = "picBox_output2";
            this.picBox_output2.Size = new System.Drawing.Size(89, 84);
            this.picBox_output2.TabIndex = 2;
            this.picBox_output2.TabStop = false;
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbl_error.Location = new System.Drawing.Point(363, 177);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(142, 20);
            this.lbl_error.TabIndex = 3;
            this.lbl_error.Text = "Kļūdas lielums: ";
            // 
            // lbl_iteration
            // 
            this.lbl_iteration.AutoSize = true;
            this.lbl_iteration.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbl_iteration.Location = new System.Drawing.Point(363, 216);
            this.lbl_iteration.Name = "lbl_iteration";
            this.lbl_iteration.Size = new System.Drawing.Size(146, 20);
            this.lbl_iteration.TabIndex = 4;
            this.lbl_iteration.Text = "Iterāciju skaits: ";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.ForeColor = System.Drawing.Color.AliceBlue;
            this.lbl_time.Location = new System.Drawing.Point(363, 249);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(125, 20);
            this.lbl_time.TabIndex = 5;
            this.lbl_time.Text = "Izpildes laiks:";
            // 
            // cmd_loadNet
            // 
            this.cmd_loadNet.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_loadNet.FlatAppearance.BorderSize = 0;
            this.cmd_loadNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_loadNet.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_loadNet.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_loadNet.Location = new System.Drawing.Point(27, 340);
            this.cmd_loadNet.Name = "cmd_loadNet";
            this.cmd_loadNet.Size = new System.Drawing.Size(120, 45);
            this.cmd_loadNet.TabIndex = 6;
            this.cmd_loadNet.Text = "Ielādēt apmācītu tīklu";
            this.cmd_loadNet.UseVisualStyleBackColor = false;
            this.cmd_loadNet.Click += new System.EventHandler(this.cmd_loadNet_Click);
            // 
            // cmd_saveNet
            // 
            this.cmd_saveNet.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_saveNet.FlatAppearance.BorderSize = 0;
            this.cmd_saveNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_saveNet.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_saveNet.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_saveNet.Location = new System.Drawing.Point(153, 340);
            this.cmd_saveNet.Name = "cmd_saveNet";
            this.cmd_saveNet.Size = new System.Drawing.Size(120, 45);
            this.cmd_saveNet.TabIndex = 7;
            this.cmd_saveNet.Text = "Saglabāt tīklu";
            this.cmd_saveNet.UseVisualStyleBackColor = false;
            this.cmd_saveNet.Click += new System.EventHandler(this.cmd_saveNet_Click);
            // 
            // cmd_trainNet
            // 
            this.cmd_trainNet.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_trainNet.FlatAppearance.BorderSize = 0;
            this.cmd_trainNet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_trainNet.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_trainNet.Location = new System.Drawing.Point(279, 340);
            this.cmd_trainNet.Name = "cmd_trainNet";
            this.cmd_trainNet.Size = new System.Drawing.Size(120, 45);
            this.cmd_trainNet.TabIndex = 8;
            this.cmd_trainNet.Text = "Trenēt";
            this.cmd_trainNet.UseVisualStyleBackColor = false;
            this.cmd_trainNet.Click += new System.EventHandler(this.cmd_trainNet_Click);
            // 
            // cmd_stopTraining
            // 
            this.cmd_stopTraining.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_stopTraining.FlatAppearance.BorderSize = 0;
            this.cmd_stopTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_stopTraining.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_stopTraining.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_stopTraining.Location = new System.Drawing.Point(531, 340);
            this.cmd_stopTraining.Name = "cmd_stopTraining";
            this.cmd_stopTraining.Size = new System.Drawing.Size(120, 45);
            this.cmd_stopTraining.TabIndex = 9;
            this.cmd_stopTraining.Text = "Pārtraukt trenēšanu";
            this.cmd_stopTraining.UseVisualStyleBackColor = false;
            this.cmd_stopTraining.Click += new System.EventHandler(this.cmd_stopTraining_Click);
            // 
            // cmd_recognize
            // 
            this.cmd_recognize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_recognize.FlatAppearance.BorderSize = 0;
            this.cmd_recognize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_recognize.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_recognize.Location = new System.Drawing.Point(405, 340);
            this.cmd_recognize.Name = "cmd_recognize";
            this.cmd_recognize.Size = new System.Drawing.Size(120, 45);
            this.cmd_recognize.TabIndex = 10;
            this.cmd_recognize.Text = "Atpazīt";
            this.cmd_recognize.UseVisualStyleBackColor = false;
            this.cmd_recognize.Click += new System.EventHandler(this.cmd_recognize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(363, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Apmācības statuss: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // f_results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmd_recognize);
            this.Controls.Add(this.cmd_stopTraining);
            this.Controls.Add(this.cmd_trainNet);
            this.Controls.Add(this.cmd_saveNet);
            this.Controls.Add(this.cmd_loadNet);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_iteration);
            this.Controls.Add(this.lbl_error);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtBox_info);
            this.Controls.Add(this.cmd_back);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "f_results";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezultāts";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_output1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_output2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_back;
        private System.Windows.Forms.TextBox txtBox_info;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picBox_input;
        private System.Windows.Forms.PictureBox picBox_output1;
        private System.Windows.Forms.PictureBox picBox_output2;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.Label lbl_iteration;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Button cmd_loadNet;
        private System.Windows.Forms.Button cmd_saveNet;
        private System.Windows.Forms.Button cmd_trainNet;
        private System.Windows.Forms.Button cmd_stopTraining;
        private System.Windows.Forms.Button cmd_recognize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}