﻿using Newtonsoft.Json;
using ScaledroneDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinChat
{
    [JsonObject(MemberSerialization.Fields)]
    public class MemberData
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("color")]
        public string Color;
        [JsonProperty("password")]
        public string Password;
    }

    public partial class ChatPage : ContentPage
    {
        private Scaledrone _scaledrone;



        private const string RoomName = "observable-room";
        public ChatPage (string nickname)
		{
            InitializeComponent();
            var mData = new MemberData { Name = nickname, Color = "green" };
            _scaledrone = new Scaledrone("ORZLEvNn5v2xcH33", mData);
            _scaledrone.OnOpened += Scaledrone_OnOpened;
            _scaledrone.OnRoomMessage += Scaledrone_OnRoomMessage;
            _scaledrone.Connect();
            IncomingViewCell incomingViewCell = new IncomingViewCell();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            _scaledrone.Publish(RoomName, entry1.Text);
        }
        

        private void Scaledrone_OnRoomMessage(Room room, Newtonsoft.Json.Linq.JToken message, Member member)
        {
            entry1 = new Entry { Placeholder = "Write more text", Text = "" };
            //TODO add to view
        }




        private void Scaledrone_OnOpened()
        {
            _scaledrone.Subscribe(RoomName);
        }
    }
}