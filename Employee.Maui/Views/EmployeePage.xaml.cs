using Employee.Maui.Models;
using System.Collections.ObjectModel;
using Employees = Employee.Maui.Models.Employees;

namespace Employee.Maui.Views;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var employees = new ObservableCollection<Employees>(EmployeeRepository.GetEmployees());

        listEmployees.ItemsSource = employees;
    }


    private void listEmployees_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listEmployees.SelectedItem != null)
		{
			Shell.Current.GoToAsync($"{nameof(EditEmployeePage)}?Id={((Employees)listEmployees.SelectedItem).EmployeeId}");
        }
		
    }

    private void listEmployees_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listEmployees.SelectedItem = null;
    }
}