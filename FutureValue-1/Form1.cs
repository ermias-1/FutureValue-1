using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            /* This program calculates the future value
             * when a user enters the monthly investment amuont,
             * the yearly interest rate and the number of years
             * the investment will be made */

            /* Get the monthly investment amount and the yearly ineterst rate
             * and convert them into decimal */
            decimal monthlyInvestment;
            monthlyInvestment = Decimal.Parse(txtMonthlyInvestment.Text);

            decimal yearlyInterestRate;
            yearlyInterestRate = Decimal.Parse(txtInterestRate.Text);

            // Get the number of years and convert them into months
            int years;
            years = Int32.Parse(txtYears.Text);

            int months;
            months = years * 12;

            /* Calculate the monthly interest rate based on the 
             * yearly interest rate entered by the user */
            decimal monthlyInterestRate;
            monthlyInterestRate = (yearlyInterestRate / 12) / 100;

         

            /* Creating (adding) a new method named CalculateFutureValue
             * with and without using refactoring, and call the method
             * to refactor the calculation in the event handler */
             decimal futureValue = this.CalculateFutureValue(monthlyInvestment, months, monthlyInterestRate);
           /* decimal futureValue = 0m;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate);
            } */


            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
        }

         private decimal CalculateFutureValue(decimal monthlyInvestment, int months, decimal monthlyInterestRate)
        {
            decimal futureValue = 0m;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate);
            }

            return futureValue;
        } 

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Exit from the program when finished the task
            this.Close();
        }

        /* Adding an event handler called ClearFutureValue and 
         * wire this event handler to the TextChanged events of
         * the Monthly Investment and the Yearly Interest Rate text boxes, 
         * which make the value in the Future Value text box be cleared
         * when the values in the first two text boxes are changed

          * In addition wiring the "ClearFuturValue" event handler to
          * the MouseHover event of the Monthly Investment text box to
          * clear the Future Value text box when the mouse hover over this text box */
        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }

        /* Generating an event handler for the entire form - "Form1_DoubleClick", 
         * which makes all the text boxes of the form to an empty string
         * when double-click on the form */
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
            txtMonthlyInvestment.Text = "";
            txtInterestRate.Text = "";
            txtYears.Text = "";

        }

        /* Generating an event handler for the DoubleClick event of the Yearly Interest Rate 
         * text box and set a value in this text box to 12. So, a value of 12 will displayed
         * when doubleclick this text box */
        private void txtInterestRate_DoubleClick(object sender, EventArgs e)
        {
            txtInterestRate.Text = "12";
        }
    }
}
