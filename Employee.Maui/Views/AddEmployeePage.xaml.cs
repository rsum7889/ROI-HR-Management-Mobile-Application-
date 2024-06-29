using Employee.Maui.Models;

namespace Employee.Maui.Views;

public partial class AddEmployeePage : ContentPage
{
	public AddEmployeePage()
	{
		InitializeComponent();
	}

    // Method used to go back to main menu 
    private void btnMainMenu_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void employeeCtrl_EmployeeSaved(object sender, EventArgs e)
    {

    }

    private void employeeCtrl_EmployeeSaved_1(object sender, EventArgs e)
    {
        // Add new employee to repository
        EmployeeRepository.AddEmployee(new Models.Employees
        {
            Name = employeeCtrl.Name,
            Number = employeeCtrl.Number,
            Address = employeeCtrl.Address,
        });

        // Go back to previous page
        Shell.Current.GoToAsync("..");
    }
    
    // Once a user adds new employee details this method is called to go back to the main
    // menu 
    private void employeeCtrl_EmployeeMainMenu(object sender, EventArgs e)
    {
        // Goes back to the previous page
        Shell.Current.GoToAsync("..");
    }

    private void employeeCtrl_EmployeeError(object sender, string e)
    {
        DisplayAlert("Error", e,"Ok");
    }
}