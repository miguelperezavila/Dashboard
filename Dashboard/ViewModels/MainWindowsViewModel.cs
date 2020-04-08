using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dashboard
{
    public class MainWindowsViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 0;

        /// <summary>
        /// The radious of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion


        #region Public Properties


        /// <summary>
        /// Minimum Window Width
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// Minimum Widnow height
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless { get { return ((mWindow.WindowState == WindowState.Maximized) || (mDockPosition != WindowDockPosition.Undocked)); } }

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The paddind of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        public bool LoginAttachmentVisibility { get; set; }
        /// <summary>
        /// The margin around the window for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(mOuterMarginSize);

        /// <summary>
        /// The radious of the edges of the window
        /// </summary>
        public int WindowsRadius
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radious of the edges of the window
        /// </summary>
        public CornerRadius WindowsCornerRadius => new CornerRadius(mWindowRadius);
        /// <summary>
        /// The height of the title bar/ caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar/ caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }
        #endregion

        #region Commands

        public ICommand MinimizeCommand 
        { 
            get; 
            set;
        }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        public ICommand LoginCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public MainWindowsViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing 

            mWindow.StateChanged += (sender, e) =>
            {
                //Fire off events for all properties that are affected by resize
                OnPropertyChanged(nameof(Borderless));
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowsRadius));
                OnPropertyChanged(nameof(WindowsCornerRadius));
                OnPropertyChanged(nameof(LoginAttachmentVisibility));

            };

            // create Commands;

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
            LoginCommand = new RelayCommand(LoginAttachmentButtonCommand);
        }
        #endregion

        #region Private helpers 

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion

        public void LoginAttachmentButtonCommand()
        {
            LoginAttachmentVisibility ^= true;
        }

        #region Command Methods


        #endregion

    }
}
