namespace MTS_service
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Login = new MaterialSkin2DotNet.Controls.MaterialTextBox();
            Password = new MaterialSkin2DotNet.Controls.MaterialTextBox();
            materialRaisedButton1 = new MaterialSkin2DotNet.Controls.MaterialButton();
            ErrorLabel = new Label();
            imageList1 = new ImageList(components);
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Login
            // 
            Login.AnimateReadOnly = false;
            Login.BorderStyle = BorderStyle.None;
            Login.Depth = 0;
            Login.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Login.LeadingIcon = null;
            Login.Location = new Point(14, 100);
            Login.Margin = new Padding(4, 3, 4, 3);
            Login.MaxLength = 50;
            Login.MouseState = MaterialSkin2DotNet.MouseState.OUT;
            Login.Multiline = false;
            Login.Name = "Login";
            Login.Size = new Size(327, 50);
            Login.TabIndex = 0;
            Login.Text = "Введите логин";
            Login.TrailingIcon = null;
            Login.Click += Login_Click;
            // 
            // Password
            // 
            Password.AnimateReadOnly = false;
            Password.BorderStyle = BorderStyle.None;
            Password.Depth = 0;
            Password.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Password.LeadingIcon = null;
            Password.Location = new Point(14, 146);
            Password.Margin = new Padding(4, 3, 4, 3);
            Password.MaxLength = 50;
            Password.MouseState = MaterialSkin2DotNet.MouseState.OUT;
            Password.Multiline = false;
            Password.Name = "Password";
            Password.Password = true;
            Password.Size = new Size(327, 50);
            Password.TabIndex = 1;
            Password.Text = "Введите пароль";
            Password.TrailingIcon = null;
            Password.Click += Password_Click;
            // 
            // materialRaisedButton1
            // 
            materialRaisedButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialRaisedButton1.Density = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialRaisedButton1.Depth = 0;
            materialRaisedButton1.HighEmphasis = true;
            materialRaisedButton1.Icon = null;
            materialRaisedButton1.Location = new Point(146, 202);
            materialRaisedButton1.Margin = new Padding(4, 3, 4, 3);
            materialRaisedButton1.MouseState = MaterialSkin2DotNet.MouseState.HOVER;
            materialRaisedButton1.Name = "materialRaisedButton1";
            materialRaisedButton1.NoAccentTextColor = Color.Empty;
            materialRaisedButton1.Size = new Size(71, 36);
            materialRaisedButton1.TabIndex = 2;
            materialRaisedButton1.Text = "Войти";
            materialRaisedButton1.Type = MaterialSkin2DotNet.Controls.MaterialButton.MaterialButtonType.Contained;
            materialRaisedButton1.UseAccentColor = false;
            materialRaisedButton1.UseVisualStyleBackColor = true;
            materialRaisedButton1.Click += materialRaisedButton1_Click;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            ErrorLabel.Location = new Point(87, 80);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(199, 17);
            ErrorLabel.TabIndex = 3;
            ErrorLabel.Text = "Логин или пароль не верный";
            ErrorLabel.Visible = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "pngwing.com (20).png");
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.pngwing_com__20_;
            pictureBox1.Location = new Point(320, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 244);
            Controls.Add(pictureBox1);
            Controls.Add(ErrorLabel);
            Controls.Add(materialRaisedButton1);
            Controls.Add(Password);
            Controls.Add(Login);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(357, 213);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            FormClosed += LoginForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin2DotNet.Controls.MaterialTextBox Login;
        private MaterialSkin2DotNet.Controls.MaterialTextBox Password;
        private MaterialSkin2DotNet.Controls.MaterialButton materialRaisedButton1;
        private Label ErrorLabel;
        private ImageList imageList1;
        private PictureBox pictureBox1;
    }
}
