using MauiApp1.Models;
using System.Windows.Input;

namespace MauiApp1;

public partial class BlogDatailsPage : ContentPage
{
    BlogDatailsModel blogDatailsModel;
    public BlogDatailsPage(Models.Entry blogentry)
	{
		InitializeComponent();
		blogDatailsModel = new BlogDatailsModel(blogentry);
        BindingContext = blogentry;
	}
}
