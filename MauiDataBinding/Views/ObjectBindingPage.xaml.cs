using MauiDataBinding.ViewModels;

namespace MauiDataBinding.Views;

public partial class ObjectBindingPage : ContentPage
{
	public ObjectBindingPage()
	{
		InitializeComponent();
        BindingContext = new PersonViewModel( new Person(DateTime.Parse("03/14/2000"), "Albert", "Einstein", "Male"));
        //BindingContext =  new Person(DateTime.Parse("03/14/1879"), "Albert", "Einstein", "Male");
	}



}
