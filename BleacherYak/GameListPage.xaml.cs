using System;
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
        private const string Url = "https://nbabasketball-api.herokuapp.com/nba";
        // Handles the Web Data Request from custom NBA API
        private HttpClient _client = new HttpClient();
        ActivityIndicator activityIndicator;

        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        public GameListPage()
        {
            InitializeComponent();
            OnGetList();
        }

        async void OpenGame(object sender, ItemTappedEventArgs e)
        {
            GameObject game = (GameObject)e.Item;

            // testing purposes - display alert with gameID from selected game
            // use this gameID as the extension for URL to enter specific chatroom
            await DisplayAlert("Alert", game._gameID, "OK");
           
        }

        protected async void OnGetList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    //Activity indicator visibility on
                    activityIndicator.IsRunning = true;

                    //Getting JSON data from the Web
                    var content = await _client.GetStringAsync(Url);

                    //Deserialize the JSON data from this line
                    var listofGames = JsonConvert.DeserializeObject
                        <ObservableCollection<GameObject>>(content);
                    //GameObject[] arrayofGames = listofGames.ToArray();
                    
                    ListView.ItemsSource = listofGames;

                   //Testing Output to Application Console:
                    /*for (int i = 0; i < arrayofGames.Length; i++)
                    {
                        Debug.WriteLine(" ");
                        Debug.WriteLine(arrayofGames[i]._visitor);
                        Debug.WriteLine("@");
                        Debug.WriteLine(arrayofGames[i]._home);
                        Debug.WriteLine(" ");
                    }*/
                }
                catch (Exception ey)
                {
                    Debug.WriteLine("" + ey);
                }
            }
        }
    }
}