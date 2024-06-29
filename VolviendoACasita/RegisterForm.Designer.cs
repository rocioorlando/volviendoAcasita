namespace VolviendoACasita.UI
{
    partial class RegisterForm
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
            lblNombre = new Label();
            txtName = new TextBox();
            txtlastName = new TextBox();
            lblApellido = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblBirthdate = new Label();
            dtPicker = new DateTimePicker();
            lblProvincia = new Label();
            cmbProvince = new ComboBox();
            cmbLocation = new ComboBox();
            lvlLocalidad = new Label();
            txtbeetwenStreet = new TextBox();
            lblbetweenStreet = new Label();
            txtPostalCode = new TextBox();
            lblPostalCode = new Label();
            txtCity = new TextBox();
            lblCity = new Label();
            txtNumber = new TextBox();
            lblNumero = new Label();
            txtCellPhone = new TextBox();
            lblCellPhone = new Label();
            txtUsername = new TextBox();
            lblUserName = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            applicationDbContextBindingSource = new BindingSource(components);
            txtStreet = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            Ubicacion = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            Ubicacion.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(17, 36);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // txtName
            // 
            txtName.Location = new Point(77, 33);
            txtName.Name = "txtName";
            txtName.Size = new Size(181, 23);
            txtName.TabIndex = 2;
            // 
            // txtlastName
            // 
            txtlastName.Location = new Point(77, 66);
            txtlastName.Name = "txtlastName";
            txtlastName.Size = new Size(181, 23);
            txtlastName.TabIndex = 4;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(17, 69);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido:";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(77, 106);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(181, 23);
            txtDni.TabIndex = 6;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(17, 109);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 5;
            lblDni.Text = "DNI:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(76, 148);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(323, 23);
            txtEmail.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(17, 151);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-Mail:";
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Location = new Point(418, 114);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(106, 15);
            lblBirthdate.TabIndex = 9;
            lblBirthdate.Text = "Fecha Nacimiento:";
            // 
            // dtPicker
            // 
            dtPicker.Location = new Point(543, 109);
            dtPicker.Name = "dtPicker";
            dtPicker.Size = new Size(230, 23);
            dtPicker.TabIndex = 10;
            // 
            // lblProvincia
            // 
            lblProvincia.AutoSize = true;
            lblProvincia.Location = new Point(386, 88);
            lblProvincia.Name = "lblProvincia";
            lblProvincia.Size = new Size(59, 15);
            lblProvincia.TabIndex = 11;
            lblProvincia.Text = "Provincia:";
            // 
            // cmbProvince
            // 
            cmbProvince.FormattingEnabled = true;
            cmbProvince.Location = new Point(476, 85);
            cmbProvince.Name = "cmbProvince";
            cmbProvince.Size = new Size(121, 23);
            cmbProvince.TabIndex = 12;
            // 
            // cmbLocation
            // 
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Location = new Point(476, 133);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(121, 23);
            cmbLocation.TabIndex = 14;
            // 
            // lvlLocalidad
            // 
            lvlLocalidad.AutoSize = true;
            lvlLocalidad.Location = new Point(386, 136);
            lvlLocalidad.Name = "lvlLocalidad";
            lvlLocalidad.Size = new Size(61, 15);
            lvlLocalidad.TabIndex = 13;
            lvlLocalidad.Text = "Localidad:";
            // 
            // txtbeetwenStreet
            // 
            txtbeetwenStreet.Location = new Point(92, 129);
            txtbeetwenStreet.Name = "txtbeetwenStreet";
            txtbeetwenStreet.Size = new Size(246, 23);
            txtbeetwenStreet.TabIndex = 16;
            // 
            // lblbetweenStreet
            // 
            lblbetweenStreet.AutoSize = true;
            lblbetweenStreet.Location = new Point(15, 132);
            lblbetweenStreet.Name = "lblbetweenStreet";
            lblbetweenStreet.Size = new Size(71, 15);
            lblbetweenStreet.TabIndex = 15;
            lblbetweenStreet.Text = "Entre Calles:";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(107, 174);
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(231, 23);
            txtPostalCode.TabIndex = 18;
            // 
            // lblPostalCode
            // 
            lblPostalCode.AutoSize = true;
            lblPostalCode.Location = new Point(17, 177);
            lblPostalCode.Name = "lblPostalCode";
            lblPostalCode.Size = new Size(84, 15);
            lblPostalCode.TabIndex = 17;
            lblPostalCode.Text = "Codigo Postal:";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(476, 37);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(121, 23);
            txtCity.TabIndex = 20;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(386, 37);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(48, 15);
            lblCity.TabIndex = 19;
            lblCity.Text = "Ciudad:";
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(92, 78);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(246, 23);
            txtNumber.TabIndex = 22;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(15, 81);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(54, 15);
            lblNumero.TabIndex = 21;
            lblNumero.Text = "Número:";
            // 
            // txtCellPhone
            // 
            txtCellPhone.Location = new Point(495, 63);
            txtCellPhone.Name = "txtCellPhone";
            txtCellPhone.Size = new Size(166, 23);
            txtCellPhone.TabIndex = 26;
            // 
            // lblCellPhone
            // 
            lblCellPhone.AutoSize = true;
            lblCellPhone.Location = new Point(418, 66);
            lblCellPhone.Name = "lblCellPhone";
            lblCellPhone.Size = new Size(73, 15);
            lblCellPhone.TabIndex = 25;
            lblCellPhone.Text = "Nro. Celular:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(495, 25);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(166, 23);
            txtUsername.TabIndex = 28;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(418, 33);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(50, 15);
            lblUserName.TabIndex = 27;
            lblUserName.Text = "Usuario:";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(884, 406);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 29;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(782, 406);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 30;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // applicationDbContextBindingSource
            // 
            applicationDbContextBindingSource.DataSource = typeof(DataAccess.Data.ApplicationDbContext);
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(92, 34);
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(246, 23);
            txtStreet.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 42);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 31;
            label1.Text = "Calle";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Controls.Add(txtlastName);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtCellPhone);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(lblCellPhone);
            groupBox1.Controls.Add(lblUserName);
            groupBox1.Controls.Add(lblBirthdate);
            groupBox1.Controls.Add(dtPicker);
            groupBox1.Controls.Add(lblDni);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(969, 182);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de usuario";
            // 
            // Ubicacion
            // 
            Ubicacion.Controls.Add(cmbLocation);
            Ubicacion.Controls.Add(lvlLocalidad);
            Ubicacion.Controls.Add(txtStreet);
            Ubicacion.Controls.Add(lblPostalCode);
            Ubicacion.Controls.Add(txtCity);
            Ubicacion.Controls.Add(label1);
            Ubicacion.Controls.Add(lblCity);
            Ubicacion.Controls.Add(lblNumero);
            Ubicacion.Controls.Add(txtPostalCode);
            Ubicacion.Controls.Add(txtNumber);
            Ubicacion.Controls.Add(lblProvincia);
            Ubicacion.Controls.Add(cmbProvince);
            Ubicacion.Controls.Add(txtbeetwenStreet);
            Ubicacion.Controls.Add(lblbetweenStreet);
            Ubicacion.Location = new Point(12, 214);
            Ubicacion.Name = "Ubicacion";
            Ubicacion.Size = new Size(752, 215);
            Ubicacion.TabIndex = 34;
            Ubicacion.TabStop = false;
            Ubicacion.Text = "Ubicacion";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 465);
            Controls.Add(Ubicacion);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Name = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)applicationDbContextBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Ubicacion.ResumeLayout(false);
            Ubicacion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblNombre;
        private TextBox txtName;
        private TextBox txtlastName;
        private Label lblApellido;
        private TextBox txtDni;
        private Label lblDni;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblBirthdate;
        private DateTimePicker dtPicker;
        private Label lblProvincia;
        private ComboBox cmbProvince;
        private ComboBox cmbLocation;
        private Label lvlLocalidad;
        private TextBox txtbeetwenStreet;
        private Label lblbetweenStreet;
        private TextBox txtPostalCode;
        private Label lblPostalCode;
        private TextBox txtCity;
        private Label lblCity;
        private TextBox txtNumber;
        private Label lblNumero;
        private TextBox txtCellPhone;
        private Label lblCellPhone;
        private TextBox txtUsername;
        private Label lblUserName;
        private Button btnConfirm;
        private Button btnCancel;
        private BindingSource applicationDbContextBindingSource;
        private TextBox txtStreet;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox Ubicacion;
    }
}