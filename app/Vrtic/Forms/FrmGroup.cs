using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmGroup : Form
    {
        private readonly string typeOfLanguage;
        private readonly string groupName;
        private readonly int groupId;
        private readonly bool pom;

        public FrmGroup(string groupName, string typeOfLanguage, int groupId, bool pom)  
        {
            InitializeComponent();
            this.groupName = groupName;
            LbGroupName.Text = groupName;
            this.typeOfLanguage = typeOfLanguage;
            this.groupId = groupId;
            this.pom = pom;
            ColorElements();
            LoadChildrenFromGroup(groupId);
            LoadUsersFromGroup(groupId);
        }


        // Working with educators
        /**
         * With the help of this function, we load and tabularly display all educators who belong to a given group
         */
        private void LoadUsersFromGroup(int groupId)
        {
            try
            {
                DgwListUsers.Rows.Clear();
                List<User> users = WrapperUser.GetUsersFromGroup(groupId);
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
                if (users.Capacity != 0)
                {
                    DgwListUsers.Columns["ClmnDateOfBirth"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    DgwListUsers.Rows[0].Selected = false;
                }
                DgwListUsers.Columns["ClmnIdUser"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
        * If we click on the button to add educators to the group, a new form is displayed from which we can choose
        * kindergartners we want to add to that group.
        * Adding educators is done one by one (it is not possible to add more educators to a group at once).
        * After that, the tabular representation of kindergartens is refreshed
        */
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            new FrmChooseUser(typeOfLanguage, groupName, groupId, pom).ShowDialog();
            LoadUsersFromGroup(groupId);
        }
        /**  
         * Functions used to delete educators from a given group. 
         * In order for a tutor to be deleted, it is necessary to select it from the table in which the tutors
         * are displayed 
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
                        if (AreYouSure())
                        {
                            WrapperUser.DeleteUserFromGroup(user.Id, groupId);
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


        // Working with children
        /**
         * The function with which we load and tabularly displays all the children belonging to the given group
         */
        private void LoadChildrenFromGroup(int groupId)
        {
            try
            {
                DgwListChildren.Rows.Clear();
                List<Child> children = WrapperChild.GetChildrenFromGroup(groupId);
                foreach (var c in children)
                {
                    DataGridViewRow row = new()
                    {
                        Tag = c,
                        Height = 35
                    };
                    row.CreateCells(DgwListChildren, c.Id, c.FirstName, c.LastName, c.JMB, c.DateOfBirth, c.Address, c.Height, c.Weight);
                    DgwListChildren.Rows.Add(row);
                }
                if (children.Capacity != 0)
                {
                    DgwListChildren.Columns["ClmnDateOfBirthChild"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    DgwListChildren.Rows[0].Selected = false;
                }
                DgwListChildren.Columns["ClmnIdChild"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
        * If we click on the button to add a child to the group, a new form is displayed from which we can choose
        * the children we want to add to that group.
        * Adding children is done one by one (it is not possible to add more children to the group at once).
        * After that, the tabular display of children is refreshed
        */
        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            new FrmChooseChild(typeOfLanguage, groupName, groupId, pom).ShowDialog();
            LoadChildrenFromGroup(groupId);
        }
        /**
        * A function that allows you to delete a child from a given group.
        * In order for a child to be deleted, it is necessary to select it from the table in which the children are displayed
        */
        private void BtnDeleteChild_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DgwListChildren.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    Child child = (Child)r.Tag;
                    try
                    {
                        if (AreYouSure())
                        {
                            WrapperChild.DeleteChildFromGroup(child.Id, groupId);
                            DgwListChildren.Rows.RemoveAt(DgwListChildren.SelectedRows[0].Index);
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
         * A function that enables the display of a new company after a child is selected from the
         * table and double-clicked. * After that, all arrivals and departures of that child are displayed 
         */
        private void DgwListChildren_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int childId = (int)DgwListChildren.CurrentRow.Cells[0].Value;
            string firstName = (string)DgwListChildren.CurrentRow.Cells[1].Value;
            string lastName = (string)DgwListChildren.CurrentRow.Cells[2].Value;
            new FrmChild(typeOfLanguage, childId, firstName, lastName, pom).Show();
        }


        // Helper methods
        /**
         * Auxiliary function that displays the confirmation, when deleting, in Serbian/English language.
         */
        private bool AreYouSure()
        {
            bool t;
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                t = ConfirmDeleting("Da li ste sigurni?", "Potvrda");
            else
                t = ConfirmDeleting("Are you sure?", "Confirmation");
            return t;
        }
        /**
         * A helper function that prints a confirmation to the user on the screen 
         */
        private static bool ConfirmDeleting(string message, string title)
        {
            if (MessageBox.Show(message, title, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                return true;
            return false;
        }
        /** 
         * Function with which we move the corresponding elements inside the form 
         * when resizing the form 
         */
        private void FrmGroup_Resize(object sender, EventArgs e)
        {
            int pom = (Height - 660) / 2;
            int y = 363 + pom;
            panel3.Location = new Point(3, y);
            panel3.Size = new Size(Width - 21, 255 + pom);
            panel2.Size = new Size(Width - 21, 257 + pom);

            LbUsers.Location = new Point(348 + ((panel2.Width - 779) / 2), 0);
            LbChildren.Location = new Point(348 + ((panel2.Width - 779) / 2), 2);
        }


        // Function used to apply the selected theme
        private void ColorElements()
        {
            List<Color> colors;
            if (pom)
                colors = WrapperAdmin.GetColor();
            else
                colors = WrapperUser.GetColor();
            if (colors.Capacity != 0)
            {
                panel1.BackColor = colors[0];

                BtnAddChild.ButtonColor = colors[1];
                BtnAddChild.OnHoverButtonColor = colors[1];
                BtnAddUser.ButtonColor = colors[1];
                BtnAddUser.OnHoverButtonColor = colors[1];

                BtnDeleteChild.ButtonColor = colors[1];
                BtnDeleteChild.OnHoverButtonColor = colors[1];
                BtnDeleteUser.ButtonColor = colors[1];
                BtnDeleteUser.OnHoverButtonColor = colors[1];

                pictureBox1.BackColor = colors[1];
                pictureBox2.BackColor = colors[1];
                pictureBox3.BackColor = colors[1];
                pictureBox4.BackColor = colors[1];
            }
        }
    
    }
}
