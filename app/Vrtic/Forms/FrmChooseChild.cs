using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmChooseChild : Form
    {
        private readonly string typeOfLanguage; // Stores a value indicating which language the user has selected
        private readonly int groupId;           // Stores the id of the selected group
        private readonly bool pom;

        public FrmChooseChild(string typeOfLanguage, string groupName, int groupId, bool pom)
        {
            InitializeComponent();
            this.typeOfLanguage = typeOfLanguage;
            this.groupId = groupId;
            this.pom = pom;
            LbTitle.Text = LbTitle.Text + " " + groupName;
            ColorElements();
            LoadChildren();
        }


        // Working with children
        /**
        * Functionality with which we load data on all children from BP
        * It will be called during filtering, i.e. in the case of searching for the child's name, surname, social security number or residential address
        */
        private void LoadChildren()
        {
            try
            {
                DgwListChildren.Rows.Clear();
                List<Child> children = WrapperChild.GetChildren(TbFindChild.Text);
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
                MessageBox.Show(ex.Message, "Pokušajte ponovooooo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
        * Function with which we filter children according to some criteria
        * Filtering is enabled by first name, last name, jmb and home address of the teacher
        */
        private void TbFindChild_TextChanged(object sender, EventArgs e)
        {
            LoadChildren();
        }
        /**
        * Function with which we add the selected child to the given group
        * The child must be selected first and then press the button to add to the group
        */
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DgwListChildren.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    Child child = (Child)r.Tag;
                    try
                    {
                        WrapperChild.InsertChildIntoGroup(child.Id, groupId, typeOfLanguage);
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
        * Auxiliary function to display a message about the success of adding a child to the group
        * The message will be written either in Serbian or in English, depending on it
        * what the user initially selected
        */
        private void ShowMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Uspješno ste dodali dijete u grupu",
                    "Uspješno dodavanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You've successfully added a child to the group.",
                    "Successfully add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /**
         * An auxiliary function with which we place the title of this page in the middle
         */
        private void FrmChooseChild_Resize(object sender, EventArgs e)
        {
            LbTitle.Location = new Point(183 + ((panel1.Width - 800) / 2), 27);
        }

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
