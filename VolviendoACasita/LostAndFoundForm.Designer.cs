namespace VolviendoACasita.UI
{
    partial class LostAndFoundForm
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
            lblContactPhone = new Label();
            txtContactPhone = new TextBox();
            lblbetweenStreet = new Label();
            cmbLocation = new ComboBox();
            lvlLocalidad = new Label();
            cmbProvince = new ComboBox();
            lblProvincia = new Label();
            dtPicker = new DateTimePicker();
            lblBirthdate = new Label();
            grpDatosLugar = new GroupBox();
            checkIsOwner = new CheckBox();
            groupBox1 = new GroupBox();
            lblPostalCode = new Label();
            txtPostalCode = new TextBox();
            txtStreet = new TextBox();
            label2 = new Label();
            lblNumero = new Label();
            txtNumber = new TextBox();
            txtbeetwenStreet = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            applicationDbContextBindingSource = new BindingSource(components);
            lblLost = new Label();
            lblFound = new Label();
            comboPet = new ComboBox();
            label1 = new Label();
            lblObservacion = new Label();
            txtObservation = new TextBox();
            btnShowPet = new Button();
            groupBox2 = new GroupBox();
            grpDatosLugar.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblContactPhone
            // 
            lblContactPhone.AutoSize = true;
            lblContactPhone.Location = new Point(6, 33);
            lblContactPhone.Name = "lblContactPhone";
            lblContactPhone.Size = new Size(107, 15);
            lblContactPhone.TabIndex = 5;
            lblContactPhone.Text = "Telefono Contacto:";
            // 
            // txtContactPhone
            // 
            txtContactPhone.Location = new Point(119, 30);
            txtContactPhone.Name = "txtContactPhone";
            txtContactPhone.Size = new Size(126, 23);
            txtContactPhone.TabIndex = 4;
            // 
            // lblbetweenStreet
            // 
            lblbetweenStreet.AutoSize = true;
            lblbetweenStreet.Location = new Point(442, 60);
            lblbetweenStreet.Name = "lblbetweenStreet";
            lblbetweenStreet.Size = new Size(71, 15);
            lblbetweenStreet.TabIndex = 27;
            lblbetweenStreet.Text = "Entre Calles:";
            // 
            // cmbLocation
            // 
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(298, 22);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(98, 23);
            cmbLocation.TabIndex = 26;
            // 
            // lvlLocalidad
            // 
            lvlLocalidad.AutoSize = true;
            lvlLocalidad.Location = new Point(222, 25);
            lvlLocalidad.Name = "lvlLocalidad";
            lvlLocalidad.Size = new Size(61, 15);
            lvlLocalidad.TabIndex = 25;
            lvlLocalidad.Text = "Localidad:";
            // 
            // cmbProvince
            // 
            cmbProvince.FormattingEnabled = true;
            cmbProvince.Location = new Point(77, 57);
            cmbProvince.Name = "cmbProvince";
            cmbProvince.Size = new Size(116, 23);
            cmbProvince.TabIndex = 24;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(6, 60);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(59, 15);
            lblProvincia.TabIndex = 23;
            lblProvincia.Text = "Provincia:";
            // 
            // dtPicker
            // 
            dtPicker.Location = new Point(298, 30);
            dtPicker.Name = "dtPicker";
            dtPicker.Size = new Size(217, 23);
            dtPicker.TabIndex = 36;
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Location = new Point(251, 33);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(41, 15);
            lblBirthdate.TabIndex = 35;
            lblBirthdate.Text = "Fecha:";
            // 
            // grpDatosLugar
            // 
            grpDatosLugar.Controls.Add(checkIsOwner);
            grpDatosLugar.Controls.Add(dtPicker);
            grpDatosLugar.Controls.Add(lblBirthdate);
            grpDatosLugar.Controls.Add(txtContactPhone);
            grpDatosLugar.Controls.Add(lblContactPhone);
            grpDatosLugar.Location = new Point(44, 80);
            grpDatosLugar.Name = "grpDatosLugar";
            grpDatosLugar.Size = new Size(674, 68);
            grpDatosLugar.TabIndex = 37;
            grpDatosLugar.TabStop = false;
            grpDatosLugar.Text = "Datos generales";
            // 
            // checkIsOwner
            // 
            checkIsOwner.AutoSize = true;
            checkIsOwner.CheckAlign = ContentAlignment.MiddleRight;
            checkIsOwner.Location = new Point(563, 32);
            checkIsOwner.Name = "checkIsOwner";
            checkIsOwner.Size = new Size(84, 19);
            checkIsOwner.TabIndex = 37;
            checkIsOwner.Text = "¿Es dueño?";
            checkIsOwner.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPostalCode);
            groupBox1.Controls.Add(txtPostalCode);
            groupBox1.Controls.Add(txtStreet);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblNumero);
            groupBox1.Controls.Add(txtNumber);
            groupBox1.Controls.Add(lblProvincia);
            groupBox1.Controls.Add(cmbProvince);
            groupBox1.Controls.Add(lvlLocalidad);
            groupBox1.Controls.Add(cmbLocation);
            groupBox1.Controls.Add(lblbetweenStreet);
            groupBox1.Controls.Add(txtbeetwenStreet);
            groupBox1.Location = new Point(44, 154);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(674, 96);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Lugar";
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(199, 63);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(84, 15);
            lblPostalCode.TabIndex = 37;
            lblPostalCode.Text = "Codigo Postal:";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(298, 57);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(130, 23);
            txtPostalCode.TabIndex = 38;
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(60, 22);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(142, 23);
            txtStreet.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 25);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 35;
            label2.Text = "Calle";
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(442, 22);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(54, 15);
            lblNumero.TabIndex = 33;
            lblNumero.Text = "Número:";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(519, 19);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(142, 23);
            txtNumber.TabIndex = 34;
            // 
            // txtbeetwenStreet
            // 
            txtbeetwenStreet.Location = new Point(519, 57);
            txtbeetwenStreet.Name = "txtbeetwenStreet";
            txtbeetwenStreet.Size = new Size(145, 23);
            txtbeetwenStreet.TabIndex = 28;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(643, 392);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 40;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(528, 392);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 41;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // applicationDbContextBindingSource
            // 
            applicationDbContextBindingSource.DataSource = typeof(DataAccess.Data.ApplicationDbContext);
            // 
            // lblLost
            // 
            lblLost.AutoSize = true;
            lblLost.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLost.Location = new Point(50, 23);
            lblLost.Name = "lblLost";
            lblLost.Size = new Size(381, 37);
            lblLost.TabIndex = 42;
            lblLost.Text = "Formulario Mascota Perdida";
            lblLost.Visible = false;
            // 
            // lblFound
            // 
            lblFound.AutoSize = true;
            lblFound.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblFound.Location = new Point(50, 23);
            lblFound.Name = "lblFound";
            lblFound.Size = new Size(427, 37);
            lblFound.TabIndex = 43;
            lblFound.Text = "Formulario Mascota Encontrada";
            lblFound.UseWaitCursor = true;
            lblFound.Visible = false;
            // 
            // comboPet
            // 
            comboPet.FormattingEnabled = true;
            comboPet.Location = new Point(156, 26);
            comboPet.Name = "comboPet";
            comboPet.Size = new Size(181, 23);
            comboPet.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 26);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 47;
            label1.Text = "Seleccione la mascota";
            // 
            // lblObservacion
            // 
            lblObservacion.AutoSize = true;
            lblObservacion.Location = new Point(6, 64);
            lblObservacion.Name = "lblObservacion";
            lblObservacion.Size = new Size(76, 15);
            lblObservacion.TabIndex = 45;
            lblObservacion.Text = "Observacion:";
            // 
            // txtObservation
            // 
            txtObservation.Location = new Point(83, 61);
            txtObservation.Multiline = true;
            txtObservation.Name = "txtObservation";
            txtObservation.Size = new Size(564, 57);
            txtObservation.TabIndex = 46;
            // 
            // btnShowPet
            // 
            btnShowPet.Location = new Point(362, 23);
            btnShowPet.Name = "btnShowPet";
            btnShowPet.Size = new Size(284, 23);
            btnShowPet.TabIndex = 44;
            btnShowPet.Text = "Cargar datos de la mascota";
            btnShowPet.UseVisualStyleBackColor = true;
            btnShowPet.Click += btnShowPet_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboPet);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnShowPet);
            groupBox2.Controls.Add(lblObservacion);
            groupBox2.Controls.Add(txtObservation);
            groupBox2.Location = new Point(44, 256);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(674, 134);
            groupBox2.TabIndex = 49;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos de la mascota";
            // 
            // LostAndFoundForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 449);
            Controls.Add(groupBox2);
            Controls.Add(lblFound);
            Controls.Add(lblLost);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(grpDatosLugar);
            Name = "LostAndFoundForm";
            Text = "LostAndFoundForm";
            grpDatosLugar.ResumeLayout(false);
            grpDatosLugar.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblContactPhone;
        private TextBox txtContactPhone;
        private Label lblbetweenStreet;
        private ComboBox cmbLocation;
        private Label lvlLocalidad;
        private ComboBox cmbProvince;
        private Label lblProvincia;
        private DateTimePicker dtPicker;
        private Label lblBirthdate;
        private GroupBox grpDatosLugar;
        private GroupBox groupBox1;
        private Button btnSave;
        private Button btnCancel;
        private BindingSource applicationDbContextBindingSource;
        private CheckBox checkIsOwner;
        private Label lblLost;
        private Label lblFound;
        private Button btnShowPet;
        private Label lblObservacion;
        private TextBox txtObservation;
        private ComboBox comboPet;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox txtStreet;
        private Label label2;
        private Label lblNumero;
        private TextBox txtNumber;
        private TextBox txtbeetwenStreet;
        private Label lblPostalCode;
        private TextBox txtPostalCode;
    }
}