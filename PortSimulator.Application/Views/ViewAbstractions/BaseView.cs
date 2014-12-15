using System;
using System.Collections.Generic;
using System.Linq;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application.Views.ViewAbstractions
{
    public abstract class BaseView : IView
    {
        protected string Header;

        protected T GetDependence<T>() where T : BaseEntity
        {
            List<T> entities = new List<T>();
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = unitOfWork.Repository<T>();
                entities = repository.Table.ToList();
            }

            return SelectMenuItem<T>(entities);
        }

        protected T SelectMenuItem<T>(List<T> entities) where T : BaseEntity
        {
            Console.CursorVisible = false;
            var currentMenuItem = 0;

            var items = entities.Select(item => item.ToString()).ToList();

            while (true)
            {
                DisplayItems(items, currentMenuItem);

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (currentMenuItem > 0)
                        currentMenuItem--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentMenuItem < items.Count - 1)
                        currentMenuItem++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return entities[currentMenuItem];
                }
            }
        }

        private void DisplayItems(List<string> items, int selectedMenuItem)
        {
            Console.Clear();
            for (var i = 0; i < items.Count; i++)
            {
                Console.WriteLine("{0} {1}", i == selectedMenuItem ? "    >\t" : "\t", items[i]);
            }

            DisplayHelp();
        }

        private void DisplayHelp()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            Console.WriteLine("Press <Enter> to select menu item.");
            Console.WriteLine("Press <Backspace> to return to previous submenu.");
        }

        #region IView
        public abstract void Insert();

        public abstract void Update();

        public abstract void Delete();

        public abstract void Select();

        public abstract void SelectAll();
        #endregion
    }
}
