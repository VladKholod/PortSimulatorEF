using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class CityView : BaseView
    {
        public CityView()
        {
            Header = "Id\tName";
        }

        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "City", "Name"));
            string name = Console.ReadLine();
            var city = new City() {Name = name};

            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<City>();
                repository.Insert(city);
            }
        }

        public override void Update()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<City>();
                var city = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "City", "Name"));
                string name = Console.ReadLine();
                
                city.Name = name;

                repository.Update(city);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<City>();
                var city = SelectMenuItem(repository.Table.ToList());

                repository.Delete(city);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "City", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<City>();
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
                var repository = unitOfWork.Repository<City>();
                var cities = repository.Table.ToList();

                Console.WriteLine(Header);
                foreach (var city in cities)
                {
                    Console.WriteLine(city);
                }
            }
        }
    }
}
