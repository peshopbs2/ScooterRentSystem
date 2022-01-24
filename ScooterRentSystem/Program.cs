using ScooterRentSystem.BLL.Services;
using ScooterRentSystem.DAL.Abstractions;
using ScooterRentSystem.DAL.Data;
using ScooterRentSystem.DAL.Entities;
using ScooterRentSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScooterRentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            RentDbContext context = new RentDbContext();
            IRepository<City> cityRepo = new Repository<City>(context);
            IRepository<Person> peopleRepo = new Repository<Person>(context);

            CityService cityService = new CityService(cityRepo, peopleRepo);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandData = command.Split(' ').ToArray();
                if (commandData[0] == "Add")
                {
                    string cityName = commandData[1];
                    string cityPosition = commandData[2];

                    cityService.CreateCity(cityName, cityPosition);
                }
                else if (commandData[0] == "ListAll")
                {
                    List<City> cities = cityService.GetCities();
                    foreach (var city in cities)
                    {
                        Console.WriteLine($"#{city.Id} - {city.Name} ({city.GpsPosition})");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
