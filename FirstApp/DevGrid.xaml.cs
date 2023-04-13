using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace FirstApp;


public partial class DevGrid : ContentPage
{
    List<Person> persons;
	public DevGrid()
	{
		
        InitializeComponent();
        persons= new List<Person>() {
                new Person {Name = "BoreHole", Age = 50, Location = "Atlanta"},
                new Person {Name = "Brenda Wiliams and Associates", Age = 25, Location = "Memphis"},
                new Person {Name = "Sean Paul George", Age = 36, Location = "Houston"},
                new Person {Name = "Wiliams New and Associates", Age = 16, Location = "Memphis"},
                new Person {Name = "Pauly George", Age = 36, Location = "Atlanta"}

            };
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
       person_ComboBox.ItemsSource= persons;
        person_ComboBox.DisplayMember= "Name";
        person_ComboBox.ValueMember= "Name";
        
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("Saved Successfully", ToastDuration.Short);
        await toast.Show();
    }
}
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Location { get; set; }
}