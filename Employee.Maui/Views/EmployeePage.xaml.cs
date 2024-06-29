using Employee.Maui.Models;
using Plugin.Maui.ScreenBrightness;
using System.Collections.ObjectModel;
using Employees = Employee.Maui.Models.Employees;

namespace Employee.Maui.Views;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
        // UI components are initialized
        InitializeComponent();

        // Slider default value is set to current screen brightness
        sliderBrightness.Value = ScreenBrightness.Default.Brightness;
	}

    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Everytime the homepage appears, list of employees are generated 
        LoadEmployees();
    }


    // Method is used when a user selects an employee
    private void listEmployees_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // When an employee is selected, the editemployee page of that 'employee' is shown
		if (listEmployees.SelectedItem != null)
		{
			Shell.Current.GoToAsync($"{nameof(EditEmployeePage)}?Id={((Employees)listEmployees.SelectedItem).EmployeeId}");
        }
		
    }

    private void listEmployees_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listEmployees.SelectedItem = null; // Unselect employee
    }

    // Method is used when user clicks 'Add button'
    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddEmployeePage));
    }

    // Method is used to delete employee from list
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
        var employeeItem = sender as MenuItem;
        var employees = employeeItem.CommandParameter as Employees;
        EmployeeRepository.DeleteEmployee(employees.EmployeeId); 

        // Once an employee is deleted the remaining employees are loaded to the 
        // homepage
        LoadEmployees();
    }

    private void LoadEmployees()
    {
        var employees = new ObservableCollection<Employees>(EmployeeRepository.GetEmployees());
        listEmployees.ItemsSource = employees;
    }

    // Method used to change the brightness of screen
    private void sliderBrightness_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Float value of brightness to be shown on maui 
        float brightnessValue = (float)e.NewValue/100;
        ScreenBrightness.Default.Brightness = brightnessValue;


        // Round Value
        int roundValue = (int)Math.Round(e.NewValue);
        labelBrightness.Text = $"{roundValue}%";
    }
}