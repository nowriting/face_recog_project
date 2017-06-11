namespace Salamander
{
    partial class f_settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_settings));
            this.cmd_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmd_toRecog = new System.Windows.Forms.Button();
            this.cmd_imgPro = new System.Windows.Forms.Button();
            this.num_maxIterations = new System.Windows.Forms.NumericUpDown();
            this.txtBox_maxError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_maxIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_back
            // 
            this.cmd_back.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_back.FlatAppearance.BorderSize = 0;
            this.cmd_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_back.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_back.Location = new System.Drawing.Point(61, 180);
            this.cmd_back.Name = "cmd_back";
            this.cmd_back.Size = new System.Drawing.Size(240, 45);
            this.cmd_back.TabIndex = 0;
            this.cmd_back.Text = "Atpakaļ";
            this.cmd_back.UseVisualStyleBackColor = false;
            this.cmd_back.Click += new System.EventHandler(this.cmd_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iestatīt maksimālo kļūdu: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(22, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uzstādīt maksimālo iterāciju skaitu: ";
            // 
            // cmd_toRecog
            // 
            this.cmd_toRecog.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_toRecog.FlatAppearance.BorderSize = 0;
            this.cmd_toRecog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_toRecog.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_toRecog.Location = new System.Drawing.Point(61, 315);
            this.cmd_toRecog.Name = "cmd_toRecog";
            this.cmd_toRecog.Size = new System.Drawing.Size(240, 45);
            this.cmd_toRecog.TabIndex = 3;
            this.cmd_toRecog.Text = "Uz sejas atpazīšanu\r\n";
            this.cmd_toRecog.UseVisualStyleBackColor = false;
            this.cmd_toRecog.Click += new System.EventHandler(this.cmd_toRecog_Click);
            // 
            // cmd_imgPro
            // 
            this.cmd_imgPro.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_imgPro.FlatAppearance.BorderSize = 0;
            this.cmd_imgPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_imgPro.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_imgPro.Location = new System.Drawing.Point(61, 248);
            this.cmd_imgPro.Name = "cmd_imgPro";
            this.cmd_imgPro.Size = new System.Drawing.Size(240, 45);
            this.cmd_imgPro.TabIndex = 4;
            this.cmd_imgPro.Text = "Uz attēla apstrādi";
            this.cmd_imgPro.UseVisualStyleBackColor = false;
            this.cmd_imgPro.Click += new System.EventHandler(this.cmd_imgPro_Click);
            // 
            // num_maxIterations
            // 
            this.num_maxIterations.Location = new System.Drawing.Point(369, 73);
            this.num_maxIterations.Name = "num_maxIterations";
            this.num_maxIterations.Size = new System.Drawing.Size(120, 27);
            this.num_maxIterations.TabIndex = 5;
            // 
            // txtBox_maxError
            // 
            this.txtBox_maxError.Location = new System.Drawing.Point(369, 32);
            this.txtBox_maxError.Name = "txtBox_maxError";
            this.txtBox_maxError.Size = new System.Drawing.Size(120, 27);
            this.txtBox_maxError.TabIndex = 6;
            this.txtBox_maxError.TextChanged += new System.EventHandler(this.txtBox_maxError_TextChanged);
            // 
            // f_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Salamander.Properties.Resources.background4;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.txtBox_maxError);
            this.Controls.Add(this.num_maxIterations);
            this.Controls.Add(this.cmd_imgPro);
            this.Controls.Add(this.cmd_toRecog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmd_back);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "f_settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iestatījumi";
            ((System.ComponentModel.ISupportInitialize)(this.num_maxIterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmd_toRecog;
        private System.Windows.Forms.Button cmd_imgPro;
        private System.Windows.Forms.NumericUpDown num_maxIterations;
        private System.Windows.Forms.TextBox txtBox_maxError;
    }
}