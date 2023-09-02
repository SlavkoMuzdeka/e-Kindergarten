using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmLogin : Form
    {
        private Thread? thread;
        private string typeOfLanguage;
        private string cbText;

        public FrmLogin(string cbText, string typeOfLanguage)
        {
            //sr-Latn-CS or en
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(typeOfLanguage);
            InitializeComponent();
            tbUserName.Text = "admin";//TODO UKLONIIT
            tbPassword.Text = "admin";//TODO UKLONITI
            cbLanguage.Text = cbText;
            this.typeOfLanguage = typeOfLanguage;
            this.cbText = cbText;
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.Trim();
            string password = tbPassword.Text.Trim();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                if (("sr-Latn-CS").Equals(typeOfLanguage))
                    ShowMessageBox("Pogrešno ste unijeli korisničko ime i/ili lozinku", "Pokušajte ponovo");
                else
                    ShowMessageBox("You have entered your username and/or password incorrectly", "Try again");
            }
            else if(WrapperAdmin.IsCredentialsValid(userName, password))
            {
                Close();
                thread = new Thread(OpenAdminForm);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else if(WrapperUser.IsCredentialsValid(userName, password))
            {
                Close();
                thread = new Thread(OpenUserForm);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                if (("sr-Latn-CS").Equals(typeOfLanguage))
                    ShowMessageBox("Pogrešno ste unijeli korisničko ime i/ili lozinku", "Pokušajte ponovo");
                else
                    ShowMessageBox("You have entered your username and/or password incorrectly", "Try again");
            }
            Focus();
        }

        private void OpenAdminForm(object? obj)
        {
            Application.Run(new FrmAdmin(cbText, typeOfLanguage));
        }

        private void OpenUserForm(object? obj)
        {
            Application.Run(new FrmUser(cbText, typeOfLanguage));
        }

        private static void ShowMessageBox(string str1, string str2)
        {
            MessageBox.Show(str1, str2, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CbLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cbLanguage.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn-CS");
                    this.typeOfLanguage = "sr-Latn-CS";
                    this.cbText = "ser";
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    this.typeOfLanguage = "en";
                    this.cbText = "en";
                    break;
            }
            this.Controls.Clear();
            InitializeComponent();
            tbUserName.Text = "admin"; //TODO UKLONITI
            tbPassword.Text = "admin"; //TODO UKLONITI
            if ("sr-Latn-CS".Equals(this.typeOfLanguage))
                cbLanguage.Text = "ser";
            else
                cbLanguage.Text = "en";
        }
    }
}
