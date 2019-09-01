using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    /// <summary>
    /// Contains methods to validate textboxes in windows forms
    /// </summary>
    public static class Validation
    {

        /// <summary>
        /// Tries to parse integer value in textbox and checks if its a valid non-negative whole number.
        /// </summary>
        /// <param name="textbox">The textbox field to try and parse</param>
        /// <returns>Is the value in the textbox a valid non-negative integer?</returns>
        public static bool IsValidNonNegativeInteger(TextBox textbox)
        {
            int value; // Stores value on try Parse
            // If parse is successful, test if value is negative. If unsuccessful, return false.
            if (int.TryParse(textbox.Text.Trim(), out value))
            {
                if (value < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks that textbox contains a positive integer
        /// </summary>
        /// <param name="textbox">Textbox to check</param>
        /// <returns>Is the value in the textbox a valid positive integer?</returns>
        public static bool IsValidPositiveInteger(TextBox textbox)
        {
            int value; // Stores value on try Parse
            // If parse is successful, test if value is not positive. If unsuccessful, return false.
            if (int.TryParse(textbox.Text.Trim(), out value))
            {
                if (value <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks that the textbox has a year thats greater than or equal to the current year
        /// </summary>
        /// <param name="textbox">Textbox to check</param>
        /// <returns>True/false</returns>
        public static bool IsGreaterThanOrEqualToCurrentYear(TextBox textbox)
        {
            int year; // Stores year
            if(int.TryParse(textbox.Text.Trim(), out year))
            {
                if (year >= DateTime.Now.Year) // Checks that the year is equal to or greater than current year
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks that the textbox is not empty
        /// </summary>
        /// <param name="textbox">Textbox to check</param>
        /// <returns>True or false</returns>
        public static bool IsNotEmptyOrNull(TextBox textbox)
        {
            return !String.IsNullOrEmpty(textbox.Text.Trim());
        }

        /// <summary>
        /// Checks if a valid email was entered
        /// </summary>
        /// <param name="textBox">Textbox to check</param>
        /// <returns>True/False</returns>
        public static bool IsValidEmail(TextBox textBox)
        {
            return Regex.IsMatch(textBox.Text.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);           
        }

        /// <summary>
        /// Colors the textbox red if invalid, black if vallid
        /// </summary>
        /// <param name="textBox">Textbox to check</param>
        /// <param name="validationMethod">Method to validate textbox</param>
        public static void ColorTextBoxValidation(TextBox textBox, Func<TextBox, bool> validationMethod)
        {            
            if (validationMethod(textBox))
            {
                textBox.ForeColor = Color.Black;
            }
            else
            {
                textBox.ForeColor = Color.Red;
            }
        }
    }
}
