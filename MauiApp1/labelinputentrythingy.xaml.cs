using System.Drawing;

namespace MauiApp1;

public partial class labelinputentrythingy : ContentPage
{
    public string myText = "";
    Label lable;
    Button lamecopy;
    Button readswitch;
    Entry entry;
    public int red;
    public int green;
    public int blue;
	public labelinputentrythingy()
	{
		InitializeComponent();
        readswitch = new Button()
        {
            Text = "change to reading mode",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            //Clicked = "OnButtonClicked1"
            

        };

        lamecopy = new Button()
        {
            Text = "lameCopy",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            //click??????
        };

        entry = new Entry()
        {
            Placeholder = "enter numbers",
            IsReadOnly = false,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Keyboard = Keyboard.Numeric
        };

        lable = new Label()
        {
            Text = "Dynamic label"
        };

        lamecopy.Clicked += OnButtonClicked3;
        readswitch.Clicked += OnButtonClicked1;
        entry.TextChanged += OnEntryTextChanged;
        myStack.Children.Add(readswitch);
        myStack.Children.Add(lamecopy);
        myStack.Children.Add(entry);
        myStack.Children.Add(lable);
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

    public void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        red = (int)slidered.Value;
        blue = (int)slideblue.Value;
        green = (int)slidegreen.Value;
        
        funcolors.Color  = Microsoft.Maui.Graphics.Color.FromRgb(red, blue, green);
        funcolors.RotationX = (int)slidered.Value*3 + (int)slideblue.Value * 3 + (int)slidegreen.Value * 3;
        funcolors.RotationY = (int)slidered.Value * 3 + (int)slideblue.Value * 3 + (int)slidegreen.Value * 3;
    }




}