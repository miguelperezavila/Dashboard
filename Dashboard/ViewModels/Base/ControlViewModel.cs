using System;
using System.Collections.Generic;
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
    public class ControlViewModel : BaseViewModel
    {

        #region Public Properties


        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }

        public List<Devices> DevicesList { get; set; } = new List<Devices>();

        /// <summary>
        /// A flag indicating that login is running
        /// </summary>
        public bool DeviceIsRunning { get; set; }


        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand DevicesCommand { get; set; }

        public ICommand SettingsCommand { get; set; }

        public ICommand LocationCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControlViewModel()
        {


            // Create commands

            DevicesCommand = new RelayCommand(DevicesViewChange);
            SettingsCommand = new RelayCommand(SettingsViewchange);
            LocationCommand = new RelayCommand(LocationViewchange);

        }


        #endregion

        #region Private Helpers
        
        /// <summary>
        /// Attemps to log the user in 
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password </param>
        /// <returns></returns>
        public void DevicesViewChange()
        {
          ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Control;
        }

        public void SettingsViewchange()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Settings;
        }

        public void LocationViewchange()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Location;
        }
        #endregion
    }
}
