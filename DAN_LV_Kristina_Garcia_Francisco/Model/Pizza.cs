﻿using DAN_LV_Kristina_Garcia_Francisco.DataAccess;
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
        /// List of pizza ingredients
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

        private string totalPrice;
        public string TotalPrice
        {
            get
            {
                List<tblPizzaIngredient> pizzaIngredientList = pizzaIngredientdata.GetAllSelectedPizzaIngredient(PizzaID).ToList();
                List<tblIngredient> allIngredientList = ingredientData.GetAllIngredients().ToList();
                double sum = 0;

                for (int i = 0; i < pizzaIngredientList.Count; i++)
                {
                    for (int j = 0; j < allIngredientList.Count; j++)
                    {
                        if (allIngredientList[j].IngredientID == pizzaIngredientList[i].IngredientID)
                        {
                            sum += double.Parse(allIngredientList[j].IngredientPrice);
                            break;
                        }
                    }

                }

                switch (PizzaSize)
                {
                    case "Big":
                        sum += 799.99;
                        break;
                    case "Small":
                        sum += 199.99;
                        break;
                    case "Medium":
                        sum += 499.99;
                        break;
                    default:
                        break;
                }

                totalPrice = sum.ToString();
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
    }
}
