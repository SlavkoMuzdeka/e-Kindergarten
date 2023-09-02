using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmSettings : FrmPerson
    {
        private readonly string typeOfLanguage;
        private readonly bool type; // Variable indicating whether the credentials for the educator or administrator will be changed
        private readonly bool pom;

        public FrmSettings(string typeOfLanguage, bool type, bool pom)
        {
            InitializeComponent();
            this.typeOfLanguage = typeOfLanguage;
            this.type = type;
            Rb1.Checked = true;
            this.pom = pom;
            ColorElements();
        }

        /**
         * Function with which we change the credentials of the registered user
         */
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            this.UpdateCredentials(TbNewUsername.Text, TbNewPassword.Text, TbConfirmPassword.Text, type, typeOfLanguage);
            TbNewPassword.Text = "";
            TbConfirmPassword.Text = "";
            TbNewUsername.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rb1.Checked && pom)
                    WrapperAdmin.UpdateColor(0);
                else if (Rb1.Checked && !pom)
                    WrapperUser.UpdateColor(0);
                else if (Rb2.Checked && pom)
                    WrapperAdmin.UpdateColor(1);
                else if (Rb2.Checked && !pom)
                    WrapperUser.UpdateColor(1);
                else if (Rb3.Checked && pom)
                    WrapperAdmin.UpdateColor(2);
                else if (Rb3.Checked && !pom)
                    WrapperUser.UpdateColor(2);
                ShowMessage();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void ShowMessage()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Uspješno ste promijenili temu.",
                    "Uspješno promjena", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You have successfully changed the theme.",
                    "Successful change", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                panel2.BackColor = colors[0];

                BtnSave.ButtonColor = colors[1];
                BtnSave.OnHoverButtonColor = colors[1];

                BtnSubmit.ButtonColor = colors[1];
                BtnSubmit.OnHoverButtonColor = colors[1];
            }
        }
    }
}
