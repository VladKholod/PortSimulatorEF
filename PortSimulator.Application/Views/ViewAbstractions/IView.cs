namespace PortSimulator.Application.Views.ViewAbstractions
{
    interface IView
    {
        void Insert();
        void Update();
        void Delete();
        void Select();
        void SelectAll();
    }
}
