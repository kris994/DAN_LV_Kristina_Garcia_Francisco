using DAN_LV_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAN_LV_Kristina_Garcia_Francisco.DataAccess
{
    /// <summary>
    /// Class used to create the CRUD structure for Ingredients
    /// </summary>
    class IngredientData
    {
        /// <summary>
        /// Get all data about ingredients from the database
        /// </summary>
        /// <returns>The list of all ingredients</returns>
        public List<tblIngredient> GetAllIngredients()
        {
            try
            {
                using (PizzaPanDBEntities context = new PizzaPanDBEntities())
                {
                    List<tblIngredient> list = new List<tblIngredient>();
                    list = (from x in context.tblIngredients select x).ToList();
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
        /// Adds an ingredient to the database
        /// </summary>
        /// <param name="ingredient">The ingredient ID we are adding or editing</param>
        /// <returns>The new or edited ingredient</returns>
        public tblIngredient AddIngredient(tblIngredient ingredient)
        {
            try
            {
                using (PizzaPanDBEntities context = new PizzaPanDBEntities())
                {
                    tblIngredient newIngredient = new tblIngredient
                    {
                        IngredientName = ingredient.IngredientName
                    };

                    context.tblIngredients.Add(newIngredient);
                    context.SaveChanges();
                    ingredient.IngredientID = newIngredient.IngredientID;

                    return ingredient;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void FillUpDatabase(List<string> list)
        {
            if (GetAllIngredients().Count == 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    tblIngredient ing = new tblIngredient
                    {
                        IngredientName = list[i],
                    };

                    AddIngredient(ing);
                }
            }
        }
    }
}
