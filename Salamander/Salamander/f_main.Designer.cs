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
            this.b_take_photo = new System.Windows.Forms.Button();
            this.b_open_resave = new System.Windows.Forms.Button();
            this.b_recognize = new System.Windows.Forms.Button();
            this.b_settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_take_photo
            // 
            this.b_take_photo.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.b_take_photo.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.b_take_photo.FlatAppearance.BorderSize = 0;
            this.b_take_photo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_take_photo.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_take_photo.ForeColor = System.Drawing.Color.AliceBlue;
            this.b_take_photo.Location = new System.Drawing.Point(36, 79);
            this.b_take_photo.Name = "b_take_photo";
            this.b_take_photo.Size = new System.Drawing.Size(240, 45);
            this.b_take_photo.TabIndex = 0;
            this.b_take_photo.Text = "Uzņemt foto";
            this.b_take_photo.UseVisualStyleBackColor = false;
            this.b_take_photo.Click += new System.EventHandler(this.b_take_photo_Click);
            // 
            // b_open_resave
            // 
            this.b_open_resave.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.b_open_resave.Cursor = System.Windows.Forms.Cursors.Default;
            this.b_open_resave.FlatAppearance.BorderSize = 0;
            this.b_open_resave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_open_resave.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_open_resave.ForeColor = System.Drawing.Color.AliceBlue;
            this.b_open_resave.Location = new System.Drawing.Point(36, 149);
            this.b_open_resave.Name = "b_open_resave";
            this.b_open_resave.Size = new System.Drawing.Size(240, 45);
            this.b_open_resave.TabIndex = 1;
            this.b_open_resave.Text = "Atvērt foto";
            this.b_open_resave.UseVisualStyleBackColor = false;
            this.b_open_resave.Click += new System.EventHandler(this.b_open_resave_Click);
            // 
            // b_recognize
            // 
            this.b_recognize.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.b_recognize.FlatAppearance.BorderSize = 0;
            this.b_recognize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_recognize.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_recognize.ForeColor = System.Drawing.Color.AliceBlue;
            this.b_recognize.Location = new System.Drawing.Point(36, 219);
            this.b_recognize.Name = "b_recognize";
            this.b_recognize.Size = new System.Drawing.Size(240, 45);
            this.b_recognize.TabIndex = 2;
            this.b_recognize.Text = "Atpazīt seju";
            this.b_recognize.UseVisualStyleBackColor = false;
            this.b_recognize.Click += new System.EventHandler(this.b_recognize_Click);
            // 
            // b_settings
            // 
            this.b_settings.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.b_settings.FlatAppearance.BorderSize = 0;
            this.b_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_settings.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_settings.ForeColor = System.Drawing.Color.AliceBlue;
            this.b_settings.Location = new System.Drawing.Point(36, 283);
            this.b_settings.Name = "b_settings";
            this.b_settings.Size = new System.Drawing.Size(240, 45);
            this.b_settings.TabIndex = 3;
            this.b_settings.Text = "Iestatījumi";
            this.b_settings.UseVisualStyleBackColor = false;
            this.b_settings.Click += new System.EventHandler(this.b_settings_Click);
            // 
            // f_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.b_settings);
            this.Controls.Add(this.b_recognize);
            this.Controls.Add(this.b_open_resave);
            this.Controls.Add(this.b_take_photo);
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

        private System.Windows.Forms.Button b_take_photo;
        private System.Windows.Forms.Button b_open_resave;
        private System.Windows.Forms.Button b_recognize;
        private System.Windows.Forms.Button b_settings;
    }
}