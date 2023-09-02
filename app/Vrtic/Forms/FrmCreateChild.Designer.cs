namespace Vrtic.Forms
{
    partial class FrmCreateChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateChild));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.LbFirstName = new System.Windows.Forms.Label();
            this.LbLastName = new System.Windows.Forms.Label();
            this.LbJMB = new System.Windows.Forms.Label();
            this.LbDateOfBirth = new System.Windows.Forms.Label();
            this.LbAddress = new System.Windows.Forms.Label();
            this.LbHeight = new System.Windows.Forms.Label();
            this.LbWeight = new System.Windows.Forms.Label();
            this.BtnAddUser = new ePOSOne.btnProduct.Button_WOC();
            this.TbFirstName = new System.Windows.Forms.TextBox();
            this.TbLastName = new System.Windows.Forms.TextBox();
            this.TbJMB = new System.Windows.Forms.TextBox();
            this.DtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.TbAddress = new System.Windows.Forms.TextBox();
            this.TbHeight = new System.Windows.Forms.TextBox();
            this.TbWeight = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // LbFirstName
            // 
            resources.ApplyResources(this.LbFirstName, "LbFirstName");
            this.LbFirstName.Name = "LbFirstName";
            // 
            // LbLastName
            // 
            resources.ApplyResources(this.LbLastName, "LbLastName");
            this.LbLastName.Name = "LbLastName";
            // 
            // LbJMB
            // 
            resources.ApplyResources(this.LbJMB, "LbJMB");
            this.LbJMB.Name = "LbJMB";
            // 
            // LbDateOfBirth
            // 
            resources.ApplyResources(this.LbDateOfBirth, "LbDateOfBirth");
            this.LbDateOfBirth.Name = "LbDateOfBirth";
            // 
            // LbAddress
            // 
            resources.ApplyResources(this.LbAddress, "LbAddress");
            this.LbAddress.Name = "LbAddress";
            // 
            // LbHeight
            // 
            resources.ApplyResources(this.LbHeight, "LbHeight");
            this.LbHeight.Name = "LbHeight";
            // 
            // LbWeight
            // 
            resources.ApplyResources(this.LbWeight, "LbWeight");
            this.LbWeight.Name = "LbWeight";
            // 
            // BtnAddUser
            // 
            resources.ApplyResources(this.BtnAddUser, "BtnAddUser");
            this.BtnAddUser.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddUser.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAddUser.FlatAppearance.BorderSize = 0;
            this.BtnAddUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnAddUser.Name = "BtnAddUser";
            this.BtnAddUser.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnAddUser.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAddUser.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnAddUser.TextColor = System.Drawing.Color.Black;
            this.BtnAddUser.UseVisualStyleBackColor = true;
            this.BtnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // TbFirstName
            // 
            resources.ApplyResources(this.TbFirstName, "TbFirstName");
            this.TbFirstName.Name = "TbFirstName";
            // 
            // TbLastName
            // 
            resources.ApplyResources(this.TbLastName, "TbLastName");
            this.TbLastName.Name = "TbLastName";
            // 
            // TbJMB
            // 
            resources.ApplyResources(this.TbJMB, "TbJMB");
            this.TbJMB.Name = "TbJMB";
            // 
            // DtpDateOfBirth
            // 
            resources.ApplyResources(this.DtpDateOfBirth, "DtpDateOfBirth");
            this.DtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateOfBirth.Name = "DtpDateOfBirth";
            // 
            // TbAddress
            // 
            resources.ApplyResources(this.TbAddress, "TbAddress");
            this.TbAddress.Name = "TbAddress";
            // 
            // TbHeight
            // 
            resources.ApplyResources(this.TbHeight, "TbHeight");
            this.TbHeight.Name = "TbHeight";
            // 
            // TbWeight
            // 
            resources.ApplyResources(this.TbWeight, "TbWeight");
            this.TbWeight.Name = "TbWeight";
            // 
            // FrmCreateChild
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbWeight);
            this.Controls.Add(this.TbHeight);
            this.Controls.Add(this.TbAddress);
            this.Controls.Add(this.DtpDateOfBirth);
            this.Controls.Add(this.TbJMB);
            this.Controls.Add(this.TbLastName);
            this.Controls.Add(this.TbFirstName);
            this.Controls.Add(this.BtnAddUser);
            this.Controls.Add(this.LbWeight);
            this.Controls.Add(this.LbHeight);
            this.Controls.Add(this.LbAddress);
            this.Controls.Add(this.LbDateOfBirth);
            this.Controls.Add(this.LbJMB);
            this.Controls.Add(this.LbLastName);
            this.Controls.Add(this.LbFirstName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateChild";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Splitter splitter1;
        private Label label1;
        private Label LbFirstName;
        private Label LbLastName;
        private Label LbJMB;
        private Label LbDateOfBirth;
        private Label LbAddress;
        private Label LbHeight;
        private Label LbWeight;
        private ePOSOne.btnProduct.Button_WOC BtnAddUser;
        private TextBox TbFirstName;
        private TextBox TbLastName;
        private TextBox TbJMB;
        private DateTimePicker DtpDateOfBirth;
        private TextBox TbAddress;
        private TextBox TbHeight;
        private TextBox TbWeight;
    }
}