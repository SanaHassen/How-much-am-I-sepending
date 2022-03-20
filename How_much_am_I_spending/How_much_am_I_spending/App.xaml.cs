using Model;
using Xamarin.Forms;
using RecordsDB;


namespace How_much_am_I_spending
{
    public partial class App : Application
    {
        public AppManager MyMgr { get; set; } = new AppManager(new RecordsDBManager());

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
           
        }
        


    }
}
