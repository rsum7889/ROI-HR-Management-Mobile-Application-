namespace Employee.Maui.Views;

public partial class AddEmployeePage : ContentPage
{
	public AddEmployeePage()
	{
		InitializeComponent();
	}

    private void btnMainMenu_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}