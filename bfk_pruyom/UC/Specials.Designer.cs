
namespace bfk_pruyom.UC
{
    partial class Specials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Specials));
            this.sataPanel1 = new SATAUiFramework.SATAPanel();
            this.sataButton2 = new FrameworkTest.SATAButton();
            this.sataButton1 = new FrameworkTest.SATAButton();
            this.enterVerify = new FrameworkTest.SATAButton();
            this.nameSpec = new SATATextBox();
            this.codeSpec = new SATATextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sataPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.sataPanel1.Controls.Add(this.sataButton2);
            this.sataPanel1.Controls.Add(this.sataButton1);
            this.sataPanel1.Controls.Add(this.enterVerify);
            this.sataPanel1.Controls.Add(this.nameSpec);
            this.sataPanel1.Controls.Add(this.codeSpec);
            this.sataPanel1.Controls.Add(this.dataGridView1);
            this.sataPanel1.Location = new System.Drawing.Point(151, 98);
            this.sataPanel1.Name = "sataPanel1";
            this.sataPanel1.Size = new System.Drawing.Size(591, 400);
            this.sataPanel1.TabIndex = 0;
            // 
            // sataButton2
            // 
            this.sataButton2.ButtonText = "Додати спеціальність";
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
            this.sataButton2.Location = new System.Drawing.Point(347, 192);
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
            this.sataButton2.Size = new System.Drawing.Size(240, 40);
            this.sataButton2.TabIndex = 8;
            this.sataButton2.TextAutoCenter = false;
            this.sataButton2.TextOffset = new System.Drawing.Point(5, 0);
            this.sataButton2.Click += new System.EventHandler(this.sataButton2_Click);
            // 
            // sataButton1
            // 
            this.sataButton1.ButtonText = "Видалити спеціальність";
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
            this.sataButton1.Location = new System.Drawing.Point(346, 284);
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
            this.sataButton1.Size = new System.Drawing.Size(240, 40);
            this.sataButton1.TabIndex = 9;
            this.sataButton1.TextAutoCenter = false;
            this.sataButton1.TextOffset = new System.Drawing.Point(5, 0);
            this.sataButton1.Click += new System.EventHandler(this.sataButton1_Click);
            // 
            // enterVerify
            // 
            this.enterVerify.ButtonText = "Редагувати спеціальність";
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
            this.enterVerify.Location = new System.Drawing.Point(346, 238);
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
            this.enterVerify.Size = new System.Drawing.Size(240, 40);
            this.enterVerify.TabIndex = 10;
            this.enterVerify.TextAutoCenter = false;
            this.enterVerify.TextOffset = new System.Drawing.Point(5, 0);
            this.enterVerify.Click += new System.EventHandler(this.enterVerify_Click);
            // 
            // nameSpec
            // 
            this.nameSpec.BackColor = System.Drawing.Color.White;
            this.nameSpec.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.nameSpec.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.nameSpec.BorderRadius = 5;
            this.nameSpec.BorderSize = 3;
            this.nameSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.nameSpec.Icon = ((System.Drawing.Image)(resources.GetObject("nameSpec.Icon")));
            this.nameSpec.IconSize = new System.Drawing.Size(20, 20);
            this.nameSpec.Location = new System.Drawing.Point(346, 116);
            this.nameSpec.Multiline = false;
            this.nameSpec.Name = "nameSpec";
            this.nameSpec.PasswordChar = false;
            this.nameSpec.PlaceholderColor = System.Drawing.Color.Gray;
            this.nameSpec.PlaceholderText = "Назва спеціальності";
            this.nameSpec.Size = new System.Drawing.Size(240, 37);
            this.nameSpec.TabIndex = 4;
            this.nameSpec.Texts = "";
            this.nameSpec.UnderlinedStyle = false;
            // 
            // codeSpec
            // 
            this.codeSpec.BackColor = System.Drawing.Color.White;
            this.codeSpec.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(79)))), ((int)(((byte)(165)))));
            this.codeSpec.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(68)))), ((int)(((byte)(142)))));
            this.codeSpec.BorderRadius = 5;
            this.codeSpec.BorderSize = 3;
            this.codeSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.codeSpec.Icon = ((System.Drawing.Image)(resources.GetObject("codeSpec.Icon")));
            this.codeSpec.IconSize = new System.Drawing.Size(20, 20);
            this.codeSpec.Location = new System.Drawing.Point(346, 73);
            this.codeSpec.Multiline = false;
            this.codeSpec.Name = "codeSpec";
            this.codeSpec.PasswordChar = false;
            this.codeSpec.PlaceholderColor = System.Drawing.Color.Gray;
            this.codeSpec.PlaceholderText = "Код спеціальності";
            this.codeSpec.Size = new System.Drawing.Size(240, 37);
            this.codeSpec.TabIndex = 4;
            this.codeSpec.Texts = "";
            this.codeSpec.UnderlinedStyle = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(340, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 597);
            this.panel1.TabIndex = 1;
            // 
            // Specials
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.sataPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Specials";
            this.Size = new System.Drawing.Size(893, 597);
            this.sataPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SATAUiFramework.SATAPanel sataPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private SATATextBox nameSpec;
        private SATATextBox codeSpec;
        private FrameworkTest.SATAButton sataButton2;
        private FrameworkTest.SATAButton sataButton1;
        private FrameworkTest.SATAButton enterVerify;
    }
}
