﻿using LibraryManager.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LibraryManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            this.InitializeComponent();
            FetchData();
        }

        private async void FetchData()
        {
            var task = NetworkManager.FetchJSONData("https://library-manager-data.getsandbox.com/librarydata");
            bool result = await task;
            if(result)
            {
                LoadMembersPage();
            }
        }

        //Loading a new Page
        private void LoadMembersPage()
        {
            this.Frame.Navigate(typeof(MemberSearchPage));
        }
    }
}
