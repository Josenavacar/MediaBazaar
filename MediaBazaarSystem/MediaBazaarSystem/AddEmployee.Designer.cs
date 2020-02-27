namespace MediaBazaarSystem
{
    partial class Employee_Add
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
            this.tbFirstN = new System.Windows.Forms.TextBox();
            this.tbLastN = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHours = new System.Windows.Forms.TextBox();
            this.tbSalary = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFirstN
            // 
            this.tbFirstN.Location = new System.Drawing.Point(200, 35);
            this.tbFirstN.Name = "tbFirstN";
            this.tbFirstN.Size = new System.Drawing.Size(150, 20);
            this.tbFirstN.TabIndex = 0;
            // 
            // tbLastN
            // 
            this.tbLastN.Location = new System.Drawing.Point(200, 75);
            this.tbLastN.Name = "tbLastN";
            this.tbLastN.Size = new System.Drawing.Size(150, 20);
            this.tbLastN.TabIndex = 1;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(200, 153);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(150, 20);
            this.tbAddress.TabIndex = 2;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(168, 318);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(129, 23);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "Add/Edit";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "First name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Last name(s):";
            // 
            // numAge
            // 
            this.numAge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numAge.Location = new System.Drawing.Point(200, 116);
            this.numAge.Maximum = new decimal(new int[] {
            67,
            0,
            0,
            0});
            this.numAge.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(120, 20);
            this.numAge.TabIndex = 6;
            this.numAge.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Address:";
            // 
            // cbPosition
            // 
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Items.AddRange(new object[] {
            "Manager",
            "Employee"});
            this.cbPosition.Location = new System.Drawing.Point(200, 188);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(121, 21);
            this.cbPosition.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Position:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hours Available:";
            // 
            // tbHours
            // 
            this.tbHours.Location = new System.Drawing.Point(201, 265);
            this.tbHours.Name = "tbHours";
            this.tbHours.Size = new System.Drawing.Size(120, 20);
            this.tbHours.TabIndex = 13;
            // 
            // tbSalary
            // 
            this.tbSalary.Location = new System.Drawing.Point(200, 229);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(120, 20);
            this.tbSalary.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Salary:";
            // 
            // Employee_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 363);
            this.Controls.Add(this.tbSalary);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbHours);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbLastN);
            this.Controls.Add(this.tbFirstN);
            this.Name = "Employee_Add";
            this.Text = "Employee_Add";
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFirstN;
        private System.Windows.Forms.TextBox tbLastN;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHours;
        private System.Windows.Forms.TextBox tbSalary;
        private System.Windows.Forms.Label label7;
    }
}