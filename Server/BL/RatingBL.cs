using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBL:IRatingBL
    {
        IRatingDL _IRatingDL;
        public RatingBL(IRatingDL iRatingDL)
        {
            _IRatingDL = iRatingDL;
        }
        public async Task Post(Rating rating)
        {
          await  _IRatingDL.Post(rating);
        }
    }
}
