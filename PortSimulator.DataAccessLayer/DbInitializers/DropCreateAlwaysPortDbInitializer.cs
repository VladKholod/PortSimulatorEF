using System;
using System.Collections.Generic;
using System.Data.Entity;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbInitializers
{
    public class DropCreateAlwaysPortDbInitializer : DropCreateDatabaseAlways<PortSimulatorContext>
    {
        protected override void Seed(PortSimulatorContext context)
        {
            #region cities
            var cities = new List<City>
            {
                new City() {Name = "Odessa"},
                new City() {Name = "New-York"},
                new City() {Name = "Anapa"},
                new City() {Name = "Kolon"},
                new City() {Name = "Kenai"},
                new City() {Name = "Ninbo"},
                new City() {Name = "Muuga"}
            };
            cities.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();
            #endregion

            #region cargoTypes
            var cargoTypes = new List<CargoType>
            {
                new CargoType() {Name = "Slave"},
                new CargoType() {Name = "Sugar"},
                new CargoType() {Name = "Salt"},
                new CargoType() {Name = "CornFlake"},
                new CargoType() {Name = "Cookie"},
                new CargoType() {Name = "Pie"}
            };
            cargoTypes.ForEach(ct => context.CargoTypes.Add(ct));
            context.SaveChanges();
            #endregion

            #region captains
            var captains = new List<Captain>
            {
                new Captain() {FirstName = "Vlad", LastName = "Kholod"},
                new Captain() {FirstName = "Kot", LastName = "Leopold"},
                new Captain() {FirstName = "Max", LastName = "Payne"},
                new Captain() {FirstName = "Vlad", LastName = "Lem"},
                new Captain() {FirstName = "Petr", LastName = "Pervy"}
            };
            captains.ForEach(c => context.Captains.Add(c));
            context.SaveChanges();
            #endregion

            #region ports
            var ports = new List<Port>
            {
                new Port(){Name = "Great Sailor", CityId = 1},
                new Port(){Name = "Space Kid", CityId = 1},
                new Port(){Name = "Destroyer", CityId = 2},
                new Port(){Name = "Nobody & Co", CityId = 3},
                new Port(){Name = "Temp Company", CityId = 4},
                new Port(){Name = "Little Pony",CityId = 7}
            };
            ports.ForEach(p => context.Ports.Add(p));
            context.SaveChanges();
            #endregion

            #region ships

            var ships = new List<Ship>
            {
                new Ship()
                {
                    Number = 10000,
                    MaxDistance = 12, 
                    TeamCount = 8,
                    Capacity = 2000, 
                    CreateDate = DateTime.Now,
                    PortId = 2
                },
                new Ship()
                {
                    Number = 10101,
                    MaxDistance = 154, 
                    TeamCount = 2,
                    Capacity = 90, 
                    CreateDate = new DateTime(2010,7,30),
                    PortId = 4
                },
                new Ship()
                {
                    Number = 98,
                    MaxDistance = 2, 
                    TeamCount = 100,
                    Capacity = 3, 
                    CreateDate = DateTime.Now,
                    PortId = 2
                }
            };
            ships.ForEach(s => context.Ships.Add(s));
            context.SaveChanges();
            #endregion

            #region trips
            var trips = new List<Trip>
            {
                new Trip()
                {
                    StartDate = new DateTime(2013,11,01),
                    EndDate = DateTime.Now,
                    CaptainId = 4,
                    PortFromId = 3,
                    PortToId = 1,
                    ShipId = 2
                },
                new Trip()
                {
                    StartDate = new DateTime(2014,12,20),
                    EndDate = new DateTime(2014,12,21),
                    CaptainId = 1,
                    PortFromId = 1,
                    PortToId = 2,
                    ShipId = 1
                },
                new Trip()
                {
                    StartDate = new DateTime(1994,08,16),
                    EndDate = new DateTime(2011,09,15),
                    CaptainId = 3,
                    PortFromId = 2,
                    PortToId = 4,
                    ShipId = 2
                }
            };
            trips.ForEach(t => context.Trips.Add(t));
            context.SaveChanges();
            #endregion

            #region cargos

            var cargos = new List<Cargo>
            {
                new Cargo()
                {
                    Price = 10000,
                    InsurancePrice = 1000,
                    Number = 9,
                    CargoTypeId = 1,
                    Weight = 80,
                    TripId = 1
                },
                new Cargo()
                {
                    Price = 912,
                    InsurancePrice = 500,
                    Number = 13,
                    CargoTypeId = 2,
                    Weight = 800,
                    TripId = 1
                },
                new Cargo()
                {
                    Price = 777,
                    InsurancePrice = 9000,
                    Number = 89123,
                    CargoTypeId = 4,
                    Weight = 9000,
                    TripId = 2
                },
                new Cargo()
                {
                    Price = 1,
                    InsurancePrice = 81,
                    Number = 991223,
                    CargoTypeId = 3,
                    Weight = 9111,
                    TripId = 3
                }
            };
            cargos.ForEach(c => context.Cargos.Add(c));
            context.SaveChanges();
            #endregion
        }
    }
}
