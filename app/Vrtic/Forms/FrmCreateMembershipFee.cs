using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmCreateMembershipFee : Form
    {

        private readonly string typeOfLanguage;
        private readonly int childId;
        private readonly bool pom;

        public FrmCreateMembershipFee(string typeOfLanguage, int childId, bool pom)
        {
            InitializeComponent();
            this.typeOfLanguage = typeOfLanguage;
            this.childId = childId;
            this.pom = pom;
            ColorElements();
        }

        /**
         * A function with which we create a new membership fee for a given child
         */
        private void BtnAddMembershipFee_Click(object sender, EventArgs e)
        {
            if (AreFieldsValuesCorrect())
            {
                try
                {
                    if(WrapperMembershipFee.InsertMembershipFee(new MembershipFee(TbTypeOfService.Text, int.Parse(TbAmount.Text), RbYes.Checked, DtpMonth.Value, childId)))
                    {
                        ShowSuccessfulMessage();
                        ClearFileds();
                    }
                }
                catch (Exception ex)
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
         * A function with which we check the correctness of field values when creating a new membership fee
         */
        private bool AreFieldsValuesCorrect()
        {
            string typeOfService = TbTypeOfService.Text;
            string amount = TbAmount.Text;
            string month = DtpMonth.Text;
            if(!string.IsNullOrEmpty(typeOfService) && !string.IsNullOrEmpty(amount) && !string.IsNullOrEmpty(month)
                && (RbYes.Checked || RbNo.Checked))
            {
                try
                {
                    int.Parse(amount);
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
         * Auxiliary function with the help of which we reset the value of the field for entering data on the membership fee
         */
        private void ClearFileds()
        {
            TbTypeOfService.Clear();
            TbAmount.Clear();
            RbYes.Checked = false;
            RbNo.Checked = false;
        }
        /**
         * Auxiliary function that prints a message, depending on the language, that the membership fee has been successfully added to BP
         */
        private void ShowSuccessfulMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Uspješno ste kreirali novu članarinu.",
                    "Uspješno kreiranje članarine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You have successfully added a new membership fee.",
                    "Successfully added new membership fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                BtnAddMembershipFee.ButtonColor = colors[1];
                BtnAddMembershipFee.OnHoverButtonColor = colors[1];
            }
        }

    }
}
