using DAN_LV_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace DAN_LV_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AddPizzaWindow.xaml
    /// </summary>
    public partial class AddPizzaWindow : Window
    {
        /// <summary>
        /// Add pizza window
        /// </summary>
        public AddPizzaWindow()
        {
            InitializeComponent();
            this.DataContext = new AddPizzaViewModel(this);
        }

        /// <summary>
        /// Drag window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
