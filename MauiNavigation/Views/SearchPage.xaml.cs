using MauiNavigation.ViewModels;

namespace MauiNavigation.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
        BindingContext = new SearchPageViewModel();
		InitializeComponent();
    }

}