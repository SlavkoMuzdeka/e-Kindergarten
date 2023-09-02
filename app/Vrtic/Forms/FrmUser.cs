using ePOSOne.btnProduct;
using Vrtic.Data.MySql;

namespace Vrtic.Forms
{
    public partial class FrmUser : FrmPerson
    {

        private Thread? thread;
        private readonly string typeOfLanguage; // Field that stores information about whether the Serbian or English language is selected
        private readonly string cbText;         // The field that stores the value of the selected language on the initial form, if we go back the value of that field remains as it was at the time of selection

        public FrmUser(string cbText, string typeOfLanguage)
        {
            this.typeOfLanguage = typeOfLanguage;
            this.cbText = cbText;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(this.typeOfLanguage);
            InitializeComponent();
            LoadGroups(DgwGroupList, TbFilterGroup.Text);
            LbUserName.Text = WrapperUser.LogInUser;
            ColorElements();
        }

        // Working with groups
        /**
         * A function that enables the creation of a new group, if the button
         * to create a group is pressed
         */
        private void BtnCreateGroup_Click(object sender, EventArgs e)
        {
            CreateGroup(typeOfLanguage, DgwGroupList);
        }
        /**
        * Function with which we delete the selected group from the table of groups.
        * To delete a group, it must first be selected.
        * The group cannot be deleted if there are members in it.
        * When deleting, you are asked if you really want to delete the group.
        */
        private void BtnDeleteGroup_Click(object sender, EventArgs e)
        {
            DeleteGroup(DgwGroupList, typeOfLanguage);
        }
        /**
        * If we double-click on a group when displaying the table in which the groups are located, then it opens
        * new form for displaying information about that group
        */
        private void DgwGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string groupName = this.DgwGroupList.CurrentRow.Cells[1].Value.ToString();
            int groupId = (int)this.DgwGroupList.CurrentRow.Cells[0].Value;
            new FrmGroup(groupName, typeOfLanguage, groupId, false).Show();
        }
        /**
        * A function to update group data.
        * Updating is done by the teacher changing the name of a group in the table.
        * Only group name updating is enabled.
        * The number of group members is automatically incremented or decremented depending
        * whether members are added or deleted from the group, respectively
        */
        private void DgwGroupList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateGroup(DgwGroupList, e);
        }
        /**
          * A function that enables the display of filtered groups by group name
          */
        private void TbFilterGroup_TextChanged(object sender, EventArgs e)
        {
            LoadGroups(DgwGroupList, TbFilterGroup.Text);
        }


        // Working with children
        /**
         * Function used to update the child's data if the data is changed
         * via the displayed table 
         */
        private void DgwListChildren_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateChild(DgwListChildren, e);
        }
        /**
        * A function that opens a new form for creating a child's account if the button is pressed
        * to create a child that is located in the upper right corner of the child data display.
        */
        private void BtnAddChildForm_Click(object sender, EventArgs e)
        {
            new FrmCreateChild(typeOfLanguage, false).ShowDialog();
            LoadChildren(DgwListChildren, TbFindChild.Text);
        }
        /**
        * This function enables filtering the list of children by first name, last name, social security number or residential address
        */
        private void TbFindChild_TextChanged(object sender, EventArgs e)
        {
            LoadChildren(DgwListChildren, TbFindChild.Text);
        }
        /** 
         * A function that enables the display of a new company after a child is selected from the table and 
         * double-clicked. After that, all arrivals and departures of that child are displayed 
         */
        private void DgwListChildren_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int childId = (int)DgwListChildren.CurrentRow.Cells[0].Value;
            string firstName = (string)DgwListChildren.CurrentRow.Cells[1].Value;
            string lastName = (string)DgwListChildren.CurrentRow.Cells[2].Value;
            new FrmChild(typeOfLanguage, childId, firstName, lastName, false).Show();
        }


        // Actions on buttons from the initial form
        /**
        * Functionality with the help of which panel3 (for displaying groups) becomes visible inside the initial form on which they are located
        * 2 panels on the right
        */
        private void BtnGroups_Click(object sender, EventArgs e)
        {
            LoadGroups(DgwGroupList, TbFilterGroup.Text);
            panel3.Visible = true;
            panel9.Visible = false;
        }
        /** 
         * Function with which panel5 (for displaying children) becomes visible inside the initial form 
         * on which there are 2 panels on the right 
         */
        private void BtnChildrend_Click(object sender, EventArgs e)
        {
            LoadChildren(DgwListChildren, TbFindChild.Text);
            panel3.Visible = false;
            panel9.Visible = true;
        }
        /**
         * A function that enables closing the initial form and opening the login form.
         */
        private void BtnLogOff_Click(object sender, EventArgs e)
        {
            Close();
            thread = new Thread(OpenLoginForm);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        /**
        * A function that allows changing the theme as well as changing the password
        */
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            new FrmSettings(typeOfLanguage, false, false).ShowDialog();
        }



        // Helper methods
        /**
        * A function with which we create a login form. It is used inside the BtnLogOff_Click function
        */
        private void OpenLoginForm(object? obj)
        {
            Application.Run(new FrmLogin(cbText, typeOfLanguage));
        }
        /**
         * Function with which we move the corresponding elements inside the form 
         * when resizing the form 
         */
        private void FrmUser_Resize(object sender, EventArgs e)
        {
            TbFilterGroup.Location = new Point(190 + ((panel3.Width - 610) / 2), 121);
            LbFindGroup.Location = new Point(75 + ((panel3.Width - 610) / 2), 124);
            TbFindChild.Location = new Point(190 + ((panel9.Width - 610) / 2), 121);
            LbFindChild.Location = new Point(75 + ((panel9.Width - 610) / 2), 124);
        }


        // Functions used to apply the selected theme
        private void ColorElements()
        {
            List<Color> colors = WrapperUser.GetColor();
            if (colors.Capacity != 0)
            {
                ChangeColorOfPanels(colors[0]);
                ChangeColorOfButtons(colors[1]);
                ChangeColorOfPictureBox(colors[1]);
            }
        }
        private void ChangeColorOfPanels(Color color)
        {
            panel1.BackColor = color;
            panel5.BackColor = color;
            panel6.BackColor = color;
            panel10.BackColor = color;
            panel11.BackColor = color;
        }
        private void ChangeColorOfButtons(Color color)
        {
            List<Button_WOC> buttons = new()
            {
                BtnGroups,
                BtnSettings,
                BtnCreateGroup,
                BtnDeleteGroup,
                BtnAddChildForm,
                BtnChildrend,
                BtnLogOff
            };

            foreach (Button_WOC btn in buttons)
            {
                btn.ButtonColor = color;
                btn.OnHoverButtonColor = color;
            }
        }
        private void ChangeColorOfPictureBox(Color color)
        {
            pictureBox1.BackColor = color;
            pictureBox2.BackColor = color;
            pictureBox3.BackColor = color;
            pictureBox4.BackColor = color;
            pictureBox8.BackColor = color;
            pictureBox9.BackColor = color;
            pictureBox12.BackColor = color;
            pictureBox14.BackColor = color;
        }
    }
}
