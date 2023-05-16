using DevExpress.Maui.DataForm;


namespace FirstApp;

public partial class DataFormExample : ContentPage
{
    Dictionary<string, object> dataModel = new Dictionary<string, object>();
    public static string[] Emails = { "ameliah@dx-email.com",
                                          "anthonys@dx-email.com",
                                          "arnolds@dx-email.com",
                                          "arthurm@dx-email.com" };

    public DataFormExample()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        //

        DataFormView DiseaseDataformview = new DataFormView();
        string editorName = $"Email {dataModel.Count}";
        Random random = new Random();

        int mailindex = random.Next(1, Emails.Length);
        object editorValue = Emails[mailindex];

        var dataformItem = new DataFormTextItem { FieldName = editorName };

        dataModel.Add(dataformItem.FieldName, editorValue);
        DiseaseDataformview.Items.Add(dataformItem);

        int mailindex1 = random.Next(2, Emails.Length);
        object editorValue1 = Emails[mailindex1];

        var dataformItem2 = new DataFormTextItem { FieldName = editorName+"2" };

        dataModel.Add(dataformItem2.FieldName, editorValue1);
        DiseaseDataformview.Items.Add(dataformItem2);

        DiseaseDataformview.ValidationMode = CommitMode.Manually;
        DiseaseDataformview.DataObject = dataModel;
        DiseaseDataformview.Validate();
       
        parentGrid.Add(DiseaseDataformview);
    }
}