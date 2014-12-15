using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class PortView : BaseView
    {
        public PortView()
        {
            Header = "Id\tName\t\tCityId";
        }

        public override void Insert()
        {
            try
            {
                Console.Write(string.Format("Insert {0}'s {1} : ", "Port", "Name"));
                var name = Console.ReadLine();
                Console.Write(string.Format("Select {0}'s {1} : ", "Port", "City"));
                var city = GetDependence<City>();

                var port = new Port()
                {
                    Name = name,
                    City = city
                };

                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Port>();
                    repository.Insert(port);
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
                var repository = unitOfWork.Repository<Port>();
                var port = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "Port", "Name"));
                var name = Console.ReadLine();
                Console.Write(string.Format("Select {0}'s {1} : ", "Port", "City"));
                var city = GetDependence<City>();

                port.Name = name;
                port.City = city;

                repository.Update(port);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Port>();
                var cargo = SelectMenuItem(repository.Table.ToList());

                repository.Delete(cargo);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Port", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Port>();
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
                var repository = unitOfWork.Repository<Port>();
                var ports = repository.Table.ToList();

                Console.WriteLine(Header);
                foreach (var port in ports)
                {
                    Console.WriteLine(port);
                }
            }
        }
    }
}
