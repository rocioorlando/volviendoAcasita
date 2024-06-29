namespace VolviendoACasita.UI
{
    partial class PetRegisterForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtAge = new TextBox();
            label3 = new Label();
            txtWeight = new TextBox();
            txtColor = new TextBox();
            label4 = new Label();
            checkCastrated = new CheckBox();
            checkIsOnMedication = new CheckBox();
            txtRespondsTo = new TextBox();
            label5 = new Label();
            checkIsVaccinated = new CheckBox();
            txtMedicationNotes = new TextBox();
            label6 = new Label();
            checkIsOwner = new CheckBox();
            checkHasVifVilef = new CheckBox();
            checkHasTag = new CheckBox();
            cmbBreed = new ComboBox();
            lblBreed = new Label();
            cmbSpecies = new ComboBox();
            lblSpecies = new Label();
            btnCancel = new Button();
            btnCorfirm = new Button();
            txtUrl = new TextBox();
            label7 = new Label();
            cmbSize = new ComboBox();
            applicationDbContextBindingSource = new BindingSource(components);
            label8 = new Label();
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 53);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Location = new Point(111, 53);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(141, 31);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 127);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 2;
            label2.Text = "Edad";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(111, 122);
            txtAge.Margin = new Padding(4, 5, 4, 5);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(141, 31);
            txtAge.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(666, 67);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(49, 25);
            label3.TabIndex = 4;
            label3.Text = "Peso";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(763, 62);
            txtWeight.Margin = new Padding(4, 5, 4, 5);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(141, 31);
            txtWeight.TabIndex = 5;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(111, 195);
            txtColor.Margin = new Padding(4, 5, 4, 5);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(141, 31);
            txtColor.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 195);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 6;
            label4.Text = "Color";
            // 
            // checkCastrated
            // 
            checkCastrated.AutoSize = true;
            checkCastrated.Location = new Point(320, 53);
            checkCastrated.Margin = new Padding(4, 5, 4, 5);
            checkCastrated.Name = "checkCastrated";
            checkCastrated.Size = new Size(151, 29);
            checkCastrated.TabIndex = 8;
            checkCastrated.Text = "Esta castrado?";
            checkCastrated.UseVisualStyleBackColor = true;
            // 
            // checkIsOnMedication
            // 
            checkIsOnMedication.AutoSize = true;
            checkIsOnMedication.Location = new Point(320, 120);
            checkIsOnMedication.Margin = new Padding(4, 5, 4, 5);
            checkIsOnMedication.Name = "checkIsOnMedication";
            checkIsOnMedication.Size = new Size(207, 29);
            checkIsOnMedication.TabIndex = 9;
            checkIsOnMedication.Text = "Necesita medicacion?";
            checkIsOnMedication.UseVisualStyleBackColor = true;
            // 
            // txtRespondsTo
            // 
            txtRespondsTo.Location = new Point(913, 232);
            txtRespondsTo.Margin = new Padding(4, 5, 4, 5);
            txtRespondsTo.Multiline = true;
            txtRespondsTo.Name = "txtRespondsTo";
            txtRespondsTo.Size = new Size(270, 36);
            txtRespondsTo.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(666, 232);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(211, 25);
            label5.TabIndex = 10;
            label5.Text = "Responde al nombre de: ";
            // 
            // checkIsVaccinated
            // 
            checkIsVaccinated.AutoSize = true;
            checkIsVaccinated.Location = new Point(320, 188);
            checkIsVaccinated.Margin = new Padding(4, 5, 4, 5);
            checkIsVaccinated.Name = "checkIsVaccinated";
            checkIsVaccinated.Size = new Size(160, 29);
            checkIsVaccinated.TabIndex = 12;
            checkIsVaccinated.Text = "Esta vacunado?";
            checkIsVaccinated.UseVisualStyleBackColor = true;
            // 
            // txtMedicationNotes
            // 
            txtMedicationNotes.Location = new Point(19, 100);
            txtMedicationNotes.Margin = new Padding(4, 5, 4, 5);
            txtMedicationNotes.Multiline = true;
            txtMedicationNotes.Name = "txtMedicationNotes";
            txtMedicationNotes.Size = new Size(561, 142);
            txtMedicationNotes.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 52);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(169, 25);
            label6.TabIndex = 13;
            label6.Text = "Detalles medicacion";
            // 
            // checkIsOwner
            // 
            checkIsOwner.AutoSize = true;
            checkIsOwner.Location = new Point(70, 190);
            checkIsOwner.Margin = new Padding(4, 5, 4, 5);
            checkIsOwner.Name = "checkIsOwner";
            checkIsOwner.Size = new Size(149, 29);
            checkIsOwner.TabIndex = 15;
            checkIsOwner.Text = "Sos el dueño?";
            checkIsOwner.UseVisualStyleBackColor = true;
            // 
            // checkHasVifVilef
            // 
            checkHasVifVilef.AutoSize = true;
            checkHasVifVilef.Location = new Point(71, 120);
            checkHasVifVilef.Margin = new Padding(4, 5, 4, 5);
            checkHasVifVilef.Name = "checkHasVifVilef";
            checkHasVifVilef.Size = new Size(151, 29);
            checkHasVifVilef.TabIndex = 16;
            checkHasVifVilef.Text = "Es VIF/VILEF +";
            checkHasVifVilef.UseVisualStyleBackColor = true;
            // 
            // checkHasTag
            // 
            checkHasTag.AutoSize = true;
            checkHasTag.Location = new Point(70, 52);
            checkHasTag.Margin = new Padding(4, 5, 4, 5);
            checkHasTag.Name = "checkHasTag";
            checkHasTag.Size = new Size(149, 29);
            checkHasTag.TabIndex = 17;
            checkHasTag.Text = "Tiene chapita?";
            checkHasTag.UseVisualStyleBackColor = true;
            // 
            // cmbBreed
            // 
            cmbBreed.FormattingEnabled = true;
            cmbBreed.Location = new Point(429, 213);
            cmbBreed.Margin = new Padding(4, 5, 4, 5);
            cmbBreed.Name = "cmbBreed";
            cmbBreed.Size = new Size(171, 33);
            cmbBreed.TabIndex = 20;
            // 
            // lblBreed
            // 
            lblBreed.AutoSize = true;
            lblBreed.Location = new Point(303, 208);
            lblBreed.Margin = new Padding(4, 0, 4, 0);
            lblBreed.Name = "lblBreed";
            lblBreed.Size = new Size(49, 25);
            lblBreed.TabIndex = 19;
            lblBreed.Text = "Raza";
            // 
            // cmbSpecies
            // 
            cmbSpecies.FormattingEnabled = true;
            cmbSpecies.Location = new Point(429, 130);
            cmbSpecies.Margin = new Padding(4, 5, 4, 5);
            cmbSpecies.Name = "cmbSpecies";
            cmbSpecies.Size = new Size(171, 33);
            cmbSpecies.TabIndex = 22;
            cmbSpecies.SelectedIndexChanged += cmbSpecies_SelectedIndexChanged;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(303, 135);
            lblSpecies.Margin = new Padding(4, 0, 4, 0);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(70, 25);
            lblSpecies.TabIndex = 21;
            lblSpecies.Text = "Especie";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1031, 708);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 38);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnCorfirm
            // 
            btnCorfirm.Location = new Point(1199, 708);
            btnCorfirm.Margin = new Padding(4, 5, 4, 5);
            btnCorfirm.Name = "btnCorfirm";
            btnCorfirm.Size = new Size(107, 38);
            btnCorfirm.TabIndex = 24;
            btnCorfirm.Text = "Confirmar";
            btnCorfirm.UseVisualStyleBackColor = true;
            btnCorfirm.Click += btnCorfirm_Click;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(791, 148);
            txtUrl.Margin = new Padding(4, 5, 4, 5);
            txtUrl.MaxLength = 327670;
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(391, 31);
            txtUrl.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(666, 148);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(107, 25);
            label7.TabIndex = 25;
            label7.Text = "URL imagen";
            // 
            // cmbSize
            // 
            cmbSize.FormattingEnabled = true;
            cmbSize.Location = new Point(429, 53);
            cmbSize.Margin = new Padding(4, 5, 4, 5);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(171, 33);
            cmbSize.TabIndex = 27;
            // 
            // applicationDbContextBindingSource
            // 
            applicationDbContextBindingSource.DataSource = typeof(DataAccess.Data.ApplicationDbContext);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(303, 62);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(74, 25);
            label8.TabIndex = 28;
            label8.Text = "Tamaño";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(cmbSize);
            groupBox1.Controls.Add(lblBreed);
            groupBox1.Controls.Add(cmbBreed);
            groupBox1.Controls.Add(txtUrl);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(lblSpecies);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtAge);
            groupBox1.Controls.Add(cmbSpecies);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtRespondsTo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtWeight);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtColor);
            groupBox1.Location = new Point(17, 20);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(1290, 308);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la mascota";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkHasTag);
            groupBox3.Controls.Add(checkIsOwner);
            groupBox3.Controls.Add(checkHasVifVilef);
            groupBox3.Controls.Add(checkIsOnMedication);
            groupBox3.Controls.Add(checkCastrated);
            groupBox3.Controls.Add(checkIsVaccinated);
            groupBox3.Location = new Point(17, 372);
            groupBox3.Margin = new Padding(4, 5, 4, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 5, 4, 5);
            groupBox3.Size = new Size(660, 273);
            groupBox3.TabIndex = 30;
            groupBox3.TabStop = false;
            groupBox3.Text = "Datos generales";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtMedicationNotes);
            groupBox2.Location = new Point(700, 372);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(607, 273);
            groupBox2.TabIndex = 31;
            groupBox2.TabStop = false;
            groupBox2.Text = "Observaciones";
            // 
            // PetRegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1363, 790);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(btnCorfirm);
            Controls.Add(btnCancel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PetRegisterForm";
            Text = "PetRegistraterForm";
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtAge;
        private Label label3;
        private TextBox txtWeight;
        private TextBox txtColor;
        private Label label4;
        private CheckBox checkCastrated;
        private CheckBox checkIsOnMedication;
        private TextBox txtRespondsTo;
        private Label label5;
        private CheckBox checkIsVaccinated;
        private TextBox txtMedicationNotes;
        private Label label6;
        private CheckBox checkIsOwner;
        private CheckBox checkHasVifVilef;
        private CheckBox checkHasTag;
        private ComboBox cmbBreed;
        private Label lblBreed;
        private ComboBox cmbSpecies;
        private Label lblSpecies;
        private Button btnCancel;
        private Button btnCorfirm;
        private TextBox txtUrl;
        private Label label7;
        private ComboBox cmbSize;
        private BindingSource applicationDbContextBindingSource;
        private Label label8;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
    }
}