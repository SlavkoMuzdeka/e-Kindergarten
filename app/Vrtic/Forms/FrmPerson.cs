using Microsoft.VisualBasic;
using Vrtic.Data.Model;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmPerson : Form
    {

        // Working with groups
        public static void LoadGroups(DataGridView dgw, string filter)
        {
            try
            {
                dgw.Rows.Clear();
                List<Group> groups = WrapperGroup.GetGroups(filter);
                foreach (var g in groups)
                {
                    DataGridViewRow row = new()
                    {
                        Tag = g,
                        Height = 35
                    };
                    row.CreateCells(dgw, g.Id, g.Name, g.NumberOfMembers);
                    dgw.Rows.Add(row);
                }
                if (groups.Capacity != 0)
                    dgw.Rows[0].Selected = false;
                dgw.Columns["ClmnIdGroup"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CreateGroup(string typeOfLanguage, DataGridView dgw)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
            {
                string value = Interaction.InputBox("Unesite naziv grupe", "Kreiranje grupe", "", 500, 300);
                if (!"".Equals(value) && WrapperGroup.InsertGroup(new Group(value, 0)))
                {
                    LoadGroups(dgw, "");
                    MessageBox.Show("Uspješno ste kreirali grupu pod imenom " + value,
                   "Uspješno kreiranje grupe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string value = Interaction.InputBox("Enter a name for the group", "Create group", "", 500, 300);
                if (!"".Equals(value) && WrapperGroup.InsertGroup(new Group(value, 0)))
                {
                    LoadGroups(dgw, "");
                    MessageBox.Show("You have successfully created a group with a name " + value,
                   "Successfully created new group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void DeleteGroup(DataGridView dgw, string typeOfLanguage)
        {
            foreach (DataGridViewRow r in dgw.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    Group group = (Group)r.Tag;
                    if (group.NumberOfMembers > 0)
                        MessageCannotDelete(typeOfLanguage);
                    else
                    {
                        if (AreYouSure(typeOfLanguage))
                        {
                            try
                            {
                                WrapperGroup.DeleteGroupById(group.Id);
                                LoadGroups(dgw, "");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        public static void UpdateGroup(DataGridView dgw, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int pomId = (int)dgw.Rows[e.RowIndex].Cells["ClmnIdGroup"].Value;
                string newName = (string)dgw.Rows[e.RowIndex].Cells["ClmnName"].Value;
                int numberOfMembers = (int)dgw.Rows[e.RowIndex].Cells["clmnMembers"].Value;
                try
                {
                    WrapperGroup.UpdateGroup(new Group(pomId, newName, numberOfMembers));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Working with children
        /**
        * Functionality with which we load data on all children from BP
        * It will be called during filtering, i.e. in the case of searching for the child's name, surname, social security number or residential address
        */
        public static void LoadChildren(DataGridView dgw, string filter)
        {
            try
            {
                dgw.Rows.Clear();
                List<Child> children = WrapperChild.GetChildren(filter);
                foreach (var c in children)
                {
                    DataGridViewRow row = new()
                    {
                        Tag = c,
                        Height = 35
                    };
                    row.CreateCells(dgw, c.Id, c.FirstName, c.LastName, c.JMB, c.DateOfBirth, c.Address, c.Height, c.Weight);
                    dgw.Rows.Add(row);
                }
                if (children.Capacity != 0)
                {
                    dgw.Columns["ClmnDateOfBirthChild"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    dgw.Rows[0].Selected = false;
                }
                dgw.Columns["ClmnIdChild"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateChild(DataGridView dgw, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int childId = (int)dgw.Rows[e.RowIndex].Cells["ClmnIdChild"].Value;
                string firstName = (string)dgw.Rows[e.RowIndex].Cells["ClmnNameChild"].Value;
                string lastName = (string)dgw.Rows[e.RowIndex].Cells["ClmnSurnameChild"].Value;
                string jmb = (string)dgw.Rows[e.RowIndex].Cells["ClmnJMBChild"].Value;
                DateTime dateOfBirth = Convert.ToDateTime(dgw.Rows[e.RowIndex].Cells["ClmnDateOfBirthChild"].Value);
                string address = (string)dgw.Rows[e.RowIndex].Cells["ClmnAddressChild"].Value;
                int height = Convert.ToInt32(dgw.Rows[e.RowIndex].Cells["ClmnHeightChild"].Value);
                int weight = Convert.ToInt32(dgw.Rows[e.RowIndex].Cells["ClmnWeightChild"].Value);
                try
                {
                    WrapperChild.UpdateChild(new Child(childId, jmb, firstName, lastName, dateOfBirth, address, height, weight));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteChild(DataGridView dgw, string typeOfLanguage)
        {
            foreach (DataGridViewRow r in dgw.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    Child child = (Child)r.Tag;
                    try
                    {
                        if (AreYouSure(typeOfLanguage))
                        {
                            WrapperArrivalAndDeparture.DeleteArrivalsAndDepartures(child.Id);
                            WrapperMembershipFee.DeleteMembershipFees(child.Id);
                            WrapperChild.DeleteChildById(child.Id);
                            WrapperPerson.DeletePersonById(child.Id);
                            dgw.Rows.RemoveAt(dgw.SelectedRows[0].Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
        // Method for changing credentials
        public void UpdateCredentials(string userName, string password, string password2, bool type, string typeOfLanguage)
        {
            if (AreValuesCorrect(userName, password, password2))
            {
                try
                {
                    WrapperPerson.UpdateCredentials(userName, password, type);
                    ShowMessage(typeOfLanguage);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                ShowUnsuccessfulMessage(typeOfLanguage);
        }


        // Helper methods
        /**
        * Auxiliary function that displays the message, depending on the selected language (Serbian/English),
        * about the impossibility of deleting the group because there are members within the group.
        * Note: A group can be deleted only if the number of members of that group = 0
        */
        private static void MessageCannotDelete(string typeOfLanguage)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Da biste obrisali grupu, neophodno je da nema članova unutar te grupe",
                    "Brisanje neuspješno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("To delete a group, it is necessary that there are no members within that group",
                    "Deletion failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /**
         * Helper function that displays confirmation, when deleting, in Serbian/English language.
         */
        public static bool AreYouSure(string typeOfLanguage)
        {
            bool t = false;
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
         * Functionality with the help of which we check whether the user has entered a username and password, a confirmation password
         * and checking whether the password and confirmation password are the same
         */
        private static bool AreValuesCorrect(string newUserName, string newPassword, string newPassword1)
        {
            if (!string.IsNullOrEmpty(newUserName) && !string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(newPassword)
                && newPassword.Equals(newPassword1))
                return true;
            else
                return false;
        }
        /**
         * Helper function with which we check that the credentials have been changed successfully
         */
        private static void ShowMessage(string typeOfLanguage)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Kredencijali su uspješno promijenjeni.",
                    "Uspješna promjena kredencijala", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Credentials have been successfully changed.",
                    "Successful credential change", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /**
        * An auxiliary function that prints a message in English or Serbian, depending on the selected language, about it
        * that the value of all fields must be filled in and correct
        */
        private static void ShowUnsuccessfulMessage(string typeOfLanguage)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Vrijednost polja moraju biti ispravna.",
               "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Value of fields must be correct.",
               "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
