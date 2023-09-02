namespace Vrtic.Forms
{
    partial class FrmChooseChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChooseChild));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbFindChild = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.DgwListChildren)).BeginInit();
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
            // TbFindChild
            // 
            resources.ApplyResources(this.TbFindChild, "TbFindChild");
            this.TbFindChild.Name = "TbFindChild";
            this.TbFindChild.TextChanged += new System.EventHandler(this.TbFindChild_TextChanged);
            // 
            // BtnAdd
            // 
            resources.ApplyResources(this.BtnAdd, "BtnAdd");
            this.BtnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
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
            // FrmChooseChild
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.DgwListChildren);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TbFindChild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmChooseChild";
            this.Resize += new System.EventHandler(this.FrmChooseChild_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwListChildren)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label LbTitle;
        private Label label2;
        private TextBox TbFindChild;
        private Button BtnAdd;
        private DataGridView DgwListChildren;
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