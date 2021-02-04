using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterShop.Models
{
    public class MockCategoryRepository: ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Star Wars", Description="Original Trilogy"},
                new Category{CategoryId=2, CategoryName="The Force Awakens", Description="Sequal Trilogy"},
                new Category{CategoryId=3, CategoryName="Rogue One", Description="A Star Wars Story"},
                new Category{CategoryId=4, CategoryName="The Mandalorian", Description="Star Wars Universe"},
                new Category{CategoryId=5, CategoryName="Original Movie Posters", Description="Original Movie Posters"}
            };
    }
}
