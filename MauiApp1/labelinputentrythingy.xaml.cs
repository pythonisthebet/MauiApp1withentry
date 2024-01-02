namespace MauiApp1;

public partial class labelinputentrythingy : ContentPage
{
    public string myText = "";
	public labelinputentrythingy()
	{
		InitializeComponent();

		
	}


    public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        if (!double.TryParse(newText, out var numeric) && newText != null)
        {
            entry.Text = oldText;
        }
        myText = entry.Text;
    }

    public void OnButtonClicked1(object sender, EventArgs args)
    {
        if (entry.IsReadOnly == false)
        {
            readswitch.Text = "change to writing mode";
            entry.IsReadOnly = true;
        }
        else
        {
            readswitch.Text = "change to reading mode";
            entry.IsReadOnly = false;
        }
        
    }

    async void OnButtonClicked2(object sender, EventArgs args)
    {
        await Clipboard.Default.SetTextAsync(myText);
    }

    public void OnButtonClicked3(object sender, EventArgs args)
    {
        lable.Text = myText;

    }


}