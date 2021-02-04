using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosterShop.Models
{
    public interface IPosterRepository
    {
        IEnumerable<Poster> AllPosters { get; }
        IEnumerable<Poster> PostersOfTheWeek { get; }
        Poster GetPosterById(int posterId);
    }
}
