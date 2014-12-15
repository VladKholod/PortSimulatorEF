using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class CargoView : BaseView
    {
        public CargoView()
        {
            Header = "Id\tNumber\tWeight\tPrice\tIPrice\tCTypeId\tTripId";
        }

        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Weight"));
                var weight = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Price"));
                var price = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "InsurancePrice"));
                var insurancePrice = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "Trip"));
                var trip = GetDependence<Trip>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "CargoType"));
                var cargoType = GetDependence<CargoType>();

                var cargo = new Cargo()
                {
                    Number = number,
                    Weight = weight,
                    Price = price,
                    InsurancePrice = insurancePrice,
                    Trip = trip,
                    CargoType = cargoType
                };

                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Cargo>();
                    repository.Insert(cargo);
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
                var repository = unitOfWork.Repository<Cargo>();
                var cargo = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Number"));
                var number = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Weight"));
                var weight = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Price"));
                var price = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "InsurancePrice"));
                var insurancePrice = int.Parse(Console.ReadLine());
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "Trip"));
                var trip = GetDependence<Trip>();
                Console.Write(string.Format("Select {0}'s {1} : ", "Cargo", "CargoType"));
                var cargoType = GetDependence<CargoType>();

                cargo.Number = number;
                cargo.Weight = weight;
                cargo.Price = price;
                cargo.InsurancePrice = insurancePrice;
                cargo.Trip = trip;
                cargo.CargoType = cargoType;

                repository.Update(cargo);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Cargo>();
                var cargo = SelectMenuItem(repository.Table.ToList());

                repository.Delete(cargo);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Cargo", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Cargo>();
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
                var repository = unitOfWork.Repository<Cargo>();
                var cargos = repository.Table.ToList();
                Console.WriteLine(Header);
                foreach (var cargo in cargos)
                {
                    Console.WriteLine(cargo);
                }
            }
        }
    }
}
