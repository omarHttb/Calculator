using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator__TheDeviceOfTheCentury
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        enum enBeforeOrAfterCalculation 
        {
            BeforeCalculation,
            AfterCalculation
        }

        enum EnWhatIsClickedAfter
        {
            NothingClicked,
            NumberClicked,
            OpperatorClicked,
            BackSpace,
            // To DO: FIX THE BACKSPACE Problem
            // 2nd: make number appear after calculation when clicking on number
            // see the logic
            // 3rd add the function of what happens if you click any opperator buttons after Calculation
           
        }

        EnWhatIsClickedAfter whatIsClicked = EnWhatIsClickedAfter.NothingClicked;
        enBeforeOrAfterCalculation beforeOrAfterCalculation = enBeforeOrAfterCalculation.BeforeCalculation;
            

        public char CharacterChangeOperation = '+';

        //1 means Number 1 and 2 means change to number 2 of the equation
        public char CharacterNum1OrNum2 = '1';
        public string Num1 = "";
        public string Num2 = "";
        public string TextNum2 = "";
        public string ResultString = "";
        public string TempNumber = "";
        public double ResultDouble = 0;

        // adding number code logic
        public bool IsNum2()
        {
            if (CharacterNum1OrNum2 == '2')
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {

            if (Num2 != "")
            {
                TempNumber = Num2.Substring(Num2.Length - 1);
            }
            Num1 = "";
            Num2 = "";
            TextNum2 = "";
            ResultString = "";
            ResultDouble = 0;
            TxtNumbersAndOperations.Text = "";
            if (whatIsClicked == EnWhatIsClickedAfter.NumberClicked)
            {
                CharacterChangeOperation = '+';
                CharacterNum1OrNum2 = '1';

                whatIsClicked = EnWhatIsClickedAfter.NothingClicked;
                beforeOrAfterCalculation = enBeforeOrAfterCalculation.BeforeCalculation;
                Num1 = TempNumber;
                TxtNumbersAndOperations.Text += Num1;
            }
            else if(whatIsClicked == EnWhatIsClickedAfter.OpperatorClicked)
            {
                whatIsClicked = EnWhatIsClickedAfter.NothingClicked;
                beforeOrAfterCalculation = enBeforeOrAfterCalculation.BeforeCalculation;

            }
            else
            {
                CharacterNum1OrNum2 = '1';

                TxtReuslt.Text = "";
                CharacterChangeOperation = '+';
                beforeOrAfterCalculation = enBeforeOrAfterCalculation.BeforeCalculation;
            }

        }

        public string ChangeNumber(Button btn)
        {
            return btn.Tag.ToString();
        }

        public void isNumberEmpty()
        {
            if(Num1 == "")
            {
                Num1 = "0";
            }
            if(Num2 == "")
            {
                Num2 = "0";
            }
        }
        
        public void AfterCalculationOperation()
        {
            //logic after any operation is clicked
            Num1 = TxtReuslt.Text;
            TxtNumbersAndOperations.Text += Num1;

        }
        //adding numbers code here
        private void BtnNum_Click(object sender, EventArgs e)
        {
            
            if (!IsNum2())
            {
                Num1 += ChangeNumber((Button)sender);
                TxtNumbersAndOperations.Text = Num1;
            }
            else
            {
                TextNum2 += ChangeNumber((Button)sender);
                Num2 += TextNum2;
                TxtNumbersAndOperations.Text += TextNum2;
                TextNum2 = "";
            }
            if(beforeOrAfterCalculation == enBeforeOrAfterCalculation.AfterCalculation)
            {
                whatIsClicked = EnWhatIsClickedAfter.NumberClicked;
                Clear();
            }
        }





        // the operations are here
        private void BtnSum_Click(object sender, EventArgs e)
        {

            if(beforeOrAfterCalculation == enBeforeOrAfterCalculation.AfterCalculation)
            {

                whatIsClicked = EnWhatIsClickedAfter.OpperatorClicked;
                Clear();
                AfterCalculationOperation();
                TxtNumbersAndOperations.Text += " + ";
                CharacterChangeOperation = '+';
                CharacterNum1OrNum2 = '2';

            }
            else
            {
                CharacterChangeOperation = '+';
                CharacterNum1OrNum2 = '2';
                TxtNumbersAndOperations.Text += " + ";

            }
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {

            if (beforeOrAfterCalculation == enBeforeOrAfterCalculation.AfterCalculation)
            {
                whatIsClicked = EnWhatIsClickedAfter.OpperatorClicked;
                Clear();
                AfterCalculationOperation();
                TxtNumbersAndOperations.Text += " - ";
                CharacterChangeOperation = '-';
                CharacterNum1OrNum2 = '2';
            }
            else
            {
                CharacterChangeOperation = '-';
                TxtNumbersAndOperations.Text += " - ";
                CharacterNum1OrNum2 = '2';

            }
        }

        private void BtnMultipication_Click(object sender, EventArgs e)
        {

            if (beforeOrAfterCalculation == enBeforeOrAfterCalculation.AfterCalculation)
            {
                whatIsClicked = EnWhatIsClickedAfter.OpperatorClicked;
                Clear();
                AfterCalculationOperation();
                TxtNumbersAndOperations.Text += " X ";
                CharacterChangeOperation = '*';
                CharacterNum1OrNum2 = '2';
            }
            else
            {
                CharacterChangeOperation = '*';
                TxtNumbersAndOperations.Text += " X ";
                CharacterNum1OrNum2 = '2';
            }
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {

            if (beforeOrAfterCalculation == enBeforeOrAfterCalculation.AfterCalculation)
            {
                whatIsClicked = EnWhatIsClickedAfter.OpperatorClicked;
                Clear();
                AfterCalculationOperation();
                TxtNumbersAndOperations.Text += " / ";
                CharacterChangeOperation = '/';
                CharacterNum1OrNum2 = '2';
            }
            else
            {
                CharacterChangeOperation = '/';
                TxtNumbersAndOperations.Text += " / ";
                CharacterNum1OrNum2 = '2';
            }
        }

       
        public void OperationResult()
        {
            if (CharacterChangeOperation == '+')
            {
                ResultDouble = Convert.ToDouble(Num1) + Convert.ToDouble(Num2);
            }
            else if (CharacterChangeOperation == '-')
            {
                ResultDouble = Convert.ToDouble(Num1) - Convert.ToDouble(Num2);
            }
            else if (CharacterChangeOperation == '*')
            {
                ResultDouble = Convert.ToDouble(Num1) * Convert.ToDouble(Num2);
            }
            else if (CharacterChangeOperation == '/')
            {
                ResultDouble = Convert.ToDouble(Num1) / Convert.ToDouble(Num2);
            }
        }

        // the next step is to solve what happens after calculation!
        private void BtnEqual_Click(object sender, EventArgs e)
        {

                isNumberEmpty();
                OperationResult();
                ResultString = Convert.ToString(ResultDouble);
                TxtReuslt.Text = ResultString;
            beforeOrAfterCalculation = enBeforeOrAfterCalculation.AfterCalculation;


        }

        private void BtnBackSpace_Click(object sender, EventArgs e)
        {
            if (!IsNum2())
            {
                if (Num1 != "")
                {
                    Num1 = Num1.Substring(0, Num1.Length - 1);
                    TxtNumbersAndOperations.Text = Num1;
                }
                else if (Num1 == "")
                {
                    Num1 = "";
                }
            }
            else
            {
                if (Num2 != "")
                {
                    Num2 = Num2.Substring(0, Num2.Length - 1);
                    TxtNumbersAndOperations.Text = TxtNumbersAndOperations.Text.Substring(0, TxtNumbersAndOperations.Text.Length - 1);
                }
                else if(Num2 == "")
                {
                    Num2 = "";

                    TxtNumbersAndOperations.Text = TxtNumbersAndOperations.Text.Substring(0, TxtNumbersAndOperations.Text.Length - 3);

                    CharacterNum1OrNum2 = '1';

                }

            }
            if (beforeOrAfterCalculation == enBeforeOrAfterCalculation.AfterCalculation)
            {
                beforeOrAfterCalculation = enBeforeOrAfterCalculation.BeforeCalculation;
            }
        }


        // For testing Purposes Delete AFTER FINISH 
        private void txtnum1_TextChanged(object sender, EventArgs e)
        {
            txtnum1.Text = Num1;
        }

        private void txtnum2_TextChanged(object sender, EventArgs e)
        {
            txtnum2.Text = Num2;
        }

        private void TxtNumbersAndOperations_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


    }
}
