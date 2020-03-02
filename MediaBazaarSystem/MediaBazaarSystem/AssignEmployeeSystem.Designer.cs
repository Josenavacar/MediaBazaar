namespace MediaBazaarSystem
{
    partial class AssignEmployeeSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDone = new System.Windows.Forms.Button();
            this.lBoxAssignEmployee = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDone.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(28, 408);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(520, 46);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            // 
            // lBoxAssignEmployee
            // 
            this.lBoxAssignEmployee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lBoxAssignEmployee.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBoxAssignEmployee.FormattingEnabled = true;
            this.lBoxAssignEmployee.ItemHeight = 23;
            this.lBoxAssignEmployee.Location = new System.Drawing.Point(28, 32);
            this.lBoxAssignEmployee.Name = "lBoxAssignEmployee";
            this.lBoxAssignEmployee.Size = new System.Drawing.Size(520, 188);
            this.lBoxAssignEmployee.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(164, 347);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 29);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(164, 294);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(349, 29);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(164, 248);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(349, 29);
            this.comboBox3.TabIndex = 4;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(54, 251);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(95, 21);
            this.lblEmployeeName.TabIndex = 5;
            this.lblEmployeeName.Text = "Employee:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(53, 297);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(96, 21);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "Start Time:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(61, 350);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(88, 21);
            this.lblEndTime.TabIndex = 7;
            this.lblEndTime.Text = "End Time:";
            // 
            // AssignEmployeeSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(584, 478);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lBoxAssignEmployee);
            this.Controls.Add(this.btnDone);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AssignEmployeeSystem";
            this.Text = "AssignEmployeeSystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ListBox lBoxAssignEmployee;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
    }
}