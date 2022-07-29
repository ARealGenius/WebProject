using DL;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        TravelsAgencyContext _travelsAgencyContext;
        Rating _rating;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, TravelsAgencyContext travelsAgencyContext)
        {
           _travelsAgencyContext = travelsAgencyContext;
            _rating = new Rating();
            _rating.Host = httpContext.Request.Host.ToString();
            _rating.Method = httpContext.Request.Method;
            _rating.Path = httpContext.Request.Path;
            _rating.RecordDate = DateTime.Now;
            _rating.Referer = httpContext.Request.Headers["Referer"];
            _rating.UserAgent = httpContext.Request.Headers["User-Agent"];
            await _travelsAgencyContext.Ratings.AddAsync(_rating);
            await _travelsAgencyContext.SaveChangesAsync();
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
