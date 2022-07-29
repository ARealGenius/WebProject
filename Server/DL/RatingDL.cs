
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL : IRatingDL
    {
        TravelsAgencyContext travelsAgencyContext;
        public RatingDL(TravelsAgencyContext travelsAgencyContext)
        {
            this.travelsAgencyContext = travelsAgencyContext;
        }
        public async Task Post(Rating rating)
        {
            await travelsAgencyContext.Ratings.AddAsync(rating);
            await travelsAgencyContext.SaveChangesAsync();
        }
    }
}
       