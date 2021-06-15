using System.IO;
using System.Text;
using System.Windows.Controls;

namespace FoodPicker_WPF
{
    public class WriteAndReadFile : MainWindow
    {
        //Writes the list to .txt file
        public static void WriteFile()
        {
            TextWriter textw = new StreamWriter("FoodList.txt");

            foreach (string item in foodItemList)
            {
                textw.WriteLine(item);
            }

            textw.Close();
        }

        // Reads the .txt file back to list
        public static void ReadFile(ListBox FoodListBox)
        {
            foreach (string line in File.ReadLines("FoodList.txt", Encoding.UTF8))
            {
                foodItemList.Add(line);
                FoodListBox.Items.Add(line);
            }
        }

    }


}
