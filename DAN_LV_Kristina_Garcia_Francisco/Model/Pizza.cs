using DAN_LV_Kristina_Garcia_Francisco.DataAccess;
using Nedeljni_II_Kristina_Garcia_Francisco.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace DAN_LV_Kristina_Garcia_Francisco.Model
{
    public partial class tblPizza : ViewModelBase
    {
        PizzaIngredientData pizzaIngredientdata = new PizzaIngredientData();
        IngredientData ingredientData = new IngredientData();

        /// <summary>
        /// List of pizza
        /// </summary>
        private string ingredientList;
        public string IngredientList
        {
            get
            {
                List<tblPizzaIngredient> pizzaIngredientList = pizzaIngredientdata.GetAllSelectedPizzaIngredient(PizzaID).ToList();
                List<tblIngredient> allIngredientList = ingredientData.GetAllIngredients().ToList();

                for (int i = 0; i < pizzaIngredientList.Count; i++)
                {
                    for (int j = 0; j < allIngredientList.Count; j++)
                    {
                        if (allIngredientList[j].IngredientID == pizzaIngredientList[i].IngredientID)
                        {
                            ingredientList += allIngredientList[j].IngredientName + ", ";
                            break;
                        }
                    }
                    
                }           

                return ingredientList;
            }
            set
            {
                ingredientList = value;
                OnPropertyChanged("IngredientList");
            }
        }
    }
}
