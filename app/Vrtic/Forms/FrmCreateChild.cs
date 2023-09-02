using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmCreateChild : Form
    {
        private readonly string typeOfLanguage; // Stores the value of the language that was selected at the start of the application
        private readonly bool pom;

        public FrmCreateChild(string typeOfLanguage, bool pom)  
        {
            this.typeOfLanguage = typeOfLanguage;
            InitializeComponent();
            this.pom = pom;
            ColorElements();
        }


        // Creating child account
        /**
         * Function with which we add a new account of the child in BP
         */
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            if (AreFieldsValueCorrect())
            {
                try
                {
                    WrapperChild.InsertChild(new Child(TbJMB.Text, TbFirstName.Text, TbLastName.Text, DtpDateOfBirth.Value, TbAddress.Text,
                    int.Parse(TbHeight.Text), int.Parse(TbWeight.Text)));
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
         * Auxiliary function with which we reset the value of the field for entering data about the child
         */
        private void ClearFileds()
        {
            TbFirstName.Text = "";
            TbLastName.Text = "";
            TbJMB.Text = "";
            TbAddress.Text = "";
            TbAddress.Text = "";
            TbHeight.Text = "";
            TbWeight.Text = "";
        }
        /**
         * A helper function that prints a message, depending on the language, that the child has been successfully added to BP
         */
        private void ShowSuccessfulMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Uspješno ste dodali novo dijete.",
                    "Uspješno kreiranje djeteta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You have successfully added a new user.",
                    "Successfully added new child", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /**
        * Auxiliary function that checks the validity of all fields for entering data about the child
        * It is necessary that the string value is not an empty string or null as well as int and given values
        * The int value must be an integer value, e.g. a letter cannot be passed
        */
        private bool AreFieldsValueCorrect()
        {
            string firstName = TbFirstName.Text;
            string lastName = TbLastName.Text;
            string jmb = TbJMB.Text;
            string address = TbAddress.Text;
            string height = TbHeight.Text;
            string weight = TbWeight.Text;
            string dateOfBirth = DtpDateOfBirth.Text;
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(jmb)
                && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(dateOfBirth) && !string.IsNullOrEmpty(weight))
            {
                try
                {
                    int.Parse(height);
                    int.Parse(weight);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }


        // Functions used to apply the selected theme
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

                BtnAddUser.ButtonColor = colors[0];
                BtnAddUser.OnHoverButtonColor = colors[1];
            }
        }
    
    }
}
