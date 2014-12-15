using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class TripView : BaseView
    {
        public TripView()
        {
            Header = "Id\tStartDate\tEndDate\t\tShipID\tCapId\tPortFId\tPortTId";
        }
        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "StartDate"));
                var startDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "EndDate"));
                var endDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Ship"));
                var ship = GetDependence<Ship>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Captain"));
                var captain = GetDependence<Captain>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortFrom"));
                var portFrom = GetDependence<Port>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortTo"));
                var portTo = GetDependence<Port>();

                var trip = new Trip()
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    Ship = ship,
                    Captain = captain,
                    PortFrom = portFrom,
                    PortTo = portTo
                };

                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Trip>();
                    repository.Insert(trip);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
            }
        }

        public override void Update()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Trip>();
                var trip = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "StartDate"));
                var startDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "EndDate"));
                var endDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Ship"));
                var ship = GetDependence<Ship>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "Captain"));
                var captain = GetDependence<Captain>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortFrom"));
                var portFrom = GetDependence<Port>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Trip", "PortTo"));
                var portTo = GetDependence<Port>();

                trip.StartDate = startDate;
                trip.EndDate = endDate;
                trip.Ship = ship;
                trip.Captain = captain;
                trip.PortFrom = portFrom;
                trip.PortTo = portTo;

                repository.Update(trip);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Trip>();
                var ship = SelectMenuItem(repository.Table.ToList());

                repository.Delete(ship);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Trip", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Trip>();
                    var id = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine(Header);
                    Console.WriteLine(repository.GetById(id));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Any row with current id.");
            }
        }

        public override void SelectAll()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Trip>();
                var trips = repository.Table.ToList();

                Console.WriteLine(Header);
                foreach (var trip in trips)
                {
                    Console.WriteLine(trip);
                }
            }
        }
    }
}
