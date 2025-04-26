namespace bfk_pruyom
{
    partial class Login
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.sataEllipseControl1 = new SATAUiFramework.Controls.SATAEllipseControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userPassword = new SATATextBox();
            this.enterVerify = new FrameworkTest.SATAButton();
            this.userLogin = new SATATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // sataEllipseControl1
            // 
            this.sataEllipseControl1.CornerRadius = 25;
            this.sataEllipseControl1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.userPassword);
            this.panel1.Controls.Add(this.enterVerify);
            this.panel1.Controls.Add(this.userLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 463);
            this.panel1.TabIndex = 1;
            // 
            // userPassword
            // 
            this.userPassword.BackColor = System.Drawing.Color.White;
            this.userPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.userPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.userPassword.BorderRadius = 5;
            this.userPassword.BorderSize = 3;
            this.userPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userPassword.Icon = ((System.Drawing.Image)(resources.GetObject("userPassword.Icon")));
            this.userPassword.IconSize = new System.Drawing.Size(26, 26);
            this.userPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userPassword.Location = new System.Drawing.Point(31, 304);
            this.userPassword.Multiline = false;
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = true;
            this.userPassword.PlaceholderColor = System.Drawing.Color.Gray;
            this.userPassword.PlaceholderText = "Пароль";
            this.userPassword.Size = new System.Drawing.Size(228, 37);
            this.userPassword.TabIndex = 6;
            this.userPassword.Text = "sataTextBox2";
            this.userPassword.Texts = "";
            this.userPassword.UnderlinedStyle = false;
            // 
            // enterVerify
            // 
            this.enterVerify.ButtonText = "Вхід";
            this.enterVerify.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.CheckedForeColor = System.Drawing.Color.White;
            this.enterVerify.CheckedImageTint = System.Drawing.Color.White;
            this.enterVerify.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enterVerify.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.enterVerify.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.enterVerify.HoverBackground = System.Drawing.Color.White;
            this.enterVerify.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.HoverImage = ((System.Drawing.Image)(resources.GetObject("enterVerify.HoverImage")));
            this.enterVerify.HoverImageTint = System.Drawing.Color.White;
            this.enterVerify.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.Image = ((System.Drawing.Image)(resources.GetObject("enterVerify.Image")));
            this.enterVerify.ImageAutoCenter = true;
            this.enterVerify.ImageExpand = new System.Drawing.Point(3, 3);
            this.enterVerify.ImageOffset = new System.Drawing.Point(0, 0);
            this.enterVerify.ImageTint = System.Drawing.Color.White;
            this.enterVerify.IsToggleButton = false;
            this.enterVerify.IsToggled = false;
            this.enterVerify.Location = new System.Drawing.Point(31, 372);
            this.enterVerify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.enterVerify.Name = "enterVerify";
            this.enterVerify.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.NormalForeColor = System.Drawing.Color.White;
            this.enterVerify.NormalOutline = System.Drawing.Color.Empty;
            this.enterVerify.OutlineThickness = 2F;
            this.enterVerify.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.enterVerify.PressedForeColor = System.Drawing.Color.White;
            this.enterVerify.PressedImageTint = System.Drawing.Color.White;
            this.enterVerify.PressedOutline = System.Drawing.Color.Empty;
            this.enterVerify.Rounding = new System.Windows.Forms.Padding(5);
            this.enterVerify.Size = new System.Drawing.Size(228, 51);
            this.enterVerify.TabIndex = 5;
            this.enterVerify.TextAutoCenter = true;
            this.enterVerify.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // userLogin
            // 
            this.userLogin.BackColor = System.Drawing.Color.White;
            this.userLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.userLogin.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.userLogin.BorderRadius = 5;
            this.userLogin.BorderSize = 3;
            this.userLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userLogin.Icon = ((System.Drawing.Image)(resources.GetObject("userLogin.Icon")));
            this.userLogin.IconSize = new System.Drawing.Size(26, 26);
            this.userLogin.Location = new System.Drawing.Point(31, 254);
            this.userLogin.Multiline = false;
            this.userLogin.Name = "userLogin";
            this.userLogin.PasswordChar = false;
            this.userLogin.PlaceholderColor = System.Drawing.Color.Gray;
            this.userLogin.PlaceholderText = "Ім\'я користувача";
            this.userLogin.Size = new System.Drawing.Size(228, 37);
            this.userLogin.TabIndex = 3;
            this.userLogin.Text = "sataTextBox1";
            this.userLogin.Texts = "";
            this.userLogin.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.label1.Location = new System.Drawing.Point(13, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Автоматизоване робоче місце\r\nсекретаря приймальної комісії";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(261, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(291, 463);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.Controls.SATAEllipseControl sataEllipseControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private SATATextBox userLogin;
        private FrameworkTest.SATAButton enterVerify;
        private SATATextBox userPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

