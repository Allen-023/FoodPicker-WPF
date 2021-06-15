using System.Linq;
using System.Windows;

namespace FoodPicker_WPF
{
    public class Validate : MainWindow
    {
        // Input validation check
        public static bool InputValidationCheck(string input)
        {

            if (foodItemList.Contains(input))
            {
                MessageBox.Show("That food item is has been already added. \nTry another food item.", "Error");
                return false;
            }
            else if (input == "")
            {
                MessageBox.Show("Input field is blank. \nTry a food item.", "Error");
                return false;
            }
            else if (input.Any(char.IsDigit))
            {
                MessageBox.Show("Foods don't have numbers. \nTry a food item.", "Error");
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
