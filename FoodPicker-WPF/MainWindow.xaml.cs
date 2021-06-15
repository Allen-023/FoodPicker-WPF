using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodPicker_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        protected List<string> foodItemList = new List<string>();
        
        public MainWindow()
        {
            
            InitializeComponent();
            ReadFile();

        }

        protected override void OnClosing(CancelEventArgs e)
        {


            MessageBoxResult result = MessageBox.Show("Do you want to save your changes before exiting?", "Save and exit", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Saved...Closing...", "Save and exit");
                    WriteFile();
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
                MessageBox.Show("There is currently no food in the list.");
            }

        }

        // Adds user input to the food list then prompts the user.
        private void AddFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (foodItemList.Contains(InputTextBox.Text))
            {
                MessageBox.Show("That food item is has been already added. \nTry another food item.");
            }
            else
            {
                foodItemList.Add(InputTextBox.Text);

                FoodListBox.Items.Add(InputTextBox.Text); //*****************

                MessageBox.Show(InputTextBox.Text + " has been added.");
                InputTextBox.Text = "";
            }

        }

        // Deletes the user input from the food list if it is present then prompts the user.
        private void DeleteFoodButton_Click(object sender, RoutedEventArgs e)
        {
            if (foodItemList.Contains(InputTextBox.Text))
            {

                foodItemList.Remove(InputTextBox.Text);

                FoodListBox.Items.Remove(InputTextBox.Text); //********

                MessageBox.Show(InputTextBox.Text + " has been deleted.");
                InputTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("That food item is has not been added yet.");
            }

        }

        //Writes the list to .txt file
        private void WriteFile()
        {
            TextWriter textw = new StreamWriter("FoodList.txt");

            foreach (string item in foodItemList)
            {
                textw.WriteLine(item);
            }

            textw.Close();
        }

        // Reads the .txt file back to list
        private void ReadFile()
        {
         

            foreach (string line in File.ReadLines("FoodList.txt", Encoding.UTF8))
            {

                foodItemList.Add(line);
                FoodListBox.Items.Add(line);
            }

        }

    }
    
}
