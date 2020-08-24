using DAN_LV_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAN_LV_Kristina_Garcia_Francisco.DataAccess
{
    /// <summary>
    /// Class used to create the CRUD structure for Pizza Ingredients
    /// </summary>
    class PizzaIngredientData
    {
        /// <summary>
        /// Get all data about pizza ingredient from the database
        /// </summary>
        /// <returns>The list of all pizza ingredients</returns>
        public List<tblPizzaIngredient> GetAllPizzaIngredients()
        {
            try
            {
                using (PizzaPanDBEntities context = new PizzaPanDBEntities())
                {
                    List<tblPizzaIngredient> list = new List<tblPizzaIngredient>();
                    list = (from x in context.tblPizzaIngredients select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Adds a pizza ingredient to the database
        /// </summary>
        /// <param name="pizza">The pizza ingredient we are adding or editing</param>
        /// <returns>The new or pizza ingredient</returns>
        public tblPizzaIngredient AddPizzaIngredient(tblPizzaIngredient pizza)
        {
            try
            {
                using (PizzaPanDBEntities context = new PizzaPanDBEntities())
                {
                    tblPizzaIngredient newPizza = new tblPizzaIngredient
                    {
                        PizzaID = pizza.PizzaID,
                        IngredientID = pizza.IngredientID,
                    };

                    context.tblPizzaIngredients.Add(newPizza);
                    context.SaveChanges();
                    pizza.PizzaIngredientID = newPizza.PizzaIngredientID;

                    return pizza;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get all data about ingredients from selected pizza from the database
        /// </summary>
        /// <param name="recipeID">The pizza ID we are getting the ingredients from</param>
        /// <returns>The list of all ingredients from pizza</returns>
        public List<tblPizzaIngredient> GetAllSelectedPizzaIngredient(int pizzaID)
        {
            try
            {
                List<tblPizzaIngredient> list = new List<tblPizzaIngredient>();
                for (int i = 0; i < GetAllPizzaIngredients().Count; i++)
                {
                    if (GetAllPizzaIngredients()[i].PizzaID == pizzaID)
                    {
                        list.Add(GetAllPizzaIngredients()[i]);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
