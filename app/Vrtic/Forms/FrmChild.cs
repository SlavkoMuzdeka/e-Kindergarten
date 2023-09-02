using Vrtic.Data.Model;
using Vrtic.Data.MySql;
using Vrtic.Data.Wrapper;

namespace Vrtic.Forms
{
    public partial class FrmChild : Form
    {
        private readonly int childId;
        private readonly string typeOfLanguage;
        private readonly bool pom;

        public FrmChild(string typeOfLanguage, int childId, string firstName, string lastName, bool pom)
        {
            this.childId = childId;
            this.typeOfLanguage = typeOfLanguage;
            this.pom = pom;
            InitializeComponent();
            ColorElements();
            LbTitle.Text += firstName + " " + lastName;
            LbMembership.Text += firstName + " " + lastName;
            LoadDepartureAndArrivalTime(true);
            LoadMembershihFees();
        }


        // Working with arrival and departure times
        /**
        * Functionality with the help of which we tabulate the departures and arrivals of the selected child
        * Data is loaded from BP and displayed in the form of date, time and type that tells if it is
        * arrival or departure in question
        */
        private void LoadDepartureAndArrivalTime(bool pom)
        {
            try
            {
                List<DepartureAndArrivalTime> departureAndArrivalTimes;
                DgwArrivalDeparture.Rows.Clear();
                if (pom)
                    departureAndArrivalTimes = WrapperArrivalAndDeparture.GetArrivalAndDeparture(childId);
                else
                    departureAndArrivalTimes = WrapperArrivalAndDeparture.GetArrivalAndDepartureFilter(childId, DtpFrom.Value, DtpUntil.Value);
                foreach (var dA in departureAndArrivalTimes)
                {
                    DataGridViewRow row = new()
                    {
                        Tag = dA,
                        Height = 35
                    };
                    var dateOnly = dA.RecordedTime.ToShortDateString();
                    var timeOnly = dA.RecordedTime.ToShortTimeString();
                    var type = dA.Type;
                    var arrivalDeparture = DetermineArrivalOrDeparture(type);
                    row.CreateCells(DgwArrivalDeparture, dA.Id, dA.ChildId, dateOnly, timeOnly, arrivalDeparture);
                    DgwArrivalDeparture.Rows.Add(row);
                }
                if (departureAndArrivalTimes.Capacity != 0)
                    DgwArrivalDeparture.Rows[0].Selected = false;
                DgwArrivalDeparture.Columns["ClmnId"].Visible = false;
                DgwArrivalDeparture.Columns["ClmnChildId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /**
         * The function with which we register the arrival of the child
         */
        private void BtnLogArrival_Click(object sender, EventArgs e)
        {
            WrapperArrivalAndDeparture.InsertTime(childId, 0);
            LoadDepartureAndArrivalTime(true);
        }
        /**
         * Funkcija pomocu koje evidentiramo odlazak djeteta
         */
        private void BtnLogDeparture_Click(object sender, EventArgs e)
        {
            WrapperArrivalAndDeparture.InsertTime(childId, 1);
            LoadDepartureAndArrivalTime(true);
        }


        // Working with membership fees
        /**
         * A function with the help of which we tabulate all the membership fees of the selected child
         */
        private void LoadMembershihFees()
        {
            try
            {
                DgwMembershipFee.Rows.Clear();
                List<MembershipFee> membershipFees = WrapperMembershipFee.GetMembershipFees(childId);
                foreach (var mF in membershipFees)
                {
                    DataGridViewRow row = new()
                    {
                        Tag = mF,
                        Height = 35
                    };
                    if (mF.IsPaid)
                    {
                        string paid = GetPaid(mF.IsPaid);
                        row.CreateCells(DgwMembershipFee, mF.Id, mF.Type, mF.Amount, paid, mF.MonthToPay, mF.DateOfPayment);
                    }
                    else
                    {
                        string paid = GetPaid(mF.IsPaid);
                        row.CreateCells(DgwMembershipFee, mF.Id, mF.Type, mF.Amount, paid, mF.MonthToPay, "/");
                    }
                    DgwMembershipFee.Rows.Add(row);
                }
                if (membershipFees.Capacity != 0)
                {
                    DgwMembershipFee.Columns["ClmnDateOfPayment"].DefaultCellStyle.Format = "MM/dd/yyyy";
                    DgwMembershipFee.Columns["ClmnMonth"].DefaultCellStyle.Format = "MM/yyyy";
                    DgwMembershipFee.Rows[0].Selected = false;
                }
                DgwMembershipFee.Columns["ClmnMembershipId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        * A function with the help of which we modify the membership fee to be paid
        * In order to do this, it is necessary to select the membership fee that has not been paid and then press the button
        * for "save change"
        */
        private void BtnLogPayment_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DgwMembershipFee.Rows)
            {
                if (r.Selected == true && r.Tag != null)
                {
                    MembershipFee mF = (MembershipFee)r.Tag;
                    try
                    {
                        if (mF.IsPaid)
                            MessageCannotUpdate();
                        else
                        {
                            WrapperMembershipFee.UpdateMembershipFee(mF.Id, childId);
                            LoadMembershihFees();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Pokušajte ponovo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /*
         * A function with which we create a new membership fee for a given child
         */
        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            new FrmCreateMembershipFee(typeOfLanguage, childId, pom).ShowDialog();
            LoadMembershihFees();
        }


        // Helper methods
        /**
        * An auxiliary function with the help of which we determine whether it is a question of departure and arrival
        * Depending on the selected language, departure/arrival will be written in the selected language
        */
        private string DetermineArrivalOrDeparture(int type)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
            {
                if(type == 1)
                    return "Odlazak";
                else
                    return "Dolazak";
            }
            else
            {
                if(type == 1)
                    return "Departure";
                else
                    return "Arrival";
            }
        }
        /** 
         * Function with which we move the corresponding elements inside the form * when resizing the form 
         */
        private void FrmChild_Resize(object sender, EventArgs e)
        {
            LbTitle.Location = new Point(0 + (((this.Width - 30) - 761) / 2), 28);
            LbMembership.Location = new Point(0 + (((this.Width - 30) - 761) / 2), 28);
            LbFrom.Location = new Point(167 + ((this.Width - 822) / 2), 118);
            LbUntil.Location = new Point(465 + ((this.Width - 822) / 2), 118);
            DtpFrom.Location = new Point(218 + ((this.Width - 822) / 2), 115);
            DtpUntil.Location = new Point(511 + ((this.Width - 822) / 2), 115);
        }
        /**
        * Auxiliary function that returns a string indicating whether the membership fee has been paid or not
        * Depending on the language, a message will be written in the table in Serbian/English
        */
        private string GetPaid(bool pay)
        {
            if (pay)
            {
                if (("sr-Latn-CS").Equals(typeOfLanguage))
                    return "Jeste";
                else
                    return "Yes";

            }
            else
            {
                if (("sr-Latn-CS").Equals(typeOfLanguage))
                    return "Nije";
                else
                    return "No";
            }
        }
        /**
        * A function that prints a message in Serbian/English that the membership fee has already been paid
        * if an attempt is made to record that the membership fee has been paid
        */
        private void MessageCannotUpdate()
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
                MessageBox.Show("Članarina je već plaćena za taj mjesec.",
                    "Ažuriranje neuspješno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("The membership fee has already been paid for that month.",
                    "Update failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                BtnCreateNew.ButtonColor = colors[1];
                BtnCreateNew.OnHoverButtonColor = colors[1];

                BtnLogPayment.ButtonColor = colors[1];
                BtnLogPayment.OnHoverButtonColor = colors[1];

                BtnLogArrival.ButtonColor = colors[1];
                BtnLogArrival.OnHoverButtonColor = colors[1];

                BtnLogDeparture.ButtonColor = colors[1];
                BtnLogDeparture.OnHoverButtonColor = colors[1];

                BtnFilter.ButtonColor = colors[1];
                BtnFilter.OnHoverButtonColor = colors[1];
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadDepartureAndArrivalTime(false);
        }
    }
}
