using DAN_LV_Kristina_Garcia_Francisco.Command;
using DAN_LV_Kristina_Garcia_Francisco.DataAccess;
using DAN_LV_Kristina_Garcia_Francisco.Model;
using DAN_LV_Kristina_Garcia_Francisco.View;
using Nedeljni_II_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_LV_Kristina_Garcia_Francisco.ViewModel
{
    class AddPizzaViewModel : ViewModelBase
    {
        readonly AddPizzaWindow addPizzaWindow;
        PizzaData pizzaData = new PizzaData();
        IngredientData ingredientData = new IngredientData();
        PizzaIngredientData pizzaIngredientData = new PizzaIngredientData();

        /// <summary>
        /// Ingredient List
        /// </summary>
        private readonly List<string> ingredientList = new List<string> { "Salama", "Ham", "Kulen", "Ketchup", "Majo", "Chilli Papper", "Olive", "Oregano", "Sesame", "Cheese" };

        #region Constructor
        /// <summary>
        /// Opens the Add Pizzawindow
        /// </summary>
        /// <param name="addPizzaOpen">Window that we open</param>
        public AddPizzaViewModel(AddPizzaWindow addPizzaOpen)
        {
            pizza = new tblPizza();
            addPizzaWindow = addPizzaOpen;
        }
        #endregion

        #region Property
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
        /// Save button
        /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        public List<string> FillList()
        {
            List<string> ingredientName = new List<string>();

            if (addPizzaWindow.cbSalama.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbSalama.Content.ToString());
            }
            if (addPizzaWindow.cbHam.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbHam.Content.ToString());
            }
            if (addPizzaWindow.cbKulen.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbKulen.Content.ToString());
            }
            if (addPizzaWindow.cbKetchup.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbKetchup.Content.ToString());
            }
            if (addPizzaWindow.cbMajo.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbMajo.Content.ToString());
            }
            if (addPizzaWindow.cbChiliP.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbChiliP.Content.ToString());
            }
            if (addPizzaWindow.cbOlive.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbOlive.Content.ToString());
            }
            if (addPizzaWindow.cbOregano.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbOregano.Content.ToString());
            }
            if (addPizzaWindow.cbSesame.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbSesame.Content.ToString());
            }
            if (addPizzaWindow.cbCheese.IsChecked == true)
            {
                ingredientName.Add(addPizzaWindow.cbCheese.Content.ToString());
            }

            return ingredientName;
        }

        /// <summary>
        /// Method for adding new Ingredients
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                ingredientData.FillUpDatabase(ingredientList);
                List<tblIngredient> ingredientsList = ingredientData.GetAllIngredients().ToList();

                pizzaData.AddPizza(Pizza);

                for (int i = 0; i < ingredientsList.Count; i++)
                {
                    for (int j = 0; j < FillList().Count; j++)
                    {
                        if (ingredientsList[i].IngredientName == FillList()[j])
                        {
                            tblPizzaIngredient item = new tblPizzaIngredient()
                            {
                                PizzaID = Pizza.PizzaID,
                                IngredientID = ingredientsList[i].IngredientID
                            };

                            pizzaIngredientData.AddPizzaIngredient(item);
                            break;
                        }
                    }
                }

                addPizzaWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if it is possible to click on the button
        /// </summary>
        /// <returns></returns>
        private bool CanSaveExecute()
        {
            if (!String.IsNullOrEmpty(Pizza.PizzaSize) && FillList().Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Close button
        /// </summary>
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// Exit window
        /// </summary>
        private void CloseExecute()
        {
            MessageBoxResult dialog = MessageBox.Show("Are you sure you want to exit? \nAll data will be lost.", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (dialog == MessageBoxResult.Yes)
            {
                addPizzaWindow.Close();
            }

            try
            {
                addPizzaWindow.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if it is possible to click on the button
        /// </summary>
        /// <returns></returns>
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
