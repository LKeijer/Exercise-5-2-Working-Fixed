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
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Controls
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : Window
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

        // If the user clicks OK to change the password, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            User theCurrentUser;

            if(!(SessionContext.UserRole == Role.Teacher))
            {
                theCurrentUser = SessionContext.CurrentStudent;
            }
            else
            {
                theCurrentUser = SessionContext.CurrentTeacher;
            }

            if (!(theCurrentUser.VerifyPassword(oldPassword.Password.ToString())))
            {
                //return;
                //throw new ArgumentException("The password you provided to be equal to the old password does not match.");
                MessageBox.Show("The old password you provided does not match.", "Password", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
                
            }
            if (string.Compare(newPassword.Password, confirm.Password) != 0)
            {
                //return;
                //throw new ArgumentException("The new password you provided does not match.");
                MessageBox.Show("The new password you provided does not match the confirmation.","Confirm password",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            else
            {
                if(!(theCurrentUser.SetPassword(confirm.Password.ToString())))
                {
                    //return;
                    //throw new Exception("SetPassword method returned false, did not change passwqord!");
                    MessageBox.Show("The method returned false, password not changed", "Error biatch!", MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                    
                }
            }

            




            // TODO: Exercise 2: Task 4a: Get the details of the current user

            // TODO: Exercise 2: Task 4b: Check that the old password is correct for the current user

            // TODO: Exercise 2: Task 4c: Check that the new password and confirm password fields are the same

            // TODO: Exercise 2: Task 4d: Attempt to change the password
            // If the password is not sufficiently complex, display an error message

            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
