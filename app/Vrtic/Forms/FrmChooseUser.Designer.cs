namespace Vrtic.Forms
{
    partial class FrmChooseUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChooseUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbFindUser = new System.Windows.Forms.TextBox();
            this.DgwListUsers = new System.Windows.Forms.DataGridView();
            this.ClmnIdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnJMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.LbTitle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // LbTitle
            // 
            resources.ApplyResources(this.LbTitle, "LbTitle");
            this.LbTitle.Name = "LbTitle";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TbFindUser
            // 
            resources.ApplyResources(this.TbFindUser, "TbFindUser");
            this.TbFindUser.Name = "TbFindUser";
            this.TbFindUser.TextChanged += new System.EventHandler(this.TbFindUser_TextChanged);
            // 
            // DgwListUsers
            // 
            this.DgwListUsers.AllowUserToAddRows = false;
            this.DgwListUsers.AllowUserToDeleteRows = false;
            this.DgwListUsers.AllowUserToResizeColumns = false;
            this.DgwListUsers.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DgwListUsers, "DgwListUsers");
            this.DgwListUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgwListUsers.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DgwListUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgwListUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgwListUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnIdUser,
            this.ClmnFirstName,
            this.ClmnLastName,
            this.ClmnJMB,
            this.ClmnDateOfBirth,
            this.ClmnAddress,
            this.ClmnSalary});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgwListUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgwListUsers.MultiSelect = false;
            this.DgwListUsers.Name = "DgwListUsers";
            this.DgwListUsers.ReadOnly = true;
            this.DgwListUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgwListUsers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DgwListUsers.RowTemplate.Height = 25;
            this.DgwListUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ClmnIdUser
            // 
            this.ClmnIdUser.FillWeight = 50.76142F;
            resources.ApplyResources(this.ClmnIdUser, "ClmnIdUser");
            this.ClmnIdUser.Name = "ClmnIdUser";
            this.ClmnIdUser.ReadOnly = true;
            // 
            // ClmnFirstName
            // 
            this.ClmnFirstName.FillWeight = 112.3096F;
            resources.ApplyResources(this.ClmnFirstName, "ClmnFirstName");
            this.ClmnFirstName.Name = "ClmnFirstName";
            this.ClmnFirstName.ReadOnly = true;
            // 
            // ClmnLastName
            // 
            this.ClmnLastName.FillWeight = 112.3096F;
            resources.ApplyResources(this.ClmnLastName, "ClmnLastName");
            this.ClmnLastName.Name = "ClmnLastName";
            this.ClmnLastName.ReadOnly = true;
            // 
            // ClmnJMB
            // 
            this.ClmnJMB.FillWeight = 112.3096F;
            resources.ApplyResources(this.ClmnJMB, "ClmnJMB");
            this.ClmnJMB.Name = "ClmnJMB";
            this.ClmnJMB.ReadOnly = true;
            // 
            // ClmnDateOfBirth
            // 
            resources.ApplyResources(this.ClmnDateOfBirth, "ClmnDateOfBirth");
            this.ClmnDateOfBirth.Name = "ClmnDateOfBirth";
            this.ClmnDateOfBirth.ReadOnly = true;
            // 
            // ClmnAddress
            // 
            this.ClmnAddress.FillWeight = 112.3096F;
            resources.ApplyResources(this.ClmnAddress, "ClmnAddress");
            this.ClmnAddress.Name = "ClmnAddress";
            this.ClmnAddress.ReadOnly = true;
            // 
            // ClmnSalary
            // 
            resources.ApplyResources(this.ClmnSalary, "ClmnSalary");
            this.ClmnSalary.Name = "ClmnSalary";
            this.ClmnSalary.ReadOnly = true;
            // 
            // BtnAdd
            // 
            resources.ApplyResources(this.BtnAdd, "BtnAdd");
            this.BtnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // FrmChooseUser
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.DgwListUsers);
            this.Controls.Add(this.TbFindUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmChooseUser";
            this.Resize += new System.EventHandler(this.FrmChooseUser_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Panel panel1;
        private Label LbTitle;
        private Label label2;
        private TextBox TbFindUser;
        private DataGridView DgwListUsers;
        private Button BtnAdd;
        private DataGridViewTextBoxColumn ClmnIdUser;
        private DataGridViewTextBoxColumn ClmnFirstName;
        private DataGridViewTextBoxColumn ClmnLastName;
        private DataGridViewTextBoxColumn ClmnJMB;
        private DataGridViewTextBoxColumn ClmnDateOfBirth;
        private DataGridViewTextBoxColumn ClmnAddress;
        private DataGridViewTextBoxColumn ClmnSalary;
    }
}