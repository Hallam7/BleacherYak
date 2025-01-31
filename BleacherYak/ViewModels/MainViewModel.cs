﻿using BleacherYak.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BleacherYak.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private string _message;
        private ObservableCollection<MessageModel> _messages;
        private bool _isConnected;

        public string Name
        {
            get{ return _name; }
            set{ _name = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get{ return _message; }
            set{ _message = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MessageModel> Messages
        {
            get{ return _messages; }
            set{ _messages = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnected
        {
            get{ return _isConnected;}
            set{ _isConnected = value;
                OnPropertyChanged();
            }
        }

        private HubConnection hubConnection;

        public Command SendMessageCommand { get; }
        public Command ConnectCommand { get; }
        public Command DisconnectCommand { get; }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            SendMessageCommand = new Command(async () => { await SendMessage(Name, Message); });
            ConnectCommand = new Command(async () => await Connect());
            DisconnectCommand = new Command(async () => await Disconnect());

            IsConnected = false;

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            var baseAddress = new Uri("https://20.50.2.4:80/chatHub");
            //var baseAddress = new Uri("https://10.0.2.2:5001/chatHub");
            var client = new HttpClient(handler) { BaseAddress = baseAddress };
            var result = client.GetAsync("");


            //var httpClientHandler = new HttpClientHandler();
            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => { return true; };


            //if (!SslCheck)
            //{ 
            // System.Net.ServicePointManager.ServerCertificateValidationCallback = (message, cert, chain, errors) => { return true; };
            //no SSL check needed yet  - NOT WORKING!
            // httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            //no SSL check needed yet
            //}

            hubConnection = new HubConnectionBuilder()
            //.WithUrl($"https://10.0.2.2:5001/chatHub")
            .WithUrl($"https://20.50.2.4:80/chatHub")
            .Build();


            hubConnection.On<string>("JoinChat", (user) =>
            {
                Messages.Add(new MessageModel() { User = Name, Message = $"{user} has joined the chat", IsSystemMessage = true });
            });

            hubConnection.On<string>("LeaveChat", (user) =>
            {
                Messages.Add(new MessageModel() { User = Name, Message = $"{user} has left the chat", IsSystemMessage = true });
            });

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Messages.Add(new MessageModel() { User = user, Message = message, IsSystemMessage = false, IsOwnMessage = Name == user });
            });

        }

        async Task Connect()
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("JoinChat", Name);

            IsConnected = true;
        }

        async Task SendMessage(string user, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", user, message);
        }

        async Task Disconnect()
        {
            await hubConnection.InvokeAsync("LeaveChat", Name);
            await hubConnection.StopAsync();

            IsConnected = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}