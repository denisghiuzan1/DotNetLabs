using System;
using System.Windows.Forms;

namespace Calculator_y
{
    public partial class Calculator : Form
    {
        private string lastEventText = string.Empty;
        private string operation = string.Empty;
        private bool operation_pressed;
        private double value;
        private bool wasDotPressed;

        public Calculator()
        {
            InitializeComponent();
        }

        private void operator_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;
            operation = b.Text;
            lastEventText = operation;

            if ((result.Text != string.Empty || result.Text == "0") && !operation_pressed)
            {
                value = double.Parse(result.Text);
                operation_pressed = true;
                if (equation.Text.Equals(""))
                    equation.Text = value + operation;
                else
                    equation.Text = equation.Text + operation;
            }
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (operation_pressed)
            {
                equation.Text = string.Empty;

                switch (operation)
                {
                    case "+":
                        result.Text = (value + double.Parse(result.Text)).ToString();
                        break;
                    case "-":
                        result.Text = (value - double.Parse(result.Text)).ToString();
                        break;
                    case "*":
                        result.Text = (value * double.Parse(result.Text)).ToString();
                        break;
                    case "/":
                        result.Text = (value / double.Parse(result.Text)).ToString();
                        break;
                }

                operation_pressed = false;
                lastEventText = "=";
            }
        }

        private void CE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            equation.Text = string.Empty;
            wasDotPressed = false;
            operation_pressed = false;
        }

        private void CButton_Click(object sender, EventArgs e)
        {
            if (result.Text != "0" && result.Text != "")
            {
                if (operation_pressed)
                {
                    if (result.Text != "") result.Text = result.Text.Remove(result.Text.Length - 1);

                    equation.Text = equation.Text.Remove(equation.Text.Length - 1);
                }
                else
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1);
                    if (equation.Text != "") equation.Text = equation.Text.Remove(equation.Text.Length - 1);
                    if (result.Text.Equals("") && equation.Text.Equals("")) CE_Click(sender, e);
                }
            }
            else
            {
                if (equation.Text != "")
                {
                    equation.Text = equation.Text.Remove(equation.Text.Length - 1);

                    if (equation.Text.Length.Equals(1)) CE_Click(sender, e);
                }
            }
        }


        private void numericButton_Click(object sender, EventArgs e)
        {
            if (result.Text.Equals("0") || operation_pressed && result.Text != "0") result.Clear();

            var b = (Button) sender;

            result.Text += b.Text;
            equation.Text += b.Text;
            lastEventText = b.Text;
            //operation_pressed = false;
        }

        private void dot_Click(object sender, EventArgs e)
        {
            var b = (Button) sender;
            if (!wasDotPressed && !operation_pressed)
            {
                result.Text += b.Text;
                if(equation.Text.Equals(""))
                {
                    equation.Text += result.Text;
                }
                else
                {
                    equation.Text += b.Text;
                }
                
                wasDotPressed = true;
                lastEventText = b.Text;
            }
        }
    }
}