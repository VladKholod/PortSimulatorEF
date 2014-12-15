using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PortSimulator.Application.Views;
using PortSimulator.Application.Views.ViewAbstractions;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.RepositoryPattern;

namespace PortSimulator.Application
{
    public sealed class Application : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        private BaseView _viewBehaviour = new CityView();

        private bool _disposed;

        private List<string> _actions = new List<string>(); 
        private List<string> _entities = new List<string>();

        private string _selectedEntity = string.Empty;
        private string _selectedAction = string.Empty;
        
        public Application()
        {
            _unitOfWork = new UnitOfWork();
            
            InitEntities();
            InitActions();
        }

        public void Start()
        {
            Console.WriteLine("Press any key to start..");
            while (Console.ReadKey(false).Key != ConsoleKey.F12)
            {
                SelectMenuItem(_entities);
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.WriteLine("Press any key to continue or <F12> to exit");
            }
        }

        private void PerformCommand()
        {
            ChangeViewBehaviour();

            if (_selectedAction == "Insert")
            {
                _viewBehaviour.Insert();
            }
            else if (_selectedAction == "Update")
            {
                _viewBehaviour.Update();
            }
            else if (_selectedAction == "Delete")
            {
                _viewBehaviour.Delete();
            }
            else if (_selectedAction == "Select")
            {
                _viewBehaviour.Select();
            }
            else if (_selectedAction == "SelectAll")
            {
                _viewBehaviour.SelectAll();
            }
        }

        private void ChangeViewBehaviour()
        {
            if (_selectedEntity == "Captain")
            {
                _viewBehaviour = new CaptainView();
            }
            else if (_selectedEntity == "Cargo")
            {
                _viewBehaviour = new CargoView();
            }
            else if (_selectedEntity == "CargoType")
            {
                _viewBehaviour = new CargoTypeView();
            }
            else if (_selectedEntity == "City")
            {
                _viewBehaviour = new CityView();
            }
            else if (_selectedEntity == "Port")
            {
                _viewBehaviour = new PortView();
            }
            else if (_selectedEntity == "Ship")
            {
                _viewBehaviour = new ShipView();
            }
            else if (_selectedEntity == "Trip")
            {
                _viewBehaviour = new TripView();
            }
        }

        private void DisplayMenu(List<string> items, int selectedMenuItem)
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

        private void SelectMenuItem(List<string> items)
        {
            Console.CursorVisible = false;
            var currentMenuItem = 0;
            while (true)
            {
                DisplayMenu(items, currentMenuItem);

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
                    SetSelectedEntity(currentMenuItem);
                    SelectSubMenuItem(_actions);
                    break;
                }
            }
        }

        private void SelectSubMenuItem(List<string> items)
        {
            Console.CursorVisible = false;
            var currentSubMenuItem = 0;
            while (true)
            {
                DisplayMenu(items, currentSubMenuItem);

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (currentSubMenuItem > 0)
                        currentSubMenuItem--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentSubMenuItem < items.Count - 1)
                        currentSubMenuItem++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    SetSelectedCommand(currentSubMenuItem);   
                    Console.Clear();
                    PerformCommand();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    SelectMenuItem(_entities);
                    break;
                }
            }
        }

        private void SetSelectedCommand(int index)
        {
            if (index == 0)
            {
                _selectedAction = "Insert";
            }
            else if (index == 1)
            {
                _selectedAction = "Update";
            }
            else if (index == 2)
            {
                _selectedAction = "Delete";
            }
            else if (index == 3)
            {
                _selectedAction = "Select";
            }
            else if (index == 4)
            {
                _selectedAction = "SelectAll";
            }
        }

        private void SetSelectedEntity(int index)
        {
            if (index == 0)
            {
                _selectedEntity = "Captain";
            }                     
            else if (index == 1)  
            {                     
                _selectedEntity = "Cargo";
            }                     
            else if (index == 2)  
            {                     
                _selectedEntity = "CargoType";
            }                     
            else if (index == 3)  
            {                     
                _selectedEntity = "City";
            }                     
            else if (index == 4)  
            {                     
                _selectedEntity = "Port";
            }                     
            else if (index == 5)  
            {                     
                _selectedEntity = "Ship";
            }                     
            else if (index == 6)  
            {                     
                _selectedEntity = "Trip";
            }
        }

        private void InitEntities()
        {
            var entityTypes = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType == typeof (BaseEntity));

            foreach (var type in entityTypes)
            {
                _entities.Add(type.Name);
            }
        }

        private void InitActions()
        {
            _actions.Add("Insert");
            _actions.Add("Update");
            _actions.Add("Delete");
            _actions.Add("Select");
            _actions.Add("SelectAll");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _unitOfWork.Dispose();

            _disposed = true;
        }
    }
}
