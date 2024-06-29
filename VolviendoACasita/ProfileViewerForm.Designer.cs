namespace VolviendoACasita.UI
{
    partial class ProfileViewerForm
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
            btnVolver = new Button();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(872, 666);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(258, 48);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver a la home";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // ProfileViewerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 865);
            Controls.Add(btnVolver);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ProfileViewerForm";
            Text = "ProfileViewerForm";
            Load += ProfileViewerForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnVolver;
    }
}
