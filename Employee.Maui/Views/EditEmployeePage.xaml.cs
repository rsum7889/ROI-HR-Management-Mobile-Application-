using Employee.Maui.Models;
using Employees = Employee.Maui.Models.Employees;



namespace Employee.Maui.Views;


[QueryProperty(nameof(EmployeeId),"Id")]
public partial class EditEmployeePage : ContentPage
{
	private Employees employees;
	public EditEmployeePage()
	{
		InitializeComponent();
	}

	private void btnMainMenu_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	public string EmployeeId
    {
		set
		{
			employees = EmployeeRepository.GetEmployeesById(int.Parse(value));
			if (employees != null)
			{
                entryName.Text = employees.Name;
				entryNumber.Text = employees.Number;
				entryAddress.Text = employees.Address;

            }
			
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

		if (nameValidator.IsNotValid)
		{
			DisplayAlert("Error", "Name Required", "Ok");
			return;
		}

		if (NumberValidator.IsNotValid) 
		{
			DisplayAlert("Error", "Number Required", "Ok");
			return;
		}

		if (AddressValidation.IsNotValid)
		{
			DisplayAlert("Error", "Address Required", "Ok");
			return;
		}

        employees.Name = entryName.Text;
		employees.Number = entryNumber.Text;
		employees.Address = entryAddress.Text;

        EmployeeRepository.UpdateEmployees(employees.EmployeeId, employees);
        Shell.Current.GoToAsync("..");
    }
}