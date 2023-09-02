using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmChooseUser : Form
    {
        private readonly string typeOfLanguage;  // Stores a value indicating which language the user has selected
        private readonly int groupId;            // Stores the id of the selected group
        private readonly bool pom;

        public FrmChooseUser(string typeOfLanguage, string groupName, int groupId, bool pom)
        {
            InitializeComponent();
            this.typeOfLanguage = typeOfLanguage;
            this.groupId = groupId;
            LbTitle.Text = LbTitle.Text + " " + groupName;
            this.pom = pom;
            ColorElements();
            LoadUsers();
        }


        // Working with educators
        /**
         * With the help of this function, we load all the teachers from BP and display them in a table
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
        * Function with the help of which we filter kindergartens according to some criteria
        * Filtering is enabled by first name, last name, jmb and home address of the teacher
        */
        private void TbFindUser_TextChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }
        /**
        * Function with the help of which we add the selected teacher to the given group
        * The teacher must be selected first and then press the button to add to the group
        */
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DgwListUsers.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    User user = (User)r.Tag;
                    try
                    {
                        WrapperUser.InsertUserIntoGroup(user.Id, groupId, typeOfLanguage);
                        ShowMessage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        // Helper methods
        /**
        * Auxiliary function to display a message about the success of adding educators to the group
        * The message will be written either in Serbian or in English, depending on it
        * what the user initially selected
        */
        private void ShowMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Uspješno ste dodali vaspitača u grupu",
                    "Uspješno dodavanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You've successfully added a user to the group.",
                    "Successfully add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /**
         * An auxiliary function with which we place the title of this page in the middle
         */
        private void FrmChooseUser_Resize(object sender, EventArgs e)
        {
            LbTitle.Location = new Point(183 + ((panel1.Width - 800) / 2), 27);
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
                BtnAdd.BackColor = colors[1];
            }
        }
    }
}
