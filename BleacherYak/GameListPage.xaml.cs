﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


namespace BleacherYak
{
    public partial class GameListPage : ContentPage
    {
        private const string Url = "http://10.0.2.2:5000";
        // Handles the Web Data Request
        private HttpClient _client = new HttpClient();
        ActivityIndicator activityIndicator;

        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        public GameListPage()
        {
            InitializeComponent();
            OnGetList();


        }

        protected async void OnGetList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    //Activity indicator visibility on
                    //activityIndicator.IsRunning = true;

                    //Getting JSON data from the Web
                    var content = await _client.GetStringAsync(Url);

                    //Deserialize the JSON data from this line
                    //var myList = JsonConvert.DeserializeObject<List<clsSalesTran>>(inputString)
                    var listofGames = JsonConvert.DeserializeObject<ObservableCollection<GameObject>>(content);

                    //Debug.WriteLine(listofGames[0]._home);


                    //Display List View
                    //for (int i = 0; i < 15; i++)
                    //{
                        //.Add(new Contacts() { Id = i, Name = "Student" + i.ToString(), Address = "Address" + i.ToString(), Image = "usa.png" });
                    //}



                    foreach (var _gameID in listofGames)
                        Debug.WriteLine(listofGames[0]._visitor);
                        Debug.WriteLine("@");
                        Debug.WriteLine(listofGames[0]._home);



                }

                catch (Exception ey)
                {
                    Debug.WriteLine("" + ey);
                }
            }
        }
    }
}