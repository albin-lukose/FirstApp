using Microsoft.Maui.Controls.PlatformConfiguration;



namespace FirstApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{

        string dataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        string _rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string _rootDirectory1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string _rootDirectory2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        var specialFolders = Enum.GetValues(typeof(Environment.SpecialFolder)).Cast<Environment.SpecialFolder>();
        IEnumerable<DirectoryDesc> abcd= specialFolders.Select(s => new DirectoryDesc(s.ToString(), Environment.GetFolderPath(s))).Where(d => !string.IsNullOrEmpty(d.Path));

        int randomNumber= new Random().Next(99999);
        await SaveTextFileAsync("Hello, World!", $"{randomNumber}.txt");
        // await Shell.Current.GoToAsync("DevGrid");
        //await Shell.Current.GoToAsync("DataForm");
    }
    private async Task SaveTextFileAsync(string content, string fileName)
    {
        try
        {
           
            string dataFolderPath="";
            int androidsdk=0;
            string downloads = "";
            // string path1 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
#if ANDROID
 string externalStoragePath = Android.OS.Environment.ExternalStorageDirectory.Path;
 downloads=Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
 string packageName = Android.App.Application.Context.PackageName;
 dataFolderPath = Path.Combine(externalStoragePath, "Android", "data", packageName);
 androidsdk= (int)Android.OS.Build.VERSION.SdkInt;


 //if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
 //               && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
 //           {
 //               var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
 //               RequestPermissions(permissions, 1);
 
#endif

            dataFolderPath = Path.Combine(dataFolderPath, fileName);
            var x = dataFolderPath;
            var y = androidsdk;
            var z = downloads;

            string downloadPath = Path.Combine(downloads, fileName);

            if (androidsdk<31)
            {
                using (StreamWriter writer = File.CreateText(downloadPath))
                {
                    await writer.WriteAsync(content);
                    await DisplayAlert("Success", "Text file saved successfully!", "OK");
                }

            }
            

            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to save text file: {ex.Message}", "OK");
        }
    }
}

class DirectoryDesc
{
    public DirectoryDesc(string key, string path)
    {
        Key = key;

        Path = path == null
            ? ""
            : string.Join(System.IO.Path.DirectorySeparatorChar.ToString(), path.Split(System.IO.Path.DirectorySeparatorChar).Select(s => s.Length > 18 ? s.Substring(0, 5) + "..." + s.Substring(s.Length - 8, 8) : s));
    }

    public string Key { get; set; }
    public string Path { get; set; }
}

