namespace Employee.Maui.Views.Controls;

public partial class EmployeeControl : ContentView
{

	public event EventHandler<string> EmployeeError;
	public event EventHandler<EventArgs> EmployeeSaved;
    public event EventHandler<EventArgs> EmployeeMainMenu;


    public EmployeeControl()
	{
		InitializeComponent();
	}

	public string Name 
	{
		get
		{
			return entryName.Text;
		}
		set 
		{ 
			entryName.Text = value;
		}
	}

	public string Number
	{
		get
		{
			return entryNumber.Text;
		}
		set
		{
			entryNumber.Text = value;
		}
	}

	public string Address
	{
		get
		{
			return entryAddress.Text;
		}
		set
		{
			entryAddress.Text = value;
		}
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
			EmployeeError?.Invoke(sender,"Name Required");
            return;
        }

        if (NumberValidator.IsNotValid)
        {
            EmployeeError?.Invoke(sender, "Number Required");
            return;
        }

        if (AddressValidation.IsNotValid)
        {
            EmployeeError?.Invoke(sender, "Address Required");
            return;
        }

		EmployeeSaved?.Invoke(sender, e);

    }

    private void btnMainMenu_Clicked(object sender, EventArgs e)
    {
		EmployeeMainMenu?.Invoke(sender, e);
    }
}