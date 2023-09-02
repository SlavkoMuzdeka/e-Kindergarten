using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmCreateUser : Form
    {
        private readonly string typeOfLanguage; // Saves the value of the language that was selected at the start of the application

        public FrmCreateUser(string typeOfLanguage)
        {
            this.typeOfLanguage = typeOfLanguage;
            InitializeComponent();
            ColorElements();
        }


        // Creting educator account
        /**
         *  A function with the help of which we add a new teacher's account in BP
         */
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (AreFieldsValueCorrect())
            {
                try
                {
                    int personId = WrapperPerson.InsertPerson(new Person(TbJMB.Text, TbFirstName.Text, TbLastName.Text,
                                        DtpDateOfBirth.Value, TbAddress.Text));
                    string password = TbFirstName.Text.Substring(0, 1) + TbLastName.Text.Substring(0, 1) + TbJMB.Text.Substring(7, 6);
                    WrapperUser.InsertUser(new User(personId, int.Parse(TbSalary.Text), TbFirstName.Text, password));
                    ShowSuccessfulMessage();
                    ClearFileds();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ShowUnsuccessfulMessage();
                ClearFileds();
            }
        }


        // Helper methods
        /**
         * Auxiliary function that prints a message, depending on the language, that the teacher has been successfully added to BP
         */
        private void ShowSuccessfulMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Uspješno ste dodali novog vaspitača.",
                    "Uspješno kreiranje vaspitača", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You have successfully added a new user.",
                    "Successfully added new user", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /**
        * An auxiliary function that prints a message in English or Serbian, depending on the selected language, about it
        * that the value of all fields must be filled in and correct
        */
        private void ShowUnsuccessfulMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Vrijednost polja moraju biti ispravna.",
                    "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Value of fields must be correct.",
                    "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /**
         * Auxiliary function with the help of which we reset the value of the field for entering data about the teacher
         */
        private void ClearFileds()
        {
            TbFirstName.Text = "";
            TbLastName.Text = "";
            TbJMB.Text = "";
            TbAddress.Text = "";
            TbAddress.Text = "";
            TbSalary.Text = "";
        }
        /**
          * Auxiliary function that checks the validity of all fields for entering data about the teacher
          * It is necessary that the string value is not an empty string or null as well as int and given values
          * The int value must be an integer value, e.g. a letter cannot be passed
          */
        private bool AreFieldsValueCorrect()
        {
            string firstName = TbFirstName.Text;
            string lastName = TbLastName.Text;
            string jmb = TbJMB.Text;
            string address = TbAddress.Text;
            string salary = TbSalary.Text;
            string dateOfBirth = DtpDateOfBirth.Text;
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(jmb)
                && !string.IsNullOrEmpty(address) && ! string.IsNullOrEmpty(salary) && !string.IsNullOrEmpty(dateOfBirth))
            {
                try
                {
                    int.Parse(salary);
                }catch(Exception)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        // Function used to apply the selected theme
        private void ColorElements()
        {
            List<Color> colors = WrapperAdmin.GetColor();
            if (colors.Capacity != 0)
            {
                panel1.BackColor = colors[0];
                BtnAddUser.ButtonColor = colors[1];
                BtnAddUser.OnHoverButtonColor = colors[1];
            }
        }

    }
}
