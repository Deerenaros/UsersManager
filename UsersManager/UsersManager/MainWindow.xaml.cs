using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsersManager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public UserList Userlist {
            get;
            set;
        }

        public MainWindow () {
            Userlist = new UserList ();
            InitializeComponent ();
            // This is strange, but DataGrid is not able to setup item source by xaml
            // So, this is setup here
            this.UsersGrid.ItemsSource = Userlist;
            Userlist.PropertyChanged += ( s, e ) => { // dirty update
                this.UsersGrid.ItemsSource = null;
                this.UsersGrid.ItemsSource = Userlist;
            };
        }

        public void AddNew ( Object sender, RoutedEventArgs e ) {
            ( new DialogAdd ( this ) ).ShowDialog ();
        }

        public void DeleteUser ( Object sender, RoutedEventArgs e ) {
            if ( this.UsersGrid.SelectedIndex != -1 ) {
                Userlist.RemoveUser ( this.UsersGrid.SelectedItem as UserList.User );
            }
        }
    }
}