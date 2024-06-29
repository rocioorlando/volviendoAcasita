namespace VolviendoACasita.UI
{
    partial class HomeForm
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
            RegisterButton = new Button();
            LoginButton = new Button();
            label1 = new Label();
            label2 = new Label();
            btnLostForm = new Button();
            btnFoundForm = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(1038, 12);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(154, 57);
            RegisterButton.TabIndex = 0;
            RegisterButton.Text = "Registrarse";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += ShowRegister;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(1211, 12);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(154, 57);
            LoginButton.TabIndex = 1;
            LoginButton.Text = "Iniciar Sesion";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += ShowLogin;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 452);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 15);
            label1.TabIndex = 2;
            label1.Text = "¿No sabes dónde está tu mascota? ¡Déjanos ayudarte a buscarla!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 483);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(385, 15);
            label2.TabIndex = 3;
            label2.Text = "¿Encontraste una mascota? ¡Podemos ayudarte a encontrar a su dueño! ";
            // 
            // btnLostForm
            // 
            btnLostForm.Location = new Point(429, 449);
            btnLostForm.Margin = new Padding(2);
            btnLostForm.Name = "btnLostForm";
            btnLostForm.Size = new Size(122, 20);
            btnLostForm.TabIndex = 4;
            btnLostForm.Tag = "1";
            btnLostForm.Text = "Iniciar búsqueda";
            btnLostForm.UseVisualStyleBackColor = true;
            btnLostForm.Click += btnLostForm_Click;
            // 
            // btnFoundForm
            // 
            btnFoundForm.Location = new Point(429, 480);
            btnFoundForm.Margin = new Padding(2);
            btnFoundForm.Name = "btnFoundForm";
            btnFoundForm.Size = new Size(122, 20);
            btnFoundForm.TabIndex = 5;
            btnFoundForm.Tag = "2";
            btnFoundForm.Text = "Iniciar búsqueda";
            btnFoundForm.UseVisualStyleBackColor = true;
            btnFoundForm.Click += btnFoundForm_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(8, 89);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1327, 331);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 530);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(btnFoundForm);
            Controls.Add(btnLostForm);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            Controls.Add(RegisterButton);
            Name = "HomeForm";
            Text = "HomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegisterButton;
        private Button LoginButton;
        private Label label1;
        private Label label2;
        private Button btnLostForm;
        private Button btnFoundForm;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}