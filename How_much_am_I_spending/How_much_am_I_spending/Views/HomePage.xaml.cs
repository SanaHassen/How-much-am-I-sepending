using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using Model;

namespace How_much_am_I_spending.Views
{
    public partial class HomePage : ContentPage
    {
        AppManager mgr => (App.Current as App).MyMgr;


        public HomePage()
        {
            InitializeComponent();
            BindingContext = mgr;
          
        }

        private void ADD_Clicked(object sender, EventArgs e)
        {
            try
            {
                mgr.AddRecord(new Record(float.Parse(moneyEntry.Text), descriptionEntry.Text,DateTime.Now.ToString("MMMM")));
            }
            catch
            {}
           
        }
        

        private void Delete_Clicked(object sender, EventArgs e)
        {
            Record ToBeDeleted = (Record)((Button)sender).CommandParameter;
            mgr.RemoveRecord(ToBeDeleted);
        }
    }
}