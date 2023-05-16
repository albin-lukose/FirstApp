using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using static System.Net.Mime.MediaTypeNames;

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
       // DataTemplate personDataTemplate = 

        base.OnAppearing();

        //ComboBoxEdit person_ComboBox = new ComboBoxEdit();
        //person_ComboBox.ItemsSource= persons;
        //person_ComboBox.DisplayMember= "Name";
        //person_ComboBox.ValueMember= "Name";

        //parentGrid.SetColumn(person_ComboBox, 1);
        //parentGrid.Add(person_ComboBox);


        var comboBox = new ComboBoxEdit()
        {
            ItemsSource = persons,
            SelectedItem = persons[0],
            DisplayMember= "Name"

        };

        var comboBox2 = new ComboBoxEdit()
        {
            ItemsSource = persons,
            SelectedItem = persons[0],
            DisplayMember = "Name"

        };
        //// Define ItemTemplate
        //comboBox2.ItemTemplate = new DataTemplate(() =>
        //{
        //    var stackLayout = new HorizontalStackLayout();

        //    var nameLabel = new Label();
        //    nameLabel.SetBinding(Label.TextProperty, "Name");
        //    stackLayout.Children.Add(nameLabel);


        //    var ageLabel = new Label();
        //    ageLabel.SetBinding(Label.TextProperty, "Age");
        //    stackLayout.Children.Add(ageLabel);

        //    return stackLayout;
        //});

        comboBox2.ItemTemplate = new DataTemplate(() =>
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) }); // Name: 50%
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.2, GridUnitType.Star) }); // Age: 10%
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.4, GridUnitType.Star) }); // Location: 40%

            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, "Name");
            Grid.SetColumn(nameLabel, 0);
            grid.Children.Add(nameLabel);

            var ageLabel = new Label();
            ageLabel.SetBinding(Label.TextProperty, "Age");
            Grid.SetColumn(ageLabel, 1);
            grid.Children.Add(ageLabel);

            var locationLabel = new Label();
            locationLabel.SetBinding(Label.TextProperty, "Location");
            Grid.SetColumn(locationLabel, 2);
            grid.Children.Add(locationLabel);

            return grid;
        });

        var comboBox3 = new ComboBoxEdit()
        {
            ItemsSource = persons,
            SelectedItem = persons[0],
            DisplayMember = "Name"

        };

        comboBox3.ItemTemplate = new DataTemplate(() =>
        {
            var stackLayout = new StackLayout();

            var nameLabel = new Label();
            nameLabel.SetBinding(Label.TextProperty, "Name");
            stackLayout.Children.Add(nameLabel);

            var detailsLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            var ageLabel = new Label();
            ageLabel.SetBinding(Label.TextProperty, "Age");
            detailsLayout.Children.Add(ageLabel);

            var locationLabel = new Label();
            locationLabel.SetBinding(Label.TextProperty, "Location");
            detailsLayout.Children.Add(locationLabel);

            stackLayout.Children.Add(detailsLayout);

            return stackLayout;
        });
        parentGrid.SetColumn(comboBox, 1);
        parentGrid.Add(comboBox);

        //
        parentGrid2.SetColumn(comboBox2, 1);
        parentGrid2.Add(comboBox2);
        //
        parentGrid3.SetColumn(comboBox3, 1);
        parentGrid3.Add(comboBox3);

        PersonListView.ItemsSource= persons;
        DataTemplate personDataTemplate = new DataTemplate(() =>
        {
            Grid grid = new Grid();
            

            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());



            Label nameLabel = new Label { FontAttributes = FontAttributes.Bold,TextColor=Colors.Red };
            Label ageLabel = new Label { TextColor = Colors.Blue };
            Label locationLabel = new Label { TextColor = Colors.Green };

            nameLabel.SetBinding(Label.TextProperty, "Name");
            ageLabel.SetBinding(Label.TextProperty, "Age");
            locationLabel.SetBinding(Label.TextProperty, "Location");

            //
            Grid.SetColumn(nameLabel, 0);
            Grid.SetRow(nameLabel, 0);
            grid.Add(nameLabel);

            //
            Grid.SetColumn(ageLabel,1);
            Grid.SetRow(ageLabel, 0);
            grid.Add(ageLabel);
            //
            Grid.SetColumn(locationLabel, 2);
            Grid.SetRow(locationLabel, 0);
            grid.Add(locationLabel);


            return new ViewCell { View = grid };
        });

        PersonListView.ItemTemplate = personDataTemplate;
        //person_ComboBox.ItemTemplate= personDataTemplate; 

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