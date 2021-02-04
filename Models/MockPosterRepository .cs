using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterShop.Models
{
    public class MockPosterRepository : IPosterRepository
    {
        private readonly ICategoryRepository categoryRepository = new MockCategoryRepository();

        public IEnumerable<Poster> AllPosters =>
            new List<Poster>
            {
                new Poster {PosterId = 1, Name="Ahsoka Tano", Price=5.99M,
                    ShortDescription="Ahsoka Tano is a former Jedi Padawan.",
                    LongDescription="Ahsoka Tano was a former Jedi Padawan who, after the Clone Wars, helped establish a network of various rebel cells against the Galactic Empire. A Togruta female, Tano was discovered on her homeworld of Shili by Jedi Master Plo Koon, who brought her to the Jedi Temple on Coruscant to receive training",
                    Category = categoryRepository.AllCategories.ToList()[3],ImageUrl="~/images/Ahsoka.jpg", InStock=true, IsPosterOfTheWeek=false},

                new Poster {PosterId = 2, Name="Bo-Katan Kryze", Price=3.99M,
                    ShortDescription="Bo-Katan Kryze is a Mandalorian.",
                    LongDescription="Bo-Katan Kryze was a Mandalorian human female who was the leader of the Nite Owls and a lieutenant in Death Watch, a terrorist group, and later during the Imperial Era, became Mand'alor. During the Clone Wars, Kryze's sister, Satine, ruled as the Duchess of Mandalore.",
                    Category = categoryRepository.AllCategories.ToList()[3],ImageUrl="~/images/BoKatan.jpg", InStock=true, IsPosterOfTheWeek=false},

                 new Poster {PosterId = 3, Name="Cara Dune", Price=3.99M,
                    ShortDescription="Cara Dune is from Alderaanian, and served as a shock trooper.",
                    LongDescription="Carasynthia 'Cara' Dune was a human female Alderaanian who served as a shock trooper in the Alliance to Restore the Republic and the New Republic during the Galactic Civil War.",
                    Category = categoryRepository.AllCategories.ToList()[3],ImageUrl="~/images/CaraDune.jpg", InStock=true, IsPosterOfTheWeek=false},

                 new Poster {PosterId = 4, Name="Jyn Erso", Price=4.99M,
                    ShortDescription="Jyn Erso led Rogue One in stealing the Death Star plans during the Battle of Scarif.",
                    LongDescription="Jyn Erso was the daughter of Lyra Erso, a devout member of the Church of the Force, and scientist Galen Erso, who was forced into helping the Galactic Empire build the Death Star.",
                    Category = categoryRepository.AllCategories.ToList()[2],ImageUrl="~/images/Jyn.jpg", InStock=true, IsPosterOfTheWeek=true},

                new Poster {PosterId = 5, Name="Fennec Shand", Price=4.99M,
                    ShortDescription="Fennec Shand is an assassin and mercenary who worked for many of the top crime syndicates.",
                    LongDescription="After the New Republic locked up many of her employers, Fennec Shand went on the run and ended up on the planet Tatooine, where she was tracked down by two bounty hunters, Din Djarin and rookie Toro Calican.",
                    Category = categoryRepository.AllCategories.ToList()[3],ImageUrl="~/images/Fennec.jpg", InStock=true, IsPosterOfTheWeek=false},

                new Poster {PosterId = 6, Name="Leia Organa", Price=9.99M,
                    ShortDescription="Leia Skywalker Organa Solo is political and military leader.",
                    LongDescription="Leia Skywalker Organa Solo was a Force-sensitive human female political and military leader who served in the Alliance to Restore the Republic during the Imperial Era and the New Republic and Resistance in the subsequent New Republic Era.",
                    Category = categoryRepository.AllCategories.ToList()[0],ImageUrl="~/images/Leia.jpg", InStock=true, IsPosterOfTheWeek=true},

                new Poster {PosterId = 7, Name="Rey Skywalker", Price=9.99M,
                    ShortDescription="Rey Skywalker, once known only as Rey, is a Jedi Master.",
                    LongDescription="Rey Skywalker, once known only as Rey, was a human female Jedi Master who fought on the side of the Resistance in the war against the First Order. A former scavenger from the planet Jakku, her life was changed by the tumultuous events of the last days of the New Republic Era.",
                    Category = categoryRepository.AllCategories.ToList()[1],ImageUrl="~/images/Rey.jpg", InStock=true, IsPosterOfTheWeek=true},

                //new Poster {PosterId = 8, Name="Padmé Amidala", Price=9.99M,
                //    ShortDescription="",
                //    LongDescription="",
                //    Category = categoryRepository.AllCategories.ToList()[4],ImageUrl="", InStock=false, IsPosterOfTheWeek=false}
            };

        public IEnumerable<Poster> PostersOfTheWeek
        {
            get
            {
                return AllPosters.Where(p => p.IsPosterOfTheWeek);
            }
        }

        public Poster GetPosterById(int posterId)
        {
            return AllPosters.FirstOrDefault(p => p.PosterId == posterId);
        }
    } 
}
