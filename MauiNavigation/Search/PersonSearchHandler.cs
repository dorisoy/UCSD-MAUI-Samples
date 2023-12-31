﻿using CommunityToolkit.Mvvm.ComponentModel;
using MauiNavigation.Models;
using MauiNavigation.ViewModels;
using System.Collections.ObjectModel;

namespace MauiNavigation.Search;


public class PersonSearchHandler:SearchHandler
{
    // Create an event for the selected person
    public event EventHandler<Person> PersonSelected;

    public PersonSearchHandler()
    {
        // IOS
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            SearchBoxVisibility = SearchBoxVisibility.Expanded;
        }
        else
        {
            SearchBoxVisibility = SearchBoxVisibility.Collapsible;
        }

        

    }

    public IEnumerable<Person> Persons { get; set; }


    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);
        if(Persons == null)
        {
            Persons = ItemsSource as IEnumerable<Person>;
        }

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            var search = newValue.ToLower();

            ItemsSource = (from p in Persons
             where  p.Name.ToLower().Contains(search)
             select p);
           
        }
    }

    protected override async void OnItemSelected(object item)
    {
        var selectedPerson = item as Person;
        //await Task.Delay(1000); // for the code to work on IOS add delay


        if (selectedPerson == null)
            return;
        PersonSelected?.Invoke(this, selectedPerson);

        // This works because route names are unique in this application.
        //await Shell.Current.GoToAsync($"persondetail?id={selectedPerson.Name}");
        base.OnItemSelected(item);
        
    }
}
