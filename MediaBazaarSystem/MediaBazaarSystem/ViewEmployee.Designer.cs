namespace MediaBazaarSystem
{
    partial class ViewEmployee
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
            this.lbMoney = new System.Windows.Forms.Label();
            this.lbTimeAv = new System.Windows.Forms.Label();
            this.lbWork = new System.Windows.Forms.Label();
            this.lbPlace = new System.Windows.Forms.Label();
            this.lbOld = new System.Windows.Forms.Label();
            this.lbSurn = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Location = new System.Drawing.Point(75, 214);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(39, 13);
            this.lbMoney.TabIndex = 21;
            this.lbMoney.Text = "Salary:";
            // 
            // lbTimeAv
            // 
            this.lbTimeAv.AutoSize = true;
            this.lbTimeAv.Location = new System.Drawing.Point(32, 250);
            this.lbTimeAv.Name = "lbTimeAv";
            this.lbTimeAv.Size = new System.Drawing.Size(84, 13);
            this.lbTimeAv.TabIndex = 20;
            this.lbTimeAv.Text = "Hours Available:";
            // 
            // lbWork
            // 
            this.lbWork.AutoSize = true;
            this.lbWork.Location = new System.Drawing.Point(67, 173);
            this.lbWork.Name = "lbWork";
            this.lbWork.Size = new System.Drawing.Size(47, 13);
            this.lbWork.TabIndex = 19;
            this.lbWork.Text = "Position:";
            // 
            // lbPlace
            // 
            this.lbPlace.AutoSize = true;
            this.lbPlace.Location = new System.Drawing.Point(67, 138);
            this.lbPlace.Name = "lbPlace";
            this.lbPlace.Size = new System.Drawing.Size(48, 13);
            this.lbPlace.TabIndex = 18;
            this.lbPlace.Text = "Address:";
            // 
            // lbOld
            // 
            this.lbOld.AutoSize = true;
            this.lbOld.Location = new System.Drawing.Point(86, 100);
            this.lbOld.Name = "lbOld";
            this.lbOld.Size = new System.Drawing.Size(29, 13);
            this.lbOld.TabIndex = 17;
            this.lbOld.Text = "Age:";
            // 
            // lbSurn
            // 
            this.lbSurn.AutoSize = true;
            this.lbSurn.Location = new System.Drawing.Point(45, 60);
            this.lbSurn.Name = "lbSurn";
            this.lbSurn.Size = new System.Drawing.Size(70, 13);
            this.lbSurn.TabIndex = 16;
            this.lbSurn.Text = "Last name(s):";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(57, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(58, 13);
            this.lbName.TabIndex = 15;
            this.lbName.Text = "First name:";
            // 
            // ViewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 296);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.lbTimeAv);
            this.Controls.Add(this.lbWork);
            this.Controls.Add(this.lbPlace);
            this.Controls.Add(this.lbOld);
            this.Controls.Add(this.lbSurn);
            this.Controls.Add(this.lbName);
            this.Name = "ViewEmployee";
            this.Text = "ViewEmployee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.Label lbTimeAv;
        private System.Windows.Forms.Label lbWork;
        private System.Windows.Forms.Label lbPlace;
        private System.Windows.Forms.Label lbOld;
        private System.Windows.Forms.Label lbSurn;
        private System.Windows.Forms.Label lbName;
    }
}