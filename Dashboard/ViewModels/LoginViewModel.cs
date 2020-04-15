using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dashboard
{
    /// <summary>
    /// The View Model for the w
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member

        #endregion

        #region Public Properties


        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// A flag indicating that login is running
        /// </summary>
        public bool LoginIsRunning { get; set; }


        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {


            // Create commands

            LoginCommand = new RelayParametizedCommand( async(parameter) => await Login(parameter));

        }


        #endregion

        #region Private Helpers
        
        /// <summary>
        /// Attemps to log the user in 
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password </param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {

            await RunCommand(() => this.LoginIsRunning, async () =>
           {
           await Task.Delay(500);

           var username = this.Username;
           var pass = (parameter as IHavePassword).SecurePassword.Unsecure();


               ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).MenuSideWidth = 250;
               ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).MenuSideWidthComplement = 200;
               ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).MenuSideVisibility = Visibility.Visible;
               ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Control;
           });
            

            
        }
        #endregion
    }
}
