using ePOSOne.btnProduct;
using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;
using User = Vrtic.Data.Model.User;

namespace Vrtic.Forms
{
    public partial class FrmAdmin : FrmPerson
    {

        private Thread? thread;
        private readonly string typeOfLanguage;  // Field that stores information about whether the Serbian or English language is selected
        private readonly string cbText;          // The field that stores the value of the selected language on the initial form, if we go back, the value of that field remains as it was at the time of selection

        public FrmAdmin(string cbText, string typeOfLangauge)
        {
            this.typeOfLanguage = typeOfLangauge;
            this.cbText = cbText;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(typeOfLanguage);
            InitializeComponent();
            ColorElements();
            LoadGroups(DgwGroupList, TbFilterGroup.Text);
            lbUserName.Text = WrapperAdmin.LogInAdmin;
        }

        // Working with groups
        /** 
         * A function that enables the creation of a new group, if the button * to create a group is pressed 
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
            string groupName = DgwGroupList.CurrentRow.Cells[1].Value.ToString();
            int groupId = (int)DgwGroupList.CurrentRow.Cells[0].Value;
            new FrmGroup(groupName, typeOfLanguage, groupId, true).Show();
        }
        /**
        * A function to update group data.
        * Updating is done by the administrator changing the name of a group in the table.
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


        // Working with educators
        /**
        * Functionality with the help of which we load the data about all the kindergartens from BP
        * It will be called during filtering, i.e. in the case of searching for the name, surname, social security number or residential address of the teacher.
        */
        private void LoadUsers()
        {
            try
            {
                DgwListUsers.Rows.Clear();
                List<User> users = WrapperUser.GetUsers(TbFindUser.Text);
                foreach (var u in users)
                {
                    DataGridViewRow row = new()
                    {
                        Tag = u,
                        Height = 35
                    };
                    row.CreateCells(DgwListUsers, u.Id, u.FirstName, u.LastName, u.JMB, u.DateOfBirth, u.Address, u.Salary);
                    DgwListUsers.Rows.Add(row);
                }
                if(users.Capacity != 0)
                {
                    DgwListUsers.Columns["ClmnDateOfBirth"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    DgwListUsers.Rows[0].Selected = false;
                }
                DgwListUsers.Columns["ClmnIdUser"].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
        * A function that updates the teacher's data if the data is changed
        * via the displayed table
        */
        private void DgwListUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = (int)DgwListUsers.Rows[e.RowIndex].Cells["ClmnIdUser"].Value;
                string firstName = (string)DgwListUsers.Rows[e.RowIndex].Cells["ClmnFirstName"].Value;
                string lastName = (string)DgwListUsers.Rows[e.RowIndex].Cells["ClmnLastName"].Value;
                string jmb = (string)DgwListUsers.Rows[e.RowIndex].Cells["ClmnJMB"].Value;
                DateTime dateOfBirth = Convert.ToDateTime(DgwListUsers.Rows[e.RowIndex].Cells["ClmnDateOfBirth"].Value);
                string address = (string)DgwListUsers.Rows[e.RowIndex].Cells["ClmnAddress"].Value;
                int salary = Convert.ToInt32(DgwListUsers.Rows[e.RowIndex].Cells["ClmnSalary"].Value);
                try
                {
                    WrapperPerson.UpdatePerson(new Person(id, jmb, firstName, lastName, dateOfBirth, address));
                    WrapperUser.UpdateUserSalary(new User(id, jmb, firstName, lastName, dateOfBirth, address, salary));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /**
        * A function that opens a new form for creating teacher accounts if the button is pressed
        * to create a teacher, which is located in the upper right corner of the student data display.
        */
        private void BtnAddUserForm_Click(object sender, EventArgs e)
        {
            new FrmCreateUser(typeOfLanguage).ShowDialog();
            LoadUsers();
        }
        /**
        * A function that enables the deletion of educators from BP when the administrator selects
        * of the desired teacher and then press the delete button.
        * When deleting, it is necessary to confirm the deletion action.
        */
        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DgwListUsers.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    User user = (User)r.Tag;
                    try
                    {
                        if (AreYouSure(typeOfLanguage))
                        {
                            WrapperUser.DeleteUserById(user.Id);
                            WrapperPerson.DeletePersonById(user.Id);
                            DgwListUsers.Rows.RemoveAt(DgwListUsers.SelectedRows[0].Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /**
        * A function that updates the table containing data on education
        * Filtering is possible on the basis of the first name, last name, social security number and residential address of the educators.
        */
        private void TbFindUser_TextChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }


        // Working with children
        /** 
         * Function used to update the child's data if the data is changed * via the displayed table 
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
            new FrmCreateChild(typeOfLanguage, true).ShowDialog();
            LoadChildren(DgwListChildren, TbFindChild.Text);
        }
        /**
        * A function that enables the deletion of a child from BP when the administrator selects
        * desired child and then press the delete button.
        * When deleting, it is necessary to confirm the deletion action.
        */
        private void BtnDeleteChildForm_Click(object sender, EventArgs e)
        {
            DeleteChild(DgwListChildren, typeOfLanguage);
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
         * double-clicked. * After that, all arrivals and departures of that child are displayed 
         */
        private void DgwListChildren_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int childId = (int)this.DgwListChildren.CurrentRow.Cells[0].Value;
            string firstName = (string)this.DgwListChildren.CurrentRow.Cells[1].Value;
            string lastName = (string)this.DgwListChildren.CurrentRow.Cells[2].Value;
            new FrmChild(typeOfLanguage, childId, firstName, lastName, true).Show();
        }


        // Button actions from the initial form
        /** 
         * Function with which panel3 (for displaying groups) becomes visible inside the initial form on which 
         * there are * 3 panels on the right 
         */
        private void BtnGroups_Click(object sender, EventArgs e)
        {
            LoadGroups(DgwGroupList, TbFilterGroup.Text);
            panel3.Visible = true;
            panel4.Visible = false;
            panel9.Visible = false;
        }
        /** 
         * Functions with which panel4 (to display the teacher) becomes visible inside the initial form where * 
         * there are 3 panels on the right 
         */
        private void BtnUsers_Click(object sender, EventArgs e)
        {
            LoadUsers();
            panel3.Visible = false;
            panel4.Visible = true;
            panel9.Visible = false;
        }
        /** 
         * Function with which panel5 (for displaying children) becomes visible inside the initial form on 
         * which there are * 3 panels on the right 
         */
        private void BtnChildrens_Click(object sender, EventArgs e)
        {
            LoadChildren(DgwListChildren, TbFindChild.Text);
            panel3.Visible = false;
            panel4.Visible = false;
            panel9.Visible = true;
        }
        /**
         * The function that is called if we want to create an account for the teacher * Account creation is
         * done in a new form 
         */
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            new FrmCreateUser(typeOfLanguage).ShowDialog();
            LoadUsers();
        }
        /**
        * The function that is called if we want to create an account for the child
        * Account creation is done in a new form
        */
        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            new FrmCreateChild(typeOfLanguage, true).ShowDialog();
            LoadChildren(DgwListChildren, TbFindChild.Text);
        }
        /**
         * A function that enables closing the initial form and opening the login form.
         */
        private void BtnSignOut_Click(object sender, EventArgs e)
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
            new FrmSettings(typeOfLanguage, true, true).ShowDialog();
        }


        // Helper methods
        /**  
         * Function with which we move the corresponding elements inside the form * when resizing the form 
         */
        private void FrmAdmin_Resize(object sender, EventArgs e)
        {
            TbFilterGroup.Location = new Point(190 + ((panel3.Width - 610) / 2), 121);
            LbFindGroup.Location = new Point(75 + ((panel3.Width - 610) / 2), 124);
            TbFindUser.Location = new Point(190 + ((panel4.Width - 610) / 2), 121);
            LbFindUser.Location = new Point(69 + ((panel4.Width - 610) / 2), 124);
            TbFindChild.Location = new Point(190 + ((panel9.Width - 610) / 2), 121);
            LbFindChild.Location = new Point(75 + ((panel9.Width - 610) / 2), 124);
        }
        /**
        * A function with which we create a login form. It is used inside the BtnSignOut_Click function
        */
        private void OpenLoginForm(object? obj)
        {
            Application.Run(new FrmLogin(cbText, typeOfLanguage));
        }


        // Functions used to apply the selected theme
        private void ColorElements()
        {
            List<Color> colors = WrapperAdmin.GetColor();
            if(colors.Capacity != 0)
            {
                ChangeColorOfPanels(colors[0]);
                ChangeColorOfButtons(colors[1]);
                ChangeColorOfPictureBox(colors[1]);
            }
        }
        private void ChangeColorOfPanels(Color color)
        {
            panel2.BackColor = color;
            panel5.BackColor = color;
            panel6.BackColor = color;
            panel7.BackColor = color;
            panel8.BackColor = color;
            panel10.BackColor = color;
            panel11.BackColor = color;
        }
        private void ChangeColorOfButtons(Color color)
        {
            List<Button_WOC> buttons = new()
            {
                BtnGroups,
                BtnUsers,
                BtnChildrens,
                BtnAddUser,
                BtnAddChild,
                BtnSettings,
                BtnSignOut,
                BtnCreateGroup,
                BtnDeleteGroup,
                BtnDeleteChildForm,
                BtnAddChildForm,
                BtnDeleteChildForm,
                BtnAddUserForm,
                BtnDeleteUser
            };

            foreach (Button_WOC btn in buttons)
            {
                btn.ButtonColor = color;
                btn.OnHoverButtonColor = color;
            }
        }
        private void ChangeColorOfPictureBox(Color color)
        {
            pictureBox2.BackColor = color;
            pictureBox3.BackColor = color;
            pictureBox4.BackColor = color;
            pictureBox5.BackColor = color;
            pictureBox6.BackColor = color;
            pictureBox7.BackColor = color;
            pictureBox8.BackColor = color;
            pictureBox9.BackColor = color;
            pictureBox10.BackColor = color;
            pictureBox11.BackColor = color;
            pictureBox12.BackColor = color;
            pictureBox13.BackColor = color;
            pictureBox14.BackColor = color;
        }

    }
}
