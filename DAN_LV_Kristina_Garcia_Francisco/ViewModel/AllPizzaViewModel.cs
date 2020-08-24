using DAN_LV_Kristina_Garcia_Francisco.Command;
using DAN_LV_Kristina_Garcia_Francisco.DataAccess;
using DAN_LV_Kristina_Garcia_Francisco.Model;
using DAN_LV_Kristina_Garcia_Francisco.View;
using Nedeljni_II_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DAN_LV_Kristina_Garcia_Francisco.ViewModel
{
    class AllPizzaViewModel : ViewModelBase
    {
        readonly AllPizzaWindow allPizzaWindow;
        PizzaData pizzaData = new PizzaData();

        #region Constructor
        /// <summary>
        /// Constructor with the AllPizzaWindow info window opening
        /// </summary>
        /// <param name="allPizzaWindowOpen">opends the window</param>
        public AllPizzaViewModel(AllPizzaWindow allPizzaWindowOpen)
        {
            allPizzaWindow = allPizzaWindowOpen;
            PizzaList = pizzaData.GetAllPizzas().ToList();
        }
        #endregion

        #region Property
        /// <summary>
        /// List of pizza
        /// </summary>
        private List<tblPizza> pizzaList;
        public List<tblPizza> PizzaList
        {
            get
            {
                return pizzaList;
            }
            set
            {
                pizzaList = value;
                OnPropertyChanged("PizzaList");
            }
        }

        /// <summary>
        /// Specific Pizza
        /// </summary>
        private tblPizza pizza;
        public tblPizza Pizza
        {
            get
            {
                return pizza;
            }
            set
            {
                pizza = value;
                OnPropertyChanged("Pizza");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Add Pizza button
        /// </summary>
        private ICommand addPizza;
        public ICommand AddPizza
        {
            get
            {
                if (addPizza == null)
                {
                    addPizza = new RelayCommand(param => AddPizzaExecute(), param => CanAddPizzaExecute());
                }
                return addPizza;
            }
        }

        /// <summary>
        /// Method for adding a new pizza
        /// </summary>
        public void AddPizzaExecute()
        {
            try
            {
                AddPizzaWindow addPizzaWindow = new AddPizzaWindow();
                addPizzaWindow.ShowDialog();

                PizzaList = pizzaData.GetAllPizzas().ToList();
            }
            catch (Exception)
            {
                MessageBoxResult dialog = MessageBox.Show("Currently cannot add the pizza...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Checks if its possible to press the add button
        /// </summary>
        /// <returns></returns>
        public bool CanAddPizzaExecute()
        {
            return true;
        }

        /// <summary>
        /// Exit button
        /// </summary>
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exits the current window
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (dialog == MessageBoxResult.Yes)
            {
                allPizzaWindow.Close();
            }
        }

        /// <summary>
        /// Checks if its possible to press the button
        /// </summary>
        /// <returns></returns>
        private bool CanExitExecute()
        {
            return true;
        }
        #endregion
    }
}
