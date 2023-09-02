namespace Vrtic.Forms
{
    partial class FrmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroup));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbGroupName = new System.Windows.Forms.Label();
            this.BtnAddChild = new ePOSOne.btnProduct.Button_WOC();
            this.BtnAddUser = new ePOSOne.btnProduct.Button_WOC();
            this.BtnDeleteChild = new ePOSOne.btnProduct.Button_WOC();
            this.BtnDeleteUser = new ePOSOne.btnProduct.Button_WOC();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LbUsers = new System.Windows.Forms.Label();
            this.DgwListUsers = new System.Windows.Forms.DataGridView();
            this.ClmnIdUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnJMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LbChildren = new System.Windows.Forms.Label();
            this.DgwListChildren = new System.Windows.Forms.DataGridView();
            this.ClmnIdChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnNameChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnSurnameChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnJMBChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDateOfBirthChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAddressChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnHeightChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnWeightChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListUsers)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LbGroupName);
            this.panel1.Controls.Add(this.BtnAddChild);
            this.panel1.Controls.Add(this.BtnAddUser);
            this.panel1.Controls.Add(this.BtnDeleteChild);
            this.panel1.Controls.Add(this.BtnDeleteUser);
            this.panel1.Name = "panel1";
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox4.Image = global::Vrtic.Properties.Resources.trash;
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox3.Image = global::Vrtic.Properties.Resources.trash;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox2.Image = global::Vrtic.Properties.Resources.add_friend;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Image = global::Vrtic.Properties.Resources.add_friend;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // LbGroupName
            // 
            resources.ApplyResources(this.LbGroupName, "LbGroupName");
            this.LbGroupName.Name = "LbGroupName";
            // 
            // BtnAddChild
            // 
            resources.ApplyResources(this.BtnAddChild, "BtnAddChild");
            this.BtnAddChild.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddChild.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAddChild.FlatAppearance.BorderSize = 0;
            this.BtnAddChild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnAddChild.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnAddChild.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAddChild.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnAddChild.TextColor = System.Drawing.Color.Black;
            this.BtnAddChild.UseVisualStyleBackColor = true;
            this.BtnAddChild.Click += new System.EventHandler(this.BtnAddChild_Click);
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
            // BtnDeleteChild
            // 
            resources.ApplyResources(this.BtnDeleteChild, "BtnDeleteChild");
            this.BtnDeleteChild.BorderColor = System.Drawing.Color.Silver;
            this.BtnDeleteChild.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnDeleteChild.FlatAppearance.BorderSize = 0;
            this.BtnDeleteChild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteChild.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteChild.Name = "BtnDeleteChild";
            this.BtnDeleteChild.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnDeleteChild.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnDeleteChild.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnDeleteChild.TextColor = System.Drawing.Color.Black;
            this.BtnDeleteChild.UseVisualStyleBackColor = true;
            this.BtnDeleteChild.Click += new System.EventHandler(this.BtnDeleteChild_Click);
            // 
            // BtnDeleteUser
            // 
            resources.ApplyResources(this.BtnDeleteUser, "BtnDeleteUser");
            this.BtnDeleteUser.BorderColor = System.Drawing.Color.Silver;
            this.BtnDeleteUser.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnDeleteUser.FlatAppearance.BorderSize = 0;
            this.BtnDeleteUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteUser.Name = "BtnDeleteUser";
            this.BtnDeleteUser.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnDeleteUser.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnDeleteUser.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnDeleteUser.TextColor = System.Drawing.Color.Black;
            this.BtnDeleteUser.UseVisualStyleBackColor = true;
            this.BtnDeleteUser.Click += new System.EventHandler(this.BtnDeleteUser_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LbUsers);
            this.panel2.Controls.Add(this.DgwListUsers);
            this.panel2.Name = "panel2";
            // 
            // LbUsers
            // 
            resources.ApplyResources(this.LbUsers, "LbUsers");
            this.LbUsers.Name = "LbUsers";
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
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.LbChildren);
            this.panel3.Controls.Add(this.DgwListChildren);
            this.panel3.Name = "panel3";
            // 
            // LbChildren
            // 
            resources.ApplyResources(this.LbChildren, "LbChildren");
            this.LbChildren.Name = "LbChildren";
            // 
            // DgwListChildren
            // 
            this.DgwListChildren.AllowUserToAddRows = false;
            this.DgwListChildren.AllowUserToDeleteRows = false;
            this.DgwListChildren.AllowUserToResizeColumns = false;
            this.DgwListChildren.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DgwListChildren, "DgwListChildren");
            this.DgwListChildren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgwListChildren.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DgwListChildren.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgwListChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgwListChildren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnIdChild,
            this.ClmnNameChild,
            this.ClmnSurnameChild,
            this.ClmnJMBChild,
            this.ClmnDateOfBirthChild,
            this.ClmnAddressChild,
            this.ClmnHeightChild,
            this.ClmnWeightChild});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgwListChildren.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgwListChildren.MultiSelect = false;
            this.DgwListChildren.Name = "DgwListChildren";
            this.DgwListChildren.ReadOnly = true;
            this.DgwListChildren.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgwListChildren.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DgwListChildren.RowTemplate.Height = 25;
            this.DgwListChildren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgwListChildren.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwListChildren_CellDoubleClick);
            // 
            // ClmnIdChild
            // 
            resources.ApplyResources(this.ClmnIdChild, "ClmnIdChild");
            this.ClmnIdChild.Name = "ClmnIdChild";
            this.ClmnIdChild.ReadOnly = true;
            // 
            // ClmnNameChild
            // 
            this.ClmnNameChild.FillWeight = 116.4501F;
            resources.ApplyResources(this.ClmnNameChild, "ClmnNameChild");
            this.ClmnNameChild.Name = "ClmnNameChild";
            this.ClmnNameChild.ReadOnly = true;
            // 
            // ClmnSurnameChild
            // 
            this.ClmnSurnameChild.FillWeight = 116.4501F;
            resources.ApplyResources(this.ClmnSurnameChild, "ClmnSurnameChild");
            this.ClmnSurnameChild.Name = "ClmnSurnameChild";
            this.ClmnSurnameChild.ReadOnly = true;
            // 
            // ClmnJMBChild
            // 
            this.ClmnJMBChild.FillWeight = 116.4501F;
            resources.ApplyResources(this.ClmnJMBChild, "ClmnJMBChild");
            this.ClmnJMBChild.Name = "ClmnJMBChild";
            this.ClmnJMBChild.ReadOnly = true;
            // 
            // ClmnDateOfBirthChild
            // 
            this.ClmnDateOfBirthChild.FillWeight = 103.6867F;
            resources.ApplyResources(this.ClmnDateOfBirthChild, "ClmnDateOfBirthChild");
            this.ClmnDateOfBirthChild.Name = "ClmnDateOfBirthChild";
            this.ClmnDateOfBirthChild.ReadOnly = true;
            // 
            // ClmnAddressChild
            // 
            this.ClmnAddressChild.FillWeight = 116.4501F;
            resources.ApplyResources(this.ClmnAddressChild, "ClmnAddressChild");
            this.ClmnAddressChild.Name = "ClmnAddressChild";
            this.ClmnAddressChild.ReadOnly = true;
            // 
            // ClmnHeightChild
            // 
            this.ClmnHeightChild.FillWeight = 76.06481F;
            resources.ApplyResources(this.ClmnHeightChild, "ClmnHeightChild");
            this.ClmnHeightChild.Name = "ClmnHeightChild";
            this.ClmnHeightChild.ReadOnly = true;
            // 
            // ClmnWeightChild
            // 
            this.ClmnWeightChild.FillWeight = 103.6867F;
            resources.ApplyResources(this.ClmnWeightChild, "ClmnWeightChild");
            this.ClmnWeightChild.Name = "ClmnWeightChild";
            this.ClmnWeightChild.ReadOnly = true;
            // 
            // FrmGroup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGroup";
            this.Resize += new System.EventHandler(this.FrmGroup_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListUsers)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListChildren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ePOSOne.btnProduct.Button_WOC BtnAddChild;
        private ePOSOne.btnProduct.Button_WOC BtnAddUser;
        private ePOSOne.btnProduct.Button_WOC BtnDeleteChild;
        private ePOSOne.btnProduct.Button_WOC BtnDeleteUser;
        private Label LbGroupName;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Panel panel3;
        private DataGridView DgwListUsers;
        private DataGridView DgwListChildren;
        private Label LbUsers;
        private Label LbChildren;
        private DataGridViewTextBoxColumn ClmnIdUser;
        private DataGridViewTextBoxColumn ClmnFirstName;
        private DataGridViewTextBoxColumn ClmnLastName;
        private DataGridViewTextBoxColumn ClmnJMB;
        private DataGridViewTextBoxColumn ClmnDateOfBirth;
        private DataGridViewTextBoxColumn ClmnAddress;
        private DataGridViewTextBoxColumn ClmnSalary;
        private DataGridViewTextBoxColumn ClmnIdChild;
        private DataGridViewTextBoxColumn ClmnNameChild;
        private DataGridViewTextBoxColumn ClmnSurnameChild;
        private DataGridViewTextBoxColumn ClmnJMBChild;
        private DataGridViewTextBoxColumn ClmnDateOfBirthChild;
        private DataGridViewTextBoxColumn ClmnAddressChild;
        private DataGridViewTextBoxColumn ClmnHeightChild;
        private DataGridViewTextBoxColumn ClmnWeightChild;
    }
}