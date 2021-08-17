
namespace MyStore.WinApp
{
    partial class UserGroupEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupEdit));
            this.editBtn = new System.Windows.Forms.Button();
            this.supllyManagerBox = new System.Windows.Forms.CheckBox();
            this.managerBox = new System.Windows.Forms.CheckBox();
            this.cashierBox = new System.Windows.Forms.CheckBox();
            this.adminBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(121, 234);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(103, 23);
            this.editBtn.TabIndex = 15;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // supllyManagerBox
            // 
            this.supllyManagerBox.AutoSize = true;
            this.supllyManagerBox.Location = new System.Drawing.Point(215, 188);
            this.supllyManagerBox.Name = "supllyManagerBox";
            this.supllyManagerBox.Size = new System.Drawing.Size(112, 19);
            this.supllyManagerBox.TabIndex = 14;
            this.supllyManagerBox.Text = "Supply Manager";
            this.supllyManagerBox.UseVisualStyleBackColor = true;
            this.supllyManagerBox.CheckedChanged += new System.EventHandler(this.supllyManagerBox_CheckedChanged);
            // 
            // managerBox
            // 
            this.managerBox.AutoSize = true;
            this.managerBox.Location = new System.Drawing.Point(215, 151);
            this.managerBox.Name = "managerBox";
            this.managerBox.Size = new System.Drawing.Size(73, 19);
            this.managerBox.TabIndex = 13;
            this.managerBox.Text = "Manager";
            this.managerBox.UseVisualStyleBackColor = true;
            this.managerBox.CheckedChanged += new System.EventHandler(this.managerBox_CheckedChanged);
            // 
            // cashierBox
            // 
            this.cashierBox.AutoSize = true;
            this.cashierBox.Location = new System.Drawing.Point(40, 188);
            this.cashierBox.Name = "cashierBox";
            this.cashierBox.Size = new System.Drawing.Size(65, 19);
            this.cashierBox.TabIndex = 12;
            this.cashierBox.Text = "Cashier";
            this.cashierBox.UseVisualStyleBackColor = true;
            this.cashierBox.CheckedChanged += new System.EventHandler(this.cashierBox_CheckedChanged);
            // 
            // adminBox
            // 
            this.adminBox.AutoSize = true;
            this.adminBox.Location = new System.Drawing.Point(40, 151);
            this.adminBox.Name = "adminBox";
            this.adminBox.Size = new System.Drawing.Size(62, 19);
            this.adminBox.TabIndex = 11;
            this.adminBox.Text = "Admin";
            this.adminBox.UseVisualStyleBackColor = true;
            this.adminBox.CheckedChanged += new System.EventHandler(this.adminBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "User";
            // 
            // idBox
            // 
            this.idBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idBox.FormattingEnabled = true;
            this.idBox.Location = new System.Drawing.Point(147, 55);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(167, 23);
            this.idBox.TabIndex = 9;
            this.idBox.SelectedIndexChanged += new System.EventHandler(this.idBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // UserGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 269);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.supllyManagerBox);
            this.Controls.Add(this.managerBox);
            this.Controls.Add(this.cashierBox);
            this.Controls.Add(this.adminBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserGroupEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit User Group";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.CheckBox supllyManagerBox;
        private System.Windows.Forms.CheckBox managerBox;
        private System.Windows.Forms.CheckBox cashierBox;
        private System.Windows.Forms.CheckBox adminBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox idBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}