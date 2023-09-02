namespace Vrtic.Forms
{
    partial class FrmChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChild));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.LbFrom = new System.Windows.Forms.Label();
            this.BtnFilter = new ePOSOne.btnProduct.Button_WOC();
            this.DtpUntil = new System.Windows.Forms.DateTimePicker();
            this.LbUntil = new System.Windows.Forms.Label();
            this.DgwArrivalDeparture = new System.Windows.Forms.DataGridView();
            this.ClmnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnChildId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmArrivalDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.BtnLogDeparture = new ePOSOne.btnProduct.Button_WOC();
            this.BtnLogArrival = new ePOSOne.btnProduct.Button_WOC();
            this.LbTitle = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgwMembershipFee = new System.Windows.Forms.DataGridView();
            this.ClmnMembershipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnTypeOfService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmnDateOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BtnCreateNew = new ePOSOne.btnProduct.Button_WOC();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BtnLogPayment = new ePOSOne.btnProduct.Button_WOC();
            this.LbMembership = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwArrivalDeparture)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwMembershipFee)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DtpFrom);
            this.tabPage1.Controls.Add(this.LbFrom);
            this.tabPage1.Controls.Add(this.BtnFilter);
            this.tabPage1.Controls.Add(this.DtpUntil);
            this.tabPage1.Controls.Add(this.LbUntil);
            this.tabPage1.Controls.Add(this.DgwArrivalDeparture);
            this.tabPage1.Controls.Add(this.panel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DtpFrom
            // 
            this.DtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.DtpFrom, "DtpFrom");
            this.DtpFrom.Name = "DtpFrom";
            // 
            // LbFrom
            // 
            resources.ApplyResources(this.LbFrom, "LbFrom");
            this.LbFrom.Name = "LbFrom";
            // 
            // BtnFilter
            // 
            resources.ApplyResources(this.BtnFilter, "BtnFilter");
            this.BtnFilter.BackColor = System.Drawing.Color.Transparent;
            this.BtnFilter.BorderColor = System.Drawing.Color.Silver;
            this.BtnFilter.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnFilter.FlatAppearance.BorderSize = 0;
            this.BtnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnFilter.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnFilter.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnFilter.TextColor = System.Drawing.Color.Black;
            this.BtnFilter.UseVisualStyleBackColor = false;
            this.BtnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // DtpUntil
            // 
            resources.ApplyResources(this.DtpUntil, "DtpUntil");
            this.DtpUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpUntil.Name = "DtpUntil";
            // 
            // LbUntil
            // 
            resources.ApplyResources(this.LbUntil, "LbUntil");
            this.LbUntil.Name = "LbUntil";
            // 
            // DgwArrivalDeparture
            // 
            this.DgwArrivalDeparture.AllowUserToAddRows = false;
            this.DgwArrivalDeparture.AllowUserToDeleteRows = false;
            this.DgwArrivalDeparture.AllowUserToResizeColumns = false;
            this.DgwArrivalDeparture.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DgwArrivalDeparture, "DgwArrivalDeparture");
            this.DgwArrivalDeparture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgwArrivalDeparture.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DgwArrivalDeparture.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgwArrivalDeparture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgwArrivalDeparture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnId,
            this.ClmnChildId,
            this.ClmnDate,
            this.ClmnTime,
            this.ClmArrivalDeparture});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgwArrivalDeparture.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgwArrivalDeparture.MultiSelect = false;
            this.DgwArrivalDeparture.Name = "DgwArrivalDeparture";
            this.DgwArrivalDeparture.ReadOnly = true;
            this.DgwArrivalDeparture.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgwArrivalDeparture.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DgwArrivalDeparture.RowTemplate.Height = 25;
            this.DgwArrivalDeparture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ClmnId
            // 
            resources.ApplyResources(this.ClmnId, "ClmnId");
            this.ClmnId.Name = "ClmnId";
            this.ClmnId.ReadOnly = true;
            // 
            // ClmnChildId
            // 
            resources.ApplyResources(this.ClmnChildId, "ClmnChildId");
            this.ClmnChildId.Name = "ClmnChildId";
            this.ClmnChildId.ReadOnly = true;
            // 
            // ClmnDate
            // 
            resources.ApplyResources(this.ClmnDate, "ClmnDate");
            this.ClmnDate.Name = "ClmnDate";
            this.ClmnDate.ReadOnly = true;
            // 
            // ClmnTime
            // 
            resources.ApplyResources(this.ClmnTime, "ClmnTime");
            this.ClmnTime.Name = "ClmnTime";
            this.ClmnTime.ReadOnly = true;
            // 
            // ClmArrivalDeparture
            // 
            resources.ApplyResources(this.ClmArrivalDeparture, "ClmArrivalDeparture");
            this.ClmArrivalDeparture.Name = "ClmArrivalDeparture";
            this.ClmArrivalDeparture.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.BtnLogDeparture);
            this.panel1.Controls.Add(this.BtnLogArrival);
            this.panel1.Controls.Add(this.LbTitle);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Image = global::Vrtic.Properties.Resources.floppy_disk;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            resources.ApplyResources(this.pictureBox8, "pictureBox8");
            this.pictureBox8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox8.Image = global::Vrtic.Properties.Resources.floppy_disk;
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.TabStop = false;
            // 
            // BtnLogDeparture
            // 
            resources.ApplyResources(this.BtnLogDeparture, "BtnLogDeparture");
            this.BtnLogDeparture.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogDeparture.BorderColor = System.Drawing.Color.Silver;
            this.BtnLogDeparture.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnLogDeparture.FlatAppearance.BorderSize = 0;
            this.BtnLogDeparture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnLogDeparture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnLogDeparture.Name = "BtnLogDeparture";
            this.BtnLogDeparture.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnLogDeparture.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnLogDeparture.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnLogDeparture.TextColor = System.Drawing.Color.Black;
            this.BtnLogDeparture.UseVisualStyleBackColor = false;
            this.BtnLogDeparture.Click += new System.EventHandler(this.BtnLogDeparture_Click);
            // 
            // BtnLogArrival
            // 
            resources.ApplyResources(this.BtnLogArrival, "BtnLogArrival");
            this.BtnLogArrival.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogArrival.BorderColor = System.Drawing.Color.Silver;
            this.BtnLogArrival.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnLogArrival.FlatAppearance.BorderSize = 0;
            this.BtnLogArrival.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnLogArrival.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnLogArrival.Name = "BtnLogArrival";
            this.BtnLogArrival.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnLogArrival.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnLogArrival.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnLogArrival.TextColor = System.Drawing.Color.Black;
            this.BtnLogArrival.UseVisualStyleBackColor = false;
            this.BtnLogArrival.Click += new System.EventHandler(this.BtnLogArrival_Click);
            // 
            // LbTitle
            // 
            resources.ApplyResources(this.LbTitle, "LbTitle");
            this.LbTitle.Name = "LbTitle";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgwMembershipFee);
            this.tabPage2.Controls.Add(this.panel2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgwMembershipFee
            // 
            this.DgwMembershipFee.AllowUserToAddRows = false;
            this.DgwMembershipFee.AllowUserToDeleteRows = false;
            this.DgwMembershipFee.AllowUserToResizeColumns = false;
            this.DgwMembershipFee.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DgwMembershipFee, "DgwMembershipFee");
            this.DgwMembershipFee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgwMembershipFee.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DgwMembershipFee.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgwMembershipFee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgwMembershipFee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmnMembershipId,
            this.ClmnTypeOfService,
            this.ClmnAmount,
            this.ClmnPaid,
            this.ClmnMonth,
            this.ClmnDateOfPayment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgwMembershipFee.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgwMembershipFee.MultiSelect = false;
            this.DgwMembershipFee.Name = "DgwMembershipFee";
            this.DgwMembershipFee.ReadOnly = true;
            this.DgwMembershipFee.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgwMembershipFee.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DgwMembershipFee.RowTemplate.Height = 25;
            this.DgwMembershipFee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ClmnMembershipId
            // 
            resources.ApplyResources(this.ClmnMembershipId, "ClmnMembershipId");
            this.ClmnMembershipId.Name = "ClmnMembershipId";
            this.ClmnMembershipId.ReadOnly = true;
            // 
            // ClmnTypeOfService
            // 
            resources.ApplyResources(this.ClmnTypeOfService, "ClmnTypeOfService");
            this.ClmnTypeOfService.Name = "ClmnTypeOfService";
            this.ClmnTypeOfService.ReadOnly = true;
            // 
            // ClmnAmount
            // 
            resources.ApplyResources(this.ClmnAmount, "ClmnAmount");
            this.ClmnAmount.Name = "ClmnAmount";
            this.ClmnAmount.ReadOnly = true;
            // 
            // ClmnPaid
            // 
            resources.ApplyResources(this.ClmnPaid, "ClmnPaid");
            this.ClmnPaid.Name = "ClmnPaid";
            this.ClmnPaid.ReadOnly = true;
            // 
            // ClmnMonth
            // 
            resources.ApplyResources(this.ClmnMonth, "ClmnMonth");
            this.ClmnMonth.Name = "ClmnMonth";
            this.ClmnMonth.ReadOnly = true;
            // 
            // ClmnDateOfPayment
            // 
            resources.ApplyResources(this.ClmnDateOfPayment, "ClmnDateOfPayment");
            this.ClmnDateOfPayment.Name = "ClmnDateOfPayment";
            this.ClmnDateOfPayment.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(145)))), ((int)(((byte)(77)))));
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.BtnCreateNew);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.BtnLogPayment);
            this.panel2.Controls.Add(this.LbMembership);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox3.Image = global::Vrtic.Properties.Resources.add_button;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // BtnCreateNew
            // 
            resources.ApplyResources(this.BtnCreateNew, "BtnCreateNew");
            this.BtnCreateNew.BackColor = System.Drawing.Color.Transparent;
            this.BtnCreateNew.BorderColor = System.Drawing.Color.Silver;
            this.BtnCreateNew.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnCreateNew.FlatAppearance.BorderSize = 0;
            this.BtnCreateNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnCreateNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnCreateNew.Name = "BtnCreateNew";
            this.BtnCreateNew.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnCreateNew.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnCreateNew.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnCreateNew.TextColor = System.Drawing.Color.Black;
            this.BtnCreateNew.UseVisualStyleBackColor = false;
            this.BtnCreateNew.Click += new System.EventHandler(this.BtnCreateNew_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox2.Image = global::Vrtic.Properties.Resources.floppy_disk;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // BtnLogPayment
            // 
            resources.ApplyResources(this.BtnLogPayment, "BtnLogPayment");
            this.BtnLogPayment.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogPayment.BorderColor = System.Drawing.Color.Silver;
            this.BtnLogPayment.ButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnLogPayment.FlatAppearance.BorderSize = 0;
            this.BtnLogPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnLogPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnLogPayment.Name = "BtnLogPayment";
            this.BtnLogPayment.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.BtnLogPayment.OnHoverButtonColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnLogPayment.OnHoverTextColor = System.Drawing.Color.Black;
            this.BtnLogPayment.TextColor = System.Drawing.Color.Black;
            this.BtnLogPayment.UseVisualStyleBackColor = false;
            this.BtnLogPayment.Click += new System.EventHandler(this.BtnLogPayment_Click);
            // 
            // LbMembership
            // 
            resources.ApplyResources(this.LbMembership, "LbMembership");
            this.LbMembership.Name = "LbMembership";
            // 
            // FrmChild
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmChild";
            this.Resize += new System.EventHandler(this.FrmChild_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgwArrivalDeparture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgwMembershipFee)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox8;
        private ePOSOne.btnProduct.Button_WOC BtnLogDeparture;
        private ePOSOne.btnProduct.Button_WOC BtnLogArrival;
        private Label LbTitle;
        private DataGridView DgwArrivalDeparture;
        private DataGridViewTextBoxColumn ClmnId;
        private DataGridViewTextBoxColumn ClmnChildId;
        private DataGridViewTextBoxColumn ClmnDate;
        private DataGridViewTextBoxColumn ClmnTime;
        private DataGridViewTextBoxColumn ClmArrivalDeparture;
        private Panel panel2;
        private PictureBox pictureBox2;
        private ePOSOne.btnProduct.Button_WOC BtnLogPayment;
        private Label LbMembership;
        private DataGridView DgwMembershipFee;
        private DataGridViewTextBoxColumn ClmnMembershipId;
        private DataGridViewTextBoxColumn ClmnTypeOfService;
        private DataGridViewTextBoxColumn ClmnAmount;
        private DataGridViewTextBoxColumn ClmnPaid;
        private DataGridViewTextBoxColumn ClmnMonth;
        private DataGridViewTextBoxColumn ClmnDateOfPayment;
        private ePOSOne.btnProduct.Button_WOC BtnCreateNew;
        private PictureBox pictureBox3;
        private Label LbUntil;
        private DateTimePicker DtpUntil;
        private ePOSOne.btnProduct.Button_WOC BtnFilter;
        private Label LbFrom;
        private DateTimePicker DtpFrom;
    }
}