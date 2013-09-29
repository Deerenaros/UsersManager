using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UsersManager {
    public class UserList: IEnumerable < UserList.User >, INotifyPropertyChanged {
        public class User {
            public String FirstName {
                get;
                set;
            }
            public String LastName {
                get;
                set;
            }
            public String PassportData {
                get;
                set;
            }
            public DateTime Birthsday {
                get;
                set;
            }

            public User ( String firstName, String lastName, String passportData, DateTime birthsday ) {
                FirstName = firstName;
                LastName = lastName;
                PassportData = passportData;
                Birthsday = birthsday;
            }
        }

        private LinkedList< User > myUsers = new LinkedList<User> ();

        public event PropertyChangedEventHandler PropertyChanged;

        public void InsertUser ( User user ) {
            myUsers.AddLast ( user );
            PropertyChanged ( this, new PropertyChangedEventArgs ( "Userlist" ) );
        }

        public void RemoveUser ( User user ) {
            if ( myUsers.Remove ( user ) ) {
                PropertyChanged ( this, new PropertyChangedEventArgs ( "Userlist" ) );
            }
        }

        public IEnumerator < User > GetEnumerator () {
            return myUsers.GetEnumerator ();
        }

        IEnumerator IEnumerable.GetEnumerator () {
            return myUsers.GetEnumerator ();
        }
    }
}
