namespace PortSimulator.Application
{
    public static class Program
    {
        static void Main()
        {
            using (var app = new Application())
            {
                app.Start();
            }
        }
    }
}
