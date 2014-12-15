using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class CargoTypeView : BaseView
    {
        public CargoTypeView()
        {
            Header = "Id\tName";
        }

        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "CargoType", "Name"));
            string name = Console.ReadLine();
            var cargoType = new CargoType() { Name = name };

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<CargoType>();
                repository.Insert(cargoType);
            }
        }

        public override void Update()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<CargoType>();
                var cargoType = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "CargoType", "Name"));
                string name = Console.ReadLine();

                cargoType.Name = name;

                repository.Update(cargoType);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<CargoType>();
                var cargoType = SelectMenuItem(repository.Table.ToList());

                repository.Delete(cargoType);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "CargoType", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<CargoType>();
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
                var repository = unitOfWork.Repository<CargoType>();
                var cargoTypes = repository.Table.ToList();
                
                Console.WriteLine(Header);
                foreach (var cargoType in cargoTypes)
                {
                    Console.WriteLine(cargoType);
                }
            }
        }
    }
}
