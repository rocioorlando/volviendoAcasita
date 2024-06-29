namespace VolviendoACasita
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsuario = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            lblContrasenia = new Label();
            btnIngresar = new Button();
            lnkLblRegistro = new LinkLabel();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(251, 207);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUserName
            // 
            txtUserName.ForeColor = Color.Violet;
            txtUserName.Location = new Point(334, 204);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(245, 23);
            txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(334, 233);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(245, 23);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblContrasenia
            // 
            lblContrasenia.AutoSize = true;
            lblContrasenia.Location = new Point(251, 236);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(70, 15);
            lblContrasenia.TabIndex = 2;
            lblContrasenia.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(501, 274);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(78, 23);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += Login_Click;
            // 
            // lnkLblRegistro
            // 
            lnkLblRegistro.AutoSize = true;
            lnkLblRegistro.Location = new Point(251, 278);
            lnkLblRegistro.Name = "lnkLblRegistro";
            lnkLblRegistro.Size = new Size(209, 15);
            lnkLblRegistro.TabIndex = 5;
            lnkLblRegistro.TabStop = true;
            lnkLblRegistro.Text = "¿No estas Registrado?, Registrese aqui.";
            lnkLblRegistro.LinkClicked += lnkLblRegistro_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 576);
            Controls.Add(lnkLblRegistro);
            Controls.Add(btnIngresar);
            Controls.Add(txtPassword);
            Controls.Add(lblContrasenia);
            Controls.Add(txtUserName);
            Controls.Add(lblUsuario);
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Label lblContrasenia;
        private Button btnIngresar;
        private LinkLabel lnkLblRegistro;
    }
}
