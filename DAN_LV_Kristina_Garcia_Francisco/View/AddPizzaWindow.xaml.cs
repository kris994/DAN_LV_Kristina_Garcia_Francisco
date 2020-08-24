using DAN_LV_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace DAN_LV_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AddPizzaWindow.xaml
    /// </summary>
    public partial class AddPizzaWindow : Window
    {
        public AddPizzaWindow()
        {
            InitializeComponent();
            this.DataContext = new AddPizzaViewModel(this);
        }

        private void DragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                // throw;
            }
        }
    }
}
