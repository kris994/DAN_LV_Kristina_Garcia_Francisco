using DAN_LV_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAN_LV_Kristina_Garcia_Francisco.DataAccess
{
    class PizzaData
    {
        /// <summary>
        /// Get all data about pizza from the database
        /// </summary>
        /// <returns>The list of all pizzas</returns>
        public List<tblPizza> GetAllPizzas()
        {
            try
            {
                using (PizzaPanDBEntities context = new PizzaPanDBEntities())
                {
                    List<tblPizza> list = new List<tblPizza>();
                    list = (from x in context.tblPizzas select x).ToList();
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
        /// Adds a pizza to the database
        /// </summary>
        /// <param name="pizza">The pizza ID we are adding or editing</param>
        /// <returns>The new or pizza ingredient</returns>
        public tblPizza AddPizza(tblPizza pizza)
        {
            try
            {
                using (PizzaPanDBEntities context = new PizzaPanDBEntities())
                {
                    tblPizza newPizza = new tblPizza
                    {
                        PizzaSize = pizza.PizzaSize
                    };

                    context.tblPizzas.Add(newPizza);
                    context.SaveChanges();
                    pizza.PizzaID = newPizza.PizzaID;

                    return pizza;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
