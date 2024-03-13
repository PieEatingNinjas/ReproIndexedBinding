using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReproductionIndexProperty;

public partial class MainPage : ContentPage
{
    public ClassWithIndexProperty ClassWithIndexProperty
    {
        get;
    } = new ();
    
    public MainPage()
    {
        BindingContext = this;
        InitializeComponent();
    }
    
    private void Button_Clicked(object sender, EventArgs e)
    {
        ClassWithIndexProperty.SetValue("foo", "bar");
    }
    
    private void Button_Clicked2(object sender, EventArgs e)
    {
        ClassWithIndexProperty.SetValue2("foo", "bar bar");
    }
}

public class ClassWithIndexProperty : INotifyPropertyChanged
{
    private Dictionary<string, string> data = new ();
    
    public string this[string index] => data[index];

    public void SetValue(string key, string value)
    {
        data[key] = value;
        
        PropertyChanged?.Invoke(this, 
            new PropertyChangedEventArgs($"Item[{key}]"));
    }
    
    public void SetValue2(string key, string value)
    {
        data[key] = value;
        
        PropertyChanged?.Invoke(this, 
            new PropertyChangedEventArgs($"Item"));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}