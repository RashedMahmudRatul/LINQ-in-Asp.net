using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App11_LINQ3.Models;
using Microsoft.AspNetCore.Mvc;

namespace App11_LINQ3.Controllers
{
    public class LINQController : Controller
    {
        public IActionResult Index()
        {
            Recipe[] recipes =
            {
                new Recipe{Id = 1, Name= "Plain Rice"},
                new Recipe{Id = 2, Name= "Pizza"},
                new Recipe{Id = 3, Name= "Chotpoti"},
                new Recipe{Id = 3, Name= "Kabab"}
            };

            Review[] reviews =
           {
                new Review{RecipeId = 1, ReviewText= "Excellent"},
                new Review{RecipeId = 1, ReviewText= "Nice"},
                new Review{RecipeId = 1, ReviewText= "Very Good"},
                new Review{RecipeId = 2, ReviewText= "Essentiual"},
                new Review{RecipeId = 2, ReviewText= "Pretty"},
                new Review{RecipeId = 3, ReviewText= "Not so Good.."},
                new Review{RecipeId = 3, ReviewText= "So So"},
                new Review{RecipeId = 4, ReviewText= "Most Exciting"},
                new Review{RecipeId = 4, ReviewText= "Very Tasty"}
            };

            var reviewresult = from recipe in recipes
                               join review in reviews on recipe.Id equals review.RecipeId
                               into reviewgroup
                               select new
                               {
                                   RecipeName = recipe.Name,
                                   Reviews = reviewgroup
                               };
            List<string> reviewlist = new List<string>();
            foreach (var item in reviewresult)
            {
                reviewlist.Add(item.RecipeName+ " : ");

                foreach (var n in item.Reviews)
                {
                    reviewlist.Add("\t"+ n.ReviewText);
                }
            }



            return View(reviewlist);
        }

        public IActionResult Eample17()
        {

            Ingredient[] ingredients =
            {
                new Ingredient{Name = "Sugar", Calories = 500},
                new Ingredient{Name = "Egg", Calories = 100},
                new Ingredient{Name = "Milk", Calories = 150},
                new Ingredient{Name = "Flour", Calories = 50},
                new Ingredient{Name = "Butter", Calories = 200}
            };

            var highcaloriesingredient = ingredients.Where(x => x.Calories >= 150)
                                          .OrderBy(x => x.Name)
                                          .Select(x => x.Name);

            //var highcaloriesingredient = from i in ingredients
            //                             where i.Calories >= 150
            //                             orderby i.Name
            //                             select i.Name;

            List<string> result = new List<string>();
            foreach (var item in highcaloriesingredient)
            {
                result.Add(item.ToString());
            }




            return View(result);
        }


    }
}