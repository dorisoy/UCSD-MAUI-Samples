﻿using System.Windows.Input;

namespace MauiNavigation;

public partial class AppShell : Shell
{
	public AppShell()
	{
        //AppActions.Current.SetAsync(new { } AppAction("SettingsPage", "Settings", icon: "settings_icon"));

        InitializeComponent();


        NavigateToSettingsCommand = new Command( () =>
        {
             DisplayAlert("Settings","Settings Menu Selected","Ok");
        });

        BindingContext = this;


    }



    public ICommand NavigateToSettingsCommand { get; private set; }
}
