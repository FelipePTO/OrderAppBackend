using GFT.Restaurant.Order.Borders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFT.Restaurant.Order.Services.MealList
{
    public class MorningMeal : IMorningMeal
    {
        public string ToMealList(string dish)
        {
            var outputList = "";
            var mealTypes = dish.Replace("morning,", "").Replace(" ", "").Split(",");
            var orderedMealTypes = mealTypes.OrderBy(d => d).ToArray();
            var orderedGrouped = orderedMealTypes.GroupBy(d => d).ToArray();
            var allowedTypes = new string[3] { "1", "2", "3" };
            foreach (var dict in orderedGrouped)
            {
                if (outputList.Contains("error")) break;
                if (dict.Count() > 1 && dict.Key == "3")
                {
                    outputList += dishNameMorning(dict.Key) + string.Format("(x{0}), ", dict.Count());
                }
                else if (dict.Count() > 1 && allowedTypes.Contains(dict.Key))
                {
                    outputList += dishNameMorning(dict.Key) + ", ";
                    outputList += "error, ";
                }
                else
                {
                    outputList += dishNameMorning(dict.Key) + ", ";
                }
            }
            return outputList;
        }

        private string dishNameMorning(string id)
        {
            return id switch
            {
                "1" => "eggs",
                "2" => "toast",
                "3" => "coffee",
                _ => "error",
            };
        }
    }
}
