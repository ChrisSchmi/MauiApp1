using MauiApp1.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    BlogClient _blogClient;
    MainPageModel _model;

    public MainPage()
	{
		InitializeComponent();

        _blogClient = new BlogClient();
        _model = new MainPageModel(_blogClient, Navigation);

        BindingContext = _model;
    }


}

