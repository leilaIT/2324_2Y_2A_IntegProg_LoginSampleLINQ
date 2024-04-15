using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _2324_2Y_2A_IntegProg_LoginSampleLINQ
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //allow user to change user name 
        //add log
        //next window (window2) should ask users for new register
        public string newname = "";
        public Window1()
        {
            InitializeComponent();
            tblWelcome.Text = $"Welcome back \n{MainWindow.userName}!";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
        private void btnYesChange_Click(object sender, RoutedEventArgs e)
        {
            txtbChangeUserName.Visibility = Visibility.Visible;
            tblChangeMessage.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            tblAskChange.Visibility = Visibility.Hidden;
            btnYesChange.Visibility = Visibility.Hidden;
            btnNoChange.Visibility = Visibility.Hidden;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button pressed");
            newname = txtbChangeUserName.Text;

            var loginQuery = from s in database._lsDC.LoginUsers
                             where
                                s.Name == MainWindow.userName
                             select s;

            if(loginQuery.Count() == 1)
            {
                foreach (var login in loginQuery)
                {
                    login.Name = newname;
                    login.LastLoginDate = database.cDT;

                    Log log = new Log();
                    log.LoginID = login.LoginID;
                    log.TimeStamp = database.cDT;

                    //database._lsDC.LoginUsers.InsertOnSubmit(login);
                    database._lsDC.Logs.InsertOnSubmit(log);
                    database._lsDC.SubmitChanges();
                }
            }

        }
        private void btnNoChange_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
        }
    }
}
