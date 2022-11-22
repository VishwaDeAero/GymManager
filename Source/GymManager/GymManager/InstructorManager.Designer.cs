namespace GymManager
{
    partial class InstructorManager
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
            this.components = new System.ComponentModel.Container();
            this.errorProviderMember = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvInstructor = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtInstructorId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.txtDOB = new System.Windows.Forms.DateTimePicker();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.btnInsertInstructor = new System.Windows.Forms.Button();
            this.btnUpdateInstructor = new System.Windows.Forms.Button();
            this.btnDeleteInstructor = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.genderGrp = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblShiftId = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInstructorCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInstructorName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInsertShift = new System.Windows.Forms.Button();
            this.btnDeleteShift = new System.Windows.Forms.Button();
            this.btnUpdateShift = new System.Windows.Forms.Button();
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructor)).BeginInit();
            this.genderGrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderMember
            // 
            this.errorProviderMember.ContainerControl = this;
            // 
            // dgvInstructor
            // 
            this.dgvInstructor.AllowUserToAddRows = false;
            this.dgvInstructor.AllowUserToDeleteRows = false;
            this.dgvInstructor.AllowUserToResizeColumns = false;
            this.dgvInstructor.AllowUserToResizeRows = false;
            this.dgvInstructor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstructor.BackgroundColor = System.Drawing.Color.White;
            this.dgvInstructor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstructor.Location = new System.Drawing.Point(10, 305);
            this.dgvInstructor.Name = "dgvInstructor";
            this.dgvInstructor.ReadOnly = true;
            this.dgvInstructor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstructor.Size = new System.Drawing.Size(776, 205);
            this.dgvInstructor.TabIndex = 25;
            this.dgvInstructor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstructor_CellClick);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(152, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 27);
            this.txtName.TabIndex = 9;
            // 
            // txtInstructorId
            // 
            this.txtInstructorId.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstructorId.Location = new System.Drawing.Point(152, 39);
            this.txtInstructorId.Name = "txtInstructorId";
            this.txtInstructorId.Size = new System.Drawing.Size(208, 27);
            this.txtInstructorId.TabIndex = 8;
            this.txtInstructorId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInstructorId_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(387, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 22);
            this.label8.TabIndex = 5;
            this.label8.Text = "Mobile Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(387, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 22);
            this.label9.TabIndex = 4;
            this.label9.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Gender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date of Birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Instructor ID";
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMale.Location = new System.Drawing.Point(3, -4);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(68, 26);
            this.rdbMale.TabIndex = 11;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Male";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // txtDOB
            // 
            this.txtDOB.CalendarFont = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDOB.CustomFormat = "yyyy-MM-dd";
            this.txtDOB.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDOB.Location = new System.Drawing.Point(152, 112);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(208, 27);
            this.txtDOB.TabIndex = 10;
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbFemale.Location = new System.Drawing.Point(110, -4);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(90, 26);
            this.rdbFemale.TabIndex = 12;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // btnInsertInstructor
            // 
            this.btnInsertInstructor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertInstructor.BackColor = System.Drawing.Color.LightGreen;
            this.btnInsertInstructor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertInstructor.FlatAppearance.BorderSize = 0;
            this.btnInsertInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnInsertInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnInsertInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertInstructor.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertInstructor.ForeColor = System.Drawing.Color.Black;
            this.btnInsertInstructor.Location = new System.Drawing.Point(485, 192);
            this.btnInsertInstructor.Name = "btnInsertInstructor";
            this.btnInsertInstructor.Size = new System.Drawing.Size(88, 32);
            this.btnInsertInstructor.TabIndex = 23;
            this.btnInsertInstructor.Text = "Insert";
            this.btnInsertInstructor.UseVisualStyleBackColor = false;
            this.btnInsertInstructor.Click += new System.EventHandler(this.btnInsertInstructor_Click);
            // 
            // btnUpdateInstructor
            // 
            this.btnUpdateInstructor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateInstructor.BackColor = System.Drawing.Color.Peru;
            this.btnUpdateInstructor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateInstructor.FlatAppearance.BorderSize = 0;
            this.btnUpdateInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnUpdateInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnUpdateInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateInstructor.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInstructor.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateInstructor.Location = new System.Drawing.Point(579, 192);
            this.btnUpdateInstructor.Name = "btnUpdateInstructor";
            this.btnUpdateInstructor.Size = new System.Drawing.Size(88, 32);
            this.btnUpdateInstructor.TabIndex = 22;
            this.btnUpdateInstructor.Text = "Update";
            this.btnUpdateInstructor.UseVisualStyleBackColor = false;
            this.btnUpdateInstructor.Click += new System.EventHandler(this.btnUpdateInstructor_Click);
            // 
            // btnDeleteInstructor
            // 
            this.btnDeleteInstructor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteInstructor.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteInstructor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteInstructor.FlatAppearance.BorderSize = 0;
            this.btnDeleteInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteInstructor.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInstructor.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteInstructor.Location = new System.Drawing.Point(673, 192);
            this.btnDeleteInstructor.Name = "btnDeleteInstructor";
            this.btnDeleteInstructor.Size = new System.Drawing.Size(88, 32);
            this.btnDeleteInstructor.TabIndex = 21;
            this.btnDeleteInstructor.Text = "Delete";
            this.btnDeleteInstructor.UseVisualStyleBackColor = false;
            this.btnDeleteInstructor.Click += new System.EventHandler(this.btnDeleteInstructor_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(374, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 32);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(545, 80);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(208, 45);
            this.txtAddress.TabIndex = 17;
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(545, 136);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(208, 27);
            this.txtMobile.TabIndex = 14;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // genderGrp
            // 
            this.genderGrp.Controls.Add(this.rdbMale);
            this.genderGrp.Controls.Add(this.rdbFemale);
            this.genderGrp.Location = new System.Drawing.Point(152, 157);
            this.genderGrp.Name = "genderGrp";
            this.genderGrp.Size = new System.Drawing.Size(200, 25);
            this.genderGrp.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.DarkGray;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(1051, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 38);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnInsertInstructor);
            this.groupBox1.Controls.Add(this.btnUpdateInstructor);
            this.groupBox1.Controls.Add(this.btnDeleteInstructor);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtMobile);
            this.groupBox1.Controls.Add(this.genderGrp);
            this.groupBox1.Controls.Add(this.txtDOB);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtInstructorId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 235);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instructor Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 44);
            this.label1.TabIndex = 23;
            this.label1.Text = "Instructor Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1180, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 38);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblShiftId);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbShift);
            this.groupBox2.Controls.Add(this.cmbDay);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblInstructorCount);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblInstructorName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnInsertShift);
            this.groupBox2.Controls.Add(this.btnDeleteShift);
            this.groupBox2.Controls.Add(this.btnUpdateShift);
            this.groupBox2.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(792, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 235);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shift Details";
            // 
            // lblShiftId
            // 
            this.lblShiftId.AutoSize = true;
            this.lblShiftId.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftId.Location = new System.Drawing.Point(92, 76);
            this.lblShiftId.Name = "lblShiftId";
            this.lblShiftId.Size = new System.Drawing.Size(21, 22);
            this.lblShiftId.TabIndex = 35;
            this.lblShiftId.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 22);
            this.label13.TabIndex = 34;
            this.label13.Text = "Shift ID";
            // 
            // cmbShift
            // 
            this.cmbShift.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "From 12.00 AM to 06.00 AM",
            "From 06.00 AM to 12.00 PM",
            "From 12.00 PM to 06.00 PM",
            "From 06.00 PM to 12.00 AM"});
            this.cmbShift.Location = new System.Drawing.Point(250, 133);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(252, 30);
            this.cmbShift.TabIndex = 33;
            this.cmbShift.SelectedIndexChanged += new System.EventHandler(this.cmbShift_SelectedIndexChanged);
            // 
            // cmbDay
            // 
            this.cmbDay.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbDay.Location = new System.Drawing.Point(19, 133);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(197, 30);
            this.cmbDay.TabIndex = 32;
            this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.cmbDay_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(246, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 22);
            this.label11.TabIndex = 31;
            this.label11.Text = "Shift Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "Day";
            // 
            // lblInstructorCount
            // 
            this.lblInstructorCount.AutoSize = true;
            this.lblInstructorCount.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructorCount.Location = new System.Drawing.Point(476, 76);
            this.lblInstructorCount.Name = "lblInstructorCount";
            this.lblInstructorCount.Size = new System.Drawing.Size(21, 22);
            this.lblInstructorCount.TabIndex = 29;
            this.lblInstructorCount.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(277, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 22);
            this.label10.TabIndex = 28;
            this.label10.Text = "Allocated Instructors";
            // 
            // lblInstructorName
            // 
            this.lblInstructorName.AutoSize = true;
            this.lblInstructorName.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructorName.Location = new System.Drawing.Point(113, 47);
            this.lblInstructorName.Name = "lblInstructorName";
            this.lblInstructorName.Size = new System.Drawing.Size(182, 22);
            this.lblInstructorName.TabIndex = 27;
            this.lblInstructorName.Text = "Melanne Maduranga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 22);
            this.label6.TabIndex = 24;
            this.label6.Text = "Instructor";
            // 
            // btnInsertShift
            // 
            this.btnInsertShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertShift.BackColor = System.Drawing.Color.LightGreen;
            this.btnInsertShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertShift.FlatAppearance.BorderSize = 0;
            this.btnInsertShift.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnInsertShift.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnInsertShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertShift.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertShift.ForeColor = System.Drawing.Color.Black;
            this.btnInsertShift.Location = new System.Drawing.Point(226, 192);
            this.btnInsertShift.Name = "btnInsertShift";
            this.btnInsertShift.Size = new System.Drawing.Size(88, 32);
            this.btnInsertShift.TabIndex = 26;
            this.btnInsertShift.Text = "Insert";
            this.btnInsertShift.UseVisualStyleBackColor = false;
            this.btnInsertShift.Click += new System.EventHandler(this.btnInsertShift_Click);
            // 
            // btnDeleteShift
            // 
            this.btnDeleteShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteShift.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteShift.FlatAppearance.BorderSize = 0;
            this.btnDeleteShift.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteShift.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteShift.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShift.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteShift.Location = new System.Drawing.Point(414, 192);
            this.btnDeleteShift.Name = "btnDeleteShift";
            this.btnDeleteShift.Size = new System.Drawing.Size(88, 32);
            this.btnDeleteShift.TabIndex = 24;
            this.btnDeleteShift.Text = "Delete";
            this.btnDeleteShift.UseVisualStyleBackColor = false;
            this.btnDeleteShift.Click += new System.EventHandler(this.btnDeleteShift_Click);
            // 
            // btnUpdateShift
            // 
            this.btnUpdateShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateShift.BackColor = System.Drawing.Color.Peru;
            this.btnUpdateShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateShift.FlatAppearance.BorderSize = 0;
            this.btnUpdateShift.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chocolate;
            this.btnUpdateShift.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnUpdateShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateShift.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateShift.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateShift.Location = new System.Drawing.Point(320, 192);
            this.btnUpdateShift.Name = "btnUpdateShift";
            this.btnUpdateShift.Size = new System.Drawing.Size(88, 32);
            this.btnUpdateShift.TabIndex = 25;
            this.btnUpdateShift.Text = "Update";
            this.btnUpdateShift.UseVisualStyleBackColor = false;
            this.btnUpdateShift.Click += new System.EventHandler(this.btnUpdateShift_Click);
            // 
            // dgvShift
            // 
            this.dgvShift.AllowUserToAddRows = false;
            this.dgvShift.AllowUserToDeleteRows = false;
            this.dgvShift.AllowUserToResizeColumns = false;
            this.dgvShift.AllowUserToResizeRows = false;
            this.dgvShift.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShift.BackgroundColor = System.Drawing.Color.White;
            this.dgvShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShift.Location = new System.Drawing.Point(792, 305);
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.ReadOnly = true;
            this.dgvShift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShift.Size = new System.Drawing.Size(511, 205);
            this.dgvShift.TabIndex = 28;
            this.dgvShift.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShift_CellClick);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.DimGray;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(698, 516);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(88, 32);
            this.btnExport.TabIndex = 24;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // InstructorManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::GymManager.Properties.Resources.wp3018787;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1315, 555);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvShift);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvInstructor);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InstructorManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstructorManager";
            this.Load += new System.EventHandler(this.InstructorManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructor)).EndInit();
            this.genderGrp.ResumeLayout(false);
            this.genderGrp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProviderMember;
        private System.Windows.Forms.DataGridView dgvInstructor;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInsertInstructor;
        private System.Windows.Forms.Button btnUpdateInstructor;
        private System.Windows.Forms.Button btnDeleteInstructor;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Panel genderGrp;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.DateTimePicker txtDOB;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtInstructorId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvShift;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInsertShift;
        private System.Windows.Forms.Button btnDeleteShift;
        private System.Windows.Forms.Button btnUpdateShift;
        private System.Windows.Forms.Label lblInstructorCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblInstructorName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblShiftId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnExport;
    }
}