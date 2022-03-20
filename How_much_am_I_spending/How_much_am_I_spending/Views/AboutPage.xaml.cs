using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Collections.Generic;
using Model;

namespace How_much_am_I_spending.Views
{
    
    public partial class AboutPage : ContentPage
    {
        AppManager mgr => (App.Current as App).MyMgr;


        public AboutPage()
        {
            InitializeComponent();
           
            BindingContext = mgr;

        }

    }
}