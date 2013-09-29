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
using System.Windows.Shapes;

namespace UsersManager {
    /// <summary>
    /// Interaction logic for DialogAdd.xaml
    /// </summary>
    public partial class DialogAdd : Window {
        public DialogAdd ( Window owner ) {
            this.Owner = owner;
            InitializeComponent ();
        }

        private class InvalidBirthsday : Exception {
            public InvalidBirthsday ( String mess ) : base ( mess ) {
            }
        }

        private void Validate () {
            if ( DateTime.Now.Year - this.Birthsday.SelectedDate.Value.Year < 18 ) {
                throw new InvalidBirthsday ( "Not 18 year old yet!" );
            }
        }

        private void Confirm ( object sender, RoutedEventArgs e ) {
            try {
                Validate ();
                MainWindow main = this.Owner as MainWindow;
                main.Userlist.InsertUser ( new UserList.User (
                    this.FirstName.Text,
                    this.LastName.Text,
                    this.MultipassportData.Text,
                    this.Birthsday.SelectedDate.Value
                ) );
                this.Close ();
            } catch ( InvalidBirthsday exception ) {
                Error.Content = exception.Message;
            }
        }

        private void Cancel ( object sender, RoutedEventArgs e ) {
            this.Close ();
        }
    }
}
