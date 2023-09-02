namespace Vrtic.Forms
{
    partial class FrmCreateMembershipFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateMembershipFee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label1 = new System.Windows.Forms.Label();
            this.LbFirstName = new System.Windows.Forms.Label();
            this.LbLastName = new System.Windows.Forms.Label();
            this.LbJMB = new System.Windows.Forms.Label();
            this.LbDateOfBirth = new System.Windows.Forms.Label();
            this.TbTypeOfService = new System.Windows.Forms.TextBox();
            this.TbAmount = new System.Windows.Forms.TextBox();
            this.DtpMonth = new System.Windows.Forms.DateTimePicker();
            this.BtnAddMembershipFee = new ePOSOne.btnProduct.Button_WOC();
            this.RbYes = new System.Windows.Forms.RadioButton();
            this.RbNo = new System.Windows.Forms.RadioButton();
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
            // TbTypeOfService
            // 
            resources.ApplyResources(this.TbTypeOfService, "TbTypeOfService");
            this.TbTypeOfService.Name = "TbTypeOfService";
            // 
            // TbAmount
            // 
            resources.ApplyResources(this.TbAmount, "TbAmount");
            this.TbAmount.Name = "TbAmount";
            // 
            // DtpMonth
            // 
            resources.ApplyResources(this.DtpMonth, "DtpMonth");
            this.DtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMonth.Name = "DtpMonth";
            // 
            // BtnAddMembershipFee
            // 
            resources.ApplyResources(this.BtnAddMembershipFee, "BtnAddMembershipFee");
            this.BtnAddMembershipFee.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddMembershipFee.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAddMembershipFee.FlatAppearance.BorderSize = 0;
            this.BtnAddMembershipFee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnAddMembershipFee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnAddMembershipFee.Name = "BtnAddMembershipFee";
            this.BtnAddMembershipFee.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnAddMembershipFee.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAddMembershipFee.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnAddMembershipFee.TextColor = System.Drawing.Color.Black;
            this.BtnAddMembershipFee.UseVisualStyleBackColor = true;
            this.BtnAddMembershipFee.Click += new System.EventHandler(this.BtnAddMembershipFee_Click);
            // 
            // RbYes
            // 
            resources.ApplyResources(this.RbYes, "RbYes");
            this.RbYes.Name = "RbYes";
            this.RbYes.TabStop = true;
            this.RbYes.UseVisualStyleBackColor = true;
            // 
            // RbNo
            // 
            resources.ApplyResources(this.RbNo, "RbNo");
            this.RbNo.Name = "RbNo";
            this.RbNo.TabStop = true;
            this.RbNo.UseVisualStyleBackColor = true;
            // 
            // FrmCreateMembershipFee
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RbNo);
            this.Controls.Add(this.RbYes);
            this.Controls.Add(this.BtnAddMembershipFee);
            this.Controls.Add(this.DtpMonth);
            this.Controls.Add(this.TbAmount);
            this.Controls.Add(this.TbTypeOfService);
            this.Controls.Add(this.LbDateOfBirth);
            this.Controls.Add(this.LbJMB);
            this.Controls.Add(this.LbLastName);
            this.Controls.Add(this.LbFirstName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateMembershipFee";
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
        private TextBox TbTypeOfService;
        private TextBox TbAmount;
        private DateTimePicker DtpMonth;
        private ePOSOne.btnProduct.Button_WOC BtnAddMembershipFee;
        private RadioButton RbYes;
        private RadioButton RbNo;
    }
}