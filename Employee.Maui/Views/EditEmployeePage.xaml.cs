using Employee.Maui.Models;
using Employees = Employee.Maui.Models.Employees;



namespace Employee.Maui.Views;

// This page accepts an 'Id' query property
[QueryProperty(nameof(EmployeeId),"Id")]
public partial class EditEmployeePage : ContentPage
{
	private Employees employees;

	public EditEmployeePage()
	{
        // UI components are initialized
        InitializeComponent();
	}

	// Method used when used clicks on the main menu button
	private void btnMainMenu_Clicked(object sender, EventArgs e)
	{
		// ".." means the user will be directed to the previous page
		Shell.Current.GoToAsync("..");
	}

	public string EmployeeId
    {
		set
		{
			employees = EmployeeRepository.GetEmployeesById(int.Parse(value));
			if (employees != null)
			{
				// Employee details
                employeeCtrl.Name = employees.Name;
				employeeCtrl.Number = employees.Number;
				employeeCtrl.Address = employees.Address;

            }
			
		}
	}

	// Method to update employee details 
    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

		employees.Name = employeeCtrl.Name;
		employees.Number = employeeCtrl.Number;
		employees.Address = employeeCtrl.Address;

		// Update employees in the repository
        EmployeeRepository.UpdateEmployees(employees.EmployeeId, employees);

		// Go back to the previous page
        Shell.Current.GoToAsync("..");
    }

	// When a user updates a profile without entering all details, the following
	// method is called. 
    private void employeeCtrl_EmployeeError(object sender, string e)
    {
		// Error message display
		DisplayAlert("Error", e,"Ok");
    }
}