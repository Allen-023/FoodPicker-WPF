using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;


namespace FoodPicker_WPF
{
    public partial class MainWindow : Window
    {

        public static List<string> foodItemList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            WriteAndReadFile.ReadFile(FoodListBox);

        }

        // Prompts user end dialog and saves data accordingly.
        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save your changes before exiting?", "Save and exit", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Saved...Closing...", "Save and exit");
                    WriteAndReadFile.WriteFile();
                    e.Cancel = false;
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Closing...", "Save and exit");
                    e.Cancel = false;
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Going back...", "Save and exit");
                    e.Cancel = true;
                    break;

            }

        }

        // Generate a random int. Use the random number for an index of the food list and display to user.
        private void PickButton_Click(object sender, RoutedEventArgs e)
        {
            if (foodItemList.Count != 0)
            {
                Random rndNum = new Random();
                int randomNumber = rndNum.Next(0, foodItemList.Count());

                OutputTextBox.Text = foodItemList[randomNumber].ToString();
            }
            else
            {
                MessageBox.Show("There is currently no food in the list.", "Error");
            }

        }

        // Adds user input to the food list then prompts the user.
        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate.InputValidationCheck(InputTextBox.Text) == true)
            {
                foodItemList.Add(InputTextBox.Text.Trim());
                FoodListBox.Items.Add(InputTextBox.Text.Trim());

                MessageBox.Show(InputTextBox.Text.Trim() + " has been added.", "Added");
            }

            InputTextBox.Text = "";

        }

        // Deletes the user input from the food list if it is present then prompts the user.
        private void DeleteFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (foodItemList.Contains(InputTextBox.Text))
            {
                foodItemList.Remove(InputTextBox.Text);
                FoodListBox.Items.Remove(InputTextBox.Text);

                MessageBox.Show(InputTextBox.Text + " has been deleted.", "Deleted");
            }
            else
            {
                MessageBox.Show("That food item is has not been added yet.", "Error");
            }

            InputTextBox.Text = "";

        }



    }
}
