using Employee.Maui.Views;

namespace Employee.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EmployeePage), typeof(EmployeePage));
            Routing.RegisterRoute(nameof(EditEmployeePage), typeof(EditEmployeePage));
            Routing.RegisterRoute(nameof(AddEmployeePage), typeof(AddEmployeePage));

        }
    }
}
