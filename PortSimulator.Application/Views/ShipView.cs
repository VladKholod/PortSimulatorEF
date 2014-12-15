using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class ShipView : BaseView
    {
        public ShipView()
        {
            Header = "Id\tNumber\tCapac\tCreateDate\tMaxDist\tTCount\tPortId";
        }

        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Capacity"));
                var capacity = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "CreateDate"));
                var createDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "MaxDistance"));
                var maxDistance = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "TeamCount"));
                var teamCount = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Ship", "Port"));
                var port = GetDependence<Port>();

                var ship = new Ship()
                {
                    Number = number,
                    Capacity = capacity,
                    CreateDate = createDate,
                    MaxDistance = maxDistance,
                    TeamCount = teamCount,
                    Port = port
                };

                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Ship>();
                    repository.Insert(ship);
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
                var repository = unitOfWork.Repository<Ship>();
                var ship = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Capacity"));
                var capacity = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "CreateDate"));
                var createDate = DateTime.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "MaxDistance"));
                var maxDistance = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "TeamCount"));
                var teamCount = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Ship", "Port"));
                var port = GetDependence<Port>();

                ship.Number = number;
                ship.Capacity = capacity;
                ship.CreateDate = createDate;
                ship.Capacity = capacity;
                ship.MaxDistance = maxDistance;
                ship.Port = port;

                repository.Update(ship);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Ship>();
                var ship = SelectMenuItem(repository.Table.ToList());

                repository.Delete(ship);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Ship", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Ship>();
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
                var repository = unitOfWork.Repository<Ship>();
                var ships = repository.Table.ToList();
                
                Console.WriteLine(Header);
                foreach (var ship in ships)
                {
                    Console.WriteLine(ship);
                }
            }
        }
    }
}
