using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mjesuscode1lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mjesuscode1lab.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any Provinces.
                if (context.Provinces.Any())
                {
                    return;   // DB has already been seeded
                }

                var provinces = GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                var cities = GetCities(context).ToArray();
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }
        }

        public static List<Province> GetProvinces()
        {
            List<Province> Provinces = new List<Province>() {
            new Province() {
                ProvinceCode="BC",
                ProvinceName="British Columbia",
            },
            new Province() {
                ProvinceCode="ON",
                ProvinceName="Ontario",
            },
            new Province() {
                ProvinceCode="SK",
                ProvinceName="Saskatchewan",
            },
        };

            return Provinces;
        }

        public static List<City> GetCities(ApplicationDbContext context)
        {
            List<City> Cities = new List<City>() {
            new City {
                //CityId = 1,
                CityName = "Chilliwack",
                Population = 78000,
                ProvinceCode = "BC"
            },
            new City {
                //CityId = 2,
                CityName = "Abbotsford",
                Population = 180000,
                ProvinceCode = "BC",
            },
            new City {
                //CityId = 3,
                CityName = "Richmond",
                Population = 400000,
                ProvinceCode = "BC",
            },
            new City {
                //CityId = 4,
                CityName = "Saskatoon",
                Population = 250000,
                ProvinceCode = "SK",
            },
            new City {
                //CityId = 5,
                CityName = "Regina",
                Population = 200000,
                ProvinceCode = "SK",
            },
            new City {
                //CityId = 6,
                CityName = "Moose Jaw",
                Population = 34000,
                ProvinceCode = "SK",
            },
            new City {
                //CityId = 7,
                CityName = "Hamilton",
                Population = 78000,
                ProvinceCode = "ON",
            },
            new City {
                //CityId = 8,
                CityName = "Oakville",
                Population = 78000,
                ProvinceCode = "ON",
            },
            new City {
                //CityId = 9,
                CityName = "Ottawa",
                Population = 78000,
                ProvinceCode = "ON",
            },
        };

            return Cities;
        }
    }
}

