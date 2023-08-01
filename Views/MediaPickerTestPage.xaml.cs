using MauiApp1.Models;
using System.Windows.Input;
using static Android.Graphics.ColorSpace;

namespace MauiApp1.Views;

public partial class MediaPickerTestPage : ContentPage
{
    private MediaPickerTestPageViewModel viewModel;

    public MediaPickerTestPage(MediaPickerTestPageViewModel model)
	{
		InitializeComponent();
		InitPage(model);

    }

	public MediaPickerTestPage()
	{
        InitializeComponent();

        InitPage(new MediaPickerTestPageViewModel());
    }

	private void InitPage(MediaPickerTestPageViewModel model)
	{
        viewModel = model;

        this.BindingContext = viewModel;

        
    }
}