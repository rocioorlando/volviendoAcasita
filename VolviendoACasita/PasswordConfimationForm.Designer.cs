namespace VolviendoACasita.UI
{
    partial class PasswordConfimationForm
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
            txtUserPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtOldPass = new TextBox();
            txtConfirmNewPass = new TextBox();
            txtNewPass = new TextBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtUserPass
            // 
            txtUserPass.Location = new Point(200, 49);
            txtUserPass.Name = "txtUserPass";
            txtUserPass.Size = new Size(150, 23);
            txtUserPass.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 93);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Contraseña anterior";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 139);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña nueva";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 190);
            label3.Name = "label3";
            label3.Size = new Size(157, 15);
            label3.TabIndex = 2;
            label3.Text = "Confirmacion de contraseña";
            // 
            // txtOldPass
            // 
            txtOldPass.Location = new Point(200, 93);
            txtOldPass.Name = "txtOldPass";
            txtOldPass.Size = new Size(150, 23);
            txtOldPass.TabIndex = 3;
            // 
            // txtConfirmNewPass
            // 
            txtConfirmNewPass.Location = new Point(200, 190);
            txtConfirmNewPass.Name = "txtConfirmNewPass";
            txtConfirmNewPass.Size = new Size(150, 23);
            txtConfirmNewPass.TabIndex = 4;
            // 
            // txtNewPass
            // 
            txtNewPass.Location = new Point(200, 139);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(150, 23);
            txtNewPass.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUserPass);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtConfirmNewPass);
            groupBox1.Controls.Add(txtNewPass);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtOldPass);
            groupBox1.Location = new Point(54, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 265);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Confirmar contrseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 49);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 6;
            label4.Text = "Usuario";
            // 
            // button1
            // 
            button1.Location = new Point(441, 299);
            button1.Name = "button1";
            button1.Size = new Size(156, 38);
            button1.TabIndex = 7;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PasswordConfimation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 367);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "PasswordConfimation";
            Text = "PasswordConfimation";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtOldPass;
        private TextBox txtConfirmNewPass;
        private TextBox txtNewPass;
        private GroupBox groupBox1;
        private Button button1;
        private Label label4;
        private TextBox txtUserPass;
    }
}