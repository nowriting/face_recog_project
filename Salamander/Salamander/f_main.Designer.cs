namespace Salamander
{
    partial class f_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_main));
            this.cmd_take_photo = new System.Windows.Forms.Button();
            this.cmd_open_resave = new System.Windows.Forms.Button();
            this.cmd_recognize = new System.Windows.Forms.Button();
            this.cmd_settings = new System.Windows.Forms.Button();
            this.cmd_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd_take_photo
            // 
            this.cmd_take_photo.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_take_photo.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.cmd_take_photo.FlatAppearance.BorderSize = 0;
            this.cmd_take_photo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_take_photo.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_take_photo.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_take_photo.Location = new System.Drawing.Point(34, 39);
            this.cmd_take_photo.Name = "cmd_take_photo";
            this.cmd_take_photo.Size = new System.Drawing.Size(240, 45);
            this.cmd_take_photo.TabIndex = 0;
            this.cmd_take_photo.Text = "Uzņemt foto";
            this.cmd_take_photo.UseVisualStyleBackColor = false;
            this.cmd_take_photo.Click += new System.EventHandler(this.b_take_photo_Click);
            // 
            // cmd_open_resave
            // 
            this.cmd_open_resave.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_open_resave.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmd_open_resave.FlatAppearance.BorderSize = 0;
            this.cmd_open_resave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_open_resave.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_open_resave.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_open_resave.Location = new System.Drawing.Point(34, 109);
            this.cmd_open_resave.Name = "cmd_open_resave";
            this.cmd_open_resave.Size = new System.Drawing.Size(240, 45);
            this.cmd_open_resave.TabIndex = 1;
            this.cmd_open_resave.Text = "Atvērt foto";
            this.cmd_open_resave.UseVisualStyleBackColor = false;
            this.cmd_open_resave.Click += new System.EventHandler(this.b_open_resave_Click);
            // 
            // cmd_recognize
            // 
            this.cmd_recognize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_recognize.FlatAppearance.BorderSize = 0;
            this.cmd_recognize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_recognize.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_recognize.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_recognize.Location = new System.Drawing.Point(34, 179);
            this.cmd_recognize.Name = "cmd_recognize";
            this.cmd_recognize.Size = new System.Drawing.Size(240, 45);
            this.cmd_recognize.TabIndex = 2;
            this.cmd_recognize.Text = "Atpazīt seju";
            this.cmd_recognize.UseVisualStyleBackColor = false;
            this.cmd_recognize.Click += new System.EventHandler(this.b_recognize_Click);
            // 
            // cmd_settings
            // 
            this.cmd_settings.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_settings.FlatAppearance.BorderSize = 0;
            this.cmd_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_settings.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_settings.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_settings.Location = new System.Drawing.Point(34, 243);
            this.cmd_settings.Name = "cmd_settings";
            this.cmd_settings.Size = new System.Drawing.Size(240, 45);
            this.cmd_settings.TabIndex = 3;
            this.cmd_settings.Text = "Iestatījumi";
            this.cmd_settings.UseVisualStyleBackColor = false;
            this.cmd_settings.Click += new System.EventHandler(this.b_settings_Click);
            // 
            // cmd_exit
            // 
            this.cmd_exit.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.cmd_exit.FlatAppearance.BorderSize = 0;
            this.cmd_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_exit.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_exit.ForeColor = System.Drawing.Color.AliceBlue;
            this.cmd_exit.Location = new System.Drawing.Point(34, 311);
            this.cmd_exit.Name = "cmd_exit";
            this.cmd_exit.Size = new System.Drawing.Size(240, 45);
            this.cmd_exit.TabIndex = 4;
            this.cmd_exit.Text = "Iziet";
            this.cmd_exit.UseVisualStyleBackColor = false;
            this.cmd_exit.Click += new System.EventHandler(this.cmd_exit_Click);
            // 
            // f_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.cmd_exit);
            this.Controls.Add(this.cmd_settings);
            this.Controls.Add(this.cmd_recognize);
            this.Controls.Add(this.cmd_open_resave);
            this.Controls.Add(this.cmd_take_photo);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "f_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Galvenā Izvēlne";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_take_photo;
        private System.Windows.Forms.Button cmd_open_resave;
        private System.Windows.Forms.Button cmd_recognize;
        private System.Windows.Forms.Button cmd_settings;
        private System.Windows.Forms.Button cmd_exit;
    }
}