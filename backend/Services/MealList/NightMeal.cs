using GFT.Restaurant.Order.Borders.Services;
using System;
using System.Linq;

namespace GFT.Restaurant.Order.Services.MealList
{
    public class NightMeal : INightMeal
    {
        public string ToMealList(string dish)
        {
            var outputList = "";
            var mealTypes = dish.Replace("night,", "").Replace(" ", "").Split(",");
            var orderedMealTypes = mealTypes.OrderBy(d => d).ToArray();
            var orderedGrouped = orderedMealTypes.GroupBy(d => d).ToArray();
            var allowedTypes = new string[4] { "1", "2", "3", "4" };
            foreach (var dict in orderedGrouped)
            {
                if (outputList.Contains("error")) break;
                if (dict.Count() > 1 && dict.Key == "2")
                {
                    outputList += dishNameNight(dict.Key) + string.Format("(x{0}), ", dict.Count());
                }
                else if (dict.Count() > 1 && allowedTypes.Contains(dict.Key))
                {
                    outputList += dishNameNight(dict.Key) + ", ";
                    outputList += "error, ";
                }
                else
                {
                    outputList += dishNameNight(dict.Key) + ", ";
                }
            }
            return outputList;
        }

        private string dishNameNight(string id)
        {
            return id switch
            {
                "1" => "steak",
                "2" => "potato",
                "3" => "wine",
                "4" => "cake",
                _ => "error",
            };
        }
    }
}
