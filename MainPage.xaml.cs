using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CanteenBillSystemUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ArrayList pricearraylist = new ArrayList() { 10, 20, 30, 40 };
        int sum = 0;
        int count = 0;

        public MainPage()
        {
            this.InitializeComponent();

            this.select_item_ComboBox.Items.Add("Chocolate");
            this.select_item_ComboBox.Items.Add("Lays");
            this.select_item_ComboBox.Items.Add("Coke");
            this.select_item_ComboBox.Items.Add("Cup Noodles");

            
        }

        private void select_item_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getpricev2();
        }
        public void getpricev2()
        {
            for (int i = 0; i < pricearraylist.Count; i++)
            {
                if (i == this.select_item_ComboBox.SelectedIndex)
                {
                    this.price_TextBox.Text = pricearraylist[i].ToString();
                }
            }
        }

        private void calculate_Button_Click(object sender, RoutedEventArgs e)
        {
           if (this.price_TextBox.Text != "" && this.quantity_TextBox.Text != "")
                displayData(int.Parse(this.quantity_TextBox.Text));
        }

        public void displayData(int quantity)
        {
            // item list 
            this.item_list_ListBox.Items.Add(this.select_item_ComboBox.SelectedItem);

            // price list
            this.price_list_ListBox.Items.Add(this.price_TextBox.Text);

            // quantity list
            this.quantity_list_ListBox.Items.Add(this.quantity_TextBox.Text);

            // total list
            this.total_list_ListBox.Items.Add(int.Parse(this.price_TextBox.Text) * int.Parse(this.quantity_TextBox.Text));

            //this.totalV2_textbox.Text = (int.Parse(this.totalV2_textbox.Text) + int.Parse(this.total_list_ListBox.Items[i])).ToString();

            // implementaion for total amount
            sum = sum + (int)this.total_list_ListBox.Items[count];
            count++;

            // dieplay the total
            this.totalV2_textbox.Text = sum.ToString();


            // clear
            this.select_item_ComboBox.Text = "";
            this.price_TextBox.Text = "";
            this.quantity_TextBox.Text = "";

        }

        private void select_item_add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.add_Items_TextBox.Text != "" && this.add_price_TextBox.Text != "")
            {
                this.select_item_ComboBox.Items.Add(this.add_Items_TextBox.Text);
                this.pricearraylist.Add(int.Parse(this.add_price_TextBox.Text));

                

                this.add_Items_TextBox.Text = "";
                this.add_price_TextBox.Text = "";
            }
        }

       
    }
}
