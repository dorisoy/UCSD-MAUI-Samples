﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLayouts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlexLayoutPage : ContentPage
    {
        public FlexLayoutPage()
        {
            InitializeComponent();

            // Create an Image object for each bitmap
            // All faces are generated by an AI on the website "https://thispersondoesnotexist.com/"
            for (int i = 1; i<53 ; i++)
            {
                var imageName = $"image{i:D3}.jpg";
                Image image = new Image
                {
                    HeightRequest = 128,
                    WidthRequest = 128,
                    Source = imageName
                };
                flexLayout.Children.Add(image);
            }
        }
    }
}
