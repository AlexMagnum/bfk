
namespace bfk_pruyom.UC
{
    partial class ProgramUsers
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramUsers));
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sataPanel2 = new SATAUiFramework.SATAPanel();
            this.sataButton1 = new FrameworkTest.SATAButton();
            this.enterVerify = new FrameworkTest.SATAButton();
            this.sataButton2 = new FrameworkTest.SATAButton();
            this.pusername = new SATATextBox();
            this.userRealSurname = new SATATextBox();
            this.userRealName = new SATATextBox();
            this.userpassword = new SATATextBox();
            this.position = new SATATextBox();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.sataPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sataPanel1
            // 
            this.sataPanel1.BackColor = System.Drawing.Color.White;
            this.sataPanel1.BackColor2 = System.Drawing.Color.White;
            this.sataPanel1.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 10;
            borderRadius1.BottomRight = 10;
            borderRadius1.TopLeft = 10;
            borderRadius1.TopRight = 10;
            this.sataPanel1.BorderRadius = borderRadius1;
            this.sataPanel1.BorderThickness = 0;
            this.sataPanel1.Controls.Add(this.dataGridView1);
            this.sataPanel1.Location = new System.Drawing.Point(12, 18);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(622, 561);
            this.sataPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(622, 561);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // sataPanel2
            // 
            this.sataPanel2.BackColor = System.Drawing.Color.White;
            this.sataPanel2.BackColor2 = System.Drawing.Color.White;
            this.sataPanel2.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 10;
            borderRadius2.BottomRight = 10;
            borderRadius2.TopLeft = 10;
            borderRadius2.TopRight = 10;
            this.sataPanel2.BorderRadius = borderRadius2;
            this.sataPanel2.BorderThickness = 0;
            this.sataPanel2.Controls.Add(this.sataButton1);
            this.sataPanel2.Controls.Add(this.enterVerify);
            this.sataPanel2.Controls.Add(this.sataButton2);
            this.sataPanel2.Controls.Add(this.pusername);
            this.sataPanel2.Controls.Add(this.position);
            this.sataPanel2.Controls.Add(this.userRealSurname);
            this.sataPanel2.Controls.Add(this.userRealName);
            this.sataPanel2.Controls.Add(this.userpassword);
            this.sataPanel2.Location = new System.Drawing.Point(640, 18);
            this.sataPanel2.Name = "sataPanel2";
            this.sataPanel2.Size = new System.Drawing.Size(238, 561);
            this.sataPanel2.TabIndex = 1;
            // 
            // sataButton1
            // 
            this.sataButton1.ButtonText = "Видалити користувача";
            this.sataButton1.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sataButton1.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton1.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton1.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sataButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sataButton1.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.sataButton1.HoverBackground = System.Drawing.Color.White;
            this.sataButton1.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sataButton1.HoverImage = ((System.Drawing.Image)(resources.GetObject("sataButton1.HoverImage")));
            this.sataButton1.HoverImageTint = System.Drawing.Color.White;
            this.sataButton1.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sataButton1.Image = ((System.Drawing.Image)(resources.GetObject("sataButton1.Image")));
            this.sataButton1.ImageAutoCenter = false;
            this.sataButton1.ImageExpand = new System.Drawing.Point(3, 3);
            this.sataButton1.ImageOffset = new System.Drawing.Point(20, 0);
            this.sataButton1.ImageTint = System.Drawing.Color.White;
            this.sataButton1.IsToggleButton = false;
            this.sataButton1.IsToggled = false;
            this.sataButton1.Location = new System.Drawing.Point(3, 502);
            this.sataButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sataButton1.Name = "sataButton1";
            this.sataButton1.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sataButton1.NormalForeColor = System.Drawing.Color.White;
            this.sataButton1.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton1.OutlineThickness = 2F;
            this.sataButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sataButton1.PressedForeColor = System.Drawing.Color.White;
            this.sataButton1.PressedImageTint = System.Drawing.Color.White;
            this.sataButton1.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton1.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton1.Size = new System.Drawing.Size(231, 40);
            this.sataButton1.TabIndex = 12;
            this.sataButton1.TextAutoCenter = false;
            this.sataButton1.TextOffset = new System.Drawing.Point(5, 0);
            this.sataButton1.Click += new System.EventHandler(this.sataButton1_Click);
            // 
            // enterVerify
            // 
            this.enterVerify.ButtonText = "Редагувати користувача";
            this.enterVerify.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.CheckedForeColor = System.Drawing.Color.White;
            this.enterVerify.CheckedImageTint = System.Drawing.Color.White;
            this.enterVerify.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enterVerify.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.enterVerify.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.enterVerify.HoverBackground = System.Drawing.Color.White;
            this.enterVerify.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.HoverImage = ((System.Drawing.Image)(resources.GetObject("enterVerify.HoverImage")));
            this.enterVerify.HoverImageTint = System.Drawing.Color.White;
            this.enterVerify.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.enterVerify.Image = ((System.Drawing.Image)(resources.GetObject("enterVerify.Image")));
            this.enterVerify.ImageAutoCenter = false;
            this.enterVerify.ImageExpand = new System.Drawing.Point(3, 3);
            this.enterVerify.ImageOffset = new System.Drawing.Point(20, 0);
            this.enterVerify.ImageTint = System.Drawing.Color.White;
            this.enterVerify.IsToggleButton = false;
            this.enterVerify.IsToggled = false;
            this.enterVerify.Location = new System.Drawing.Point(3, 456);
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
            this.enterVerify.Size = new System.Drawing.Size(231, 40);
            this.enterVerify.TabIndex = 13;
            this.enterVerify.TextAutoCenter = false;
            this.enterVerify.TextOffset = new System.Drawing.Point(5, 0);
            this.enterVerify.Click += new System.EventHandler(this.enterVerify_Click);
            // 
            // sataButton2
            // 
            this.sataButton2.ButtonText = "Додати користувача";
            this.sataButton2.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.sataButton2.CheckedForeColor = System.Drawing.Color.White;
            this.sataButton2.CheckedImageTint = System.Drawing.Color.White;
            this.sataButton2.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.sataButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sataButton2.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.sataButton2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.sataButton2.HoverBackground = System.Drawing.Color.White;
            this.sataButton2.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.sataButton2.HoverImage = ((System.Drawing.Image)(resources.GetObject("sataButton2.HoverImage")));
            this.sataButton2.HoverImageTint = System.Drawing.Color.White;
            this.sataButton2.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.sataButton2.Image = ((System.Drawing.Image)(resources.GetObject("sataButton2.Image")));
            this.sataButton2.ImageAutoCenter = false;
            this.sataButton2.ImageExpand = new System.Drawing.Point(3, 3);
            this.sataButton2.ImageOffset = new System.Drawing.Point(20, 0);
            this.sataButton2.ImageTint = System.Drawing.Color.White;
            this.sataButton2.IsToggleButton = false;
            this.sataButton2.IsToggled = false;
            this.sataButton2.Location = new System.Drawing.Point(3, 410);
            this.sataButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sataButton2.Name = "sataButton2";
            this.sataButton2.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.sataButton2.NormalForeColor = System.Drawing.Color.White;
            this.sataButton2.NormalOutline = System.Drawing.Color.Empty;
            this.sataButton2.OutlineThickness = 2F;
            this.sataButton2.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(125)))), ((int)(((byte)(100)))));
            this.sataButton2.PressedForeColor = System.Drawing.Color.White;
            this.sataButton2.PressedImageTint = System.Drawing.Color.White;
            this.sataButton2.PressedOutline = System.Drawing.Color.Empty;
            this.sataButton2.Rounding = new System.Windows.Forms.Padding(5);
            this.sataButton2.Size = new System.Drawing.Size(232, 40);
            this.sataButton2.TabIndex = 11;
            this.sataButton2.TextAutoCenter = false;
            this.sataButton2.TextOffset = new System.Drawing.Point(5, 0);
            this.sataButton2.Click += new System.EventHandler(this.sataButton2_Click);
            // 
            // pusername
            // 
            this.pusername.BackColor = System.Drawing.Color.White;
            this.pusername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.pusername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.pusername.BorderRadius = 5;
            this.pusername.BorderSize = 3;
            this.pusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pusername.Icon = ((System.Drawing.Image)(resources.GetObject("pusername.Icon")));
            this.pusername.IconSize = new System.Drawing.Size(20, 20);
            this.pusername.Location = new System.Drawing.Point(3, 17);
            this.pusername.Multiline = false;
            this.pusername.Name = "pusername";
            this.pusername.PasswordChar = false;
            this.pusername.PlaceholderColor = System.Drawing.Color.Gray;
            this.pusername.PlaceholderText = "Імя користувача";
            this.pusername.Size = new System.Drawing.Size(232, 37);
            this.pusername.TabIndex = 10;
            this.pusername.Texts = "";
            this.pusername.UnderlinedStyle = false;
            // 
            // userRealSurname
            // 
            this.userRealSurname.BackColor = System.Drawing.Color.White;
            this.userRealSurname.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.userRealSurname.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.userRealSurname.BorderRadius = 5;
            this.userRealSurname.BorderSize = 3;
            this.userRealSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userRealSurname.Icon = ((System.Drawing.Image)(resources.GetObject("userRealSurname.Icon")));
            this.userRealSurname.IconSize = new System.Drawing.Size(20, 20);
            this.userRealSurname.Location = new System.Drawing.Point(3, 146);
            this.userRealSurname.Multiline = false;
            this.userRealSurname.Name = "userRealSurname";
            this.userRealSurname.PasswordChar = false;
            this.userRealSurname.PlaceholderColor = System.Drawing.Color.Gray;
            this.userRealSurname.PlaceholderText = "Прізвище";
            this.userRealSurname.Size = new System.Drawing.Size(232, 37);
            this.userRealSurname.TabIndex = 9;
            this.userRealSurname.Texts = "";
            this.userRealSurname.UnderlinedStyle = false;
            // 
            // userRealName
            // 
            this.userRealName.BackColor = System.Drawing.Color.White;
            this.userRealName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.userRealName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.userRealName.BorderRadius = 5;
            this.userRealName.BorderSize = 3;
            this.userRealName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userRealName.Icon = ((System.Drawing.Image)(resources.GetObject("userRealName.Icon")));
            this.userRealName.IconSize = new System.Drawing.Size(20, 20);
            this.userRealName.Location = new System.Drawing.Point(3, 103);
            this.userRealName.Multiline = false;
            this.userRealName.Name = "userRealName";
            this.userRealName.PasswordChar = false;
            this.userRealName.PlaceholderColor = System.Drawing.Color.Gray;
            this.userRealName.PlaceholderText = "Реальне імя";
            this.userRealName.Size = new System.Drawing.Size(232, 37);
            this.userRealName.TabIndex = 9;
            this.userRealName.Texts = "";
            this.userRealName.UnderlinedStyle = false;
            // 
            // userpassword
            // 
            this.userpassword.BackColor = System.Drawing.Color.White;
            this.userpassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.userpassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.userpassword.BorderRadius = 5;
            this.userpassword.BorderSize = 3;
            this.userpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userpassword.Icon = ((System.Drawing.Image)(resources.GetObject("userpassword.Icon")));
            this.userpassword.IconSize = new System.Drawing.Size(20, 20);
            this.userpassword.Location = new System.Drawing.Point(3, 60);
            this.userpassword.Multiline = false;
            this.userpassword.Name = "userpassword";
            this.userpassword.PasswordChar = false;
            this.userpassword.PlaceholderColor = System.Drawing.Color.Gray;
            this.userpassword.PlaceholderText = "Пароль";
            this.userpassword.Size = new System.Drawing.Size(232, 37);
            this.userpassword.TabIndex = 9;
            this.userpassword.Texts = "";
            this.userpassword.UnderlinedStyle = false;
            // 
            // position
            // 
            this.position.BackColor = System.Drawing.Color.White;
            this.position.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.position.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.position.BorderRadius = 5;
            this.position.BorderSize = 3;
            this.position.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.position.Icon = ((System.Drawing.Image)(resources.GetObject("position.Icon")));
            this.position.IconSize = new System.Drawing.Size(20, 20);
            this.position.Location = new System.Drawing.Point(3, 189);
            this.position.Multiline = false;
            this.position.Name = "position";
            this.position.PasswordChar = false;
            this.position.PlaceholderColor = System.Drawing.Color.Gray;
            this.position.PlaceholderText = "Посада";
            this.position.Size = new System.Drawing.Size(232, 37);
            this.position.TabIndex = 9;
            this.position.Texts = "";
            this.position.UnderlinedStyle = false;
            // 
            // ProgramUsers
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.sataPanel2);
            this.Controls.Add(this.sataPanel1);
            this.Name = "ProgramUsers";
            this.Size = new System.Drawing.Size(893, 597);
            this.sataPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.sataPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.SATAPanel sataPanel1;
        private SATAUiFramework.SATAPanel sataPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FrameworkTest.SATAButton sataButton2;
        private SATATextBox pusername;
        private SATATextBox userpassword;
        private FrameworkTest.SATAButton sataButton1;
        private FrameworkTest.SATAButton enterVerify;
        private SATATextBox userRealSurname;
        private SATATextBox userRealName;
        private SATATextBox position;
    }
}
