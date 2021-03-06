﻿using ManagedCrunch.Sample.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ManagedCrunch.Sample.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            FileHelper.ProcessEmbeddedFile("kodim15.crn", async (b) =>
            {
                var dxt1Texture = CrunchHelper.CrnDecompress(b);

                if (dxt1Texture.Length == 196608)
                {
                    var dialog = new MessageDialog("Ok");
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("Error");
                    await dialog.ShowAsync();
                }
            });
        }
    }
}
