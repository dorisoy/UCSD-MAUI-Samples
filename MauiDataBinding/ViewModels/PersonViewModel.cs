﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiDataBinding.Views;

namespace MauiDataBinding.ViewModels;

partial class PersonViewModel:ObservableValidator
{
    [ObservableProperty]
    [Required]
    [MaxLength(30)]
    private string   _lastName;

    [ObservableProperty]
    [Required(ErrorMessage = "First Name Required")]
    [MinLength(2, ErrorMessage = "First Name should be 2 char min")]
    private string   _firstName;

    [ObservableProperty]
    private DateTime  _dateOfBirth;

    [ObservableProperty]
    private string    _gender;
    [ObservableProperty]
    private int       _age;
    
    [ObservableProperty]
    private string _favoriteKid;

    public ObservableCollection<string> Children { get; set; } = new ObservableCollection<string>();

    [ObservableProperty] 
    private bool _isAgeVisible;

    [ObservableProperty]
    private string _errors;

    private Person _person;

    public PersonViewModel(Person p)
    {
        LastName = p.LastName;
        FirstName= p.FirstName;
        DateOfBirth=p.DateOfBirth;
        if (p.Age > 30)
        {
            IsAgeVisible = false;
        }
        else
        {
            IsAgeVisible = true;
        }
        Gender=p.Gender;
        Age=p.Age;
        _person = p;
        Children.Add("Joe");
        Children.Add("Jane");
        Children.Add("Michael");
        Children.Add("George");
        Children.Add("Anna");
        FavoriteKid = "Jane";
    }

    [RelayCommand]
    public void ModifyPerson()
    {
        LastName = "Durand";
        FirstName = "Eddie";
        Children.Remove("Michael");
        Children.Add("Ringo");
        Children.Add("Bastian");

    }

    [RelayCommand]
    public void CancelChanges()
    {
        LastName = _person.LastName;
        FirstName= _person.FirstName;
        DateOfBirth=_person.DateOfBirth;
        Gender=_person.Gender;
        Age=_person.Age;
    }

    [RelayCommand]
    public void SaveChanges()
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            Errors = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
        }
        else
        {
            Errors = "";
        }

        _person.LastName = LastName;
        _person.FirstName= FirstName;
        _person.DateOfBirth=DateOfBirth;
        _person.Gender=Gender;
        _person.Age=Age;
        // Send updated Person to the server
    }

    [RelayCommand]
    public void FavoriteChildrenChanged()
    {

    }

}