using System;
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
using DevExpress.Xpo;
using FirstXafProject.Orm;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NuevoUno.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell
    {
        public Shell()
        {
            this.InitializeComponent();
          
            this.LoadData.Click += LoadDataFromServer;
        }
    
        private async void LoadDataFromServer(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var Ds = new DevExpress.Xpo.DB.InMemoryDataStore(DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema, true);
                XpoHelper.InitXpo(Ds);

                BoLogic.CreateCustomer(1, "Joche Ojeda");
                BoLogic.CreateCustomer(2, "Jaime Macias");
                BoLogic.CreateCustomer(3, "Javier Columbie");
                BoLogic.CreateCustomer(4, "Rafael Gonzales");
                BoLogic.CreateCustomer(5, "Rocco Ojeda");
                BoLogic.CreateInvoice(new System.DateTime(2020, 1, 1), 1);

                var Count = XpoHelper.CreateUnitOfWork().Query<Invoice>().Count();
                Console.WriteLine("Its working");
                this.LoadData.Content = "Its working";
                XPCollection<Customer> customer = new XPCollection<Customer>(XpoHelper.CreateUnitOfWork());
                this.MasterListView.ItemsSource = customer;
            }
            catch (Exception ex)
            {
                var messsa = ex.Message;
                throw ex;
            }

        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // throw new NotImplementedException();
        }
    }
}
