using System;
using System.Linq;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views
{
    public class CaptainView : BaseView
    {
        public CaptainView()
        {
            Header = "Id\tFName\tLName";
        }

        public override void Insert()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "FirstName"));
            string firstName = Console.ReadLine();
            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "LastName"));
            string lastName = Console.ReadLine();

            var captain = new Captain() {FirstName = firstName, LastName = lastName};
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Captain>();
                repository.Insert(captain);
            }
        }

        public override void Update()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Captain>();
                var captain = SelectMenuItem(repository.Table.ToList());

                Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "FirstName"));
                string firstName = Console.ReadLine();
                Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "LastName"));
                string lastName = Console.ReadLine();

                captain.FirstName = firstName;
                captain.LastName = lastName;

                repository.Update(captain);
            }
        }

        public override void Delete()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<Captain>();
                var captain = SelectMenuItem(repository.Table.ToList());

                repository.Delete(captain);
            }
        }

        public override void Select()
        {
            Console.Write(string.Format("Insert {0}'s {1} : ", "Captain", "Id"));
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var repository = unitOfWork.Repository<Captain>();
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
                var repository = unitOfWork.Repository<Captain>();
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
