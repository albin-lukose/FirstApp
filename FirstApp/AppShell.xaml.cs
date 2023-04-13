namespace FirstApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("DevGrid", typeof(DevGrid));
    }
}
