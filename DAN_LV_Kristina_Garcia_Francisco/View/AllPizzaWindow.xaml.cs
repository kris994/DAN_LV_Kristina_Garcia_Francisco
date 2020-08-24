using DAN_LV_Kristina_Garcia_Francisco.ViewModel;
using System.Windows;

namespace DAN_LV_Kristina_Garcia_Francisco.View
{
    /// <summary>
    /// Interaction logic for AllPizzaWindow.xaml
    /// </summary>
    public partial class AllPizzaWindow : Window
    {
        public AllPizzaWindow()
        {
            InitializeComponent();
            this.DataContext = new AllPizzaViewModel(this);
        }
    }
}
