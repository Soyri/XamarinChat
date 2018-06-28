using ScaledroneDotNET;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinChat
{

    public partial class ChatPage : ContentPage
    
    {

        private Scaledrone _scaledrone;
        private ObservableCollection<Message> _messages;
     

        private const string RoomName = "observable-room";
    

        public ChatPage()
        {
            InitializeComponent();
            _messages = new ObservableCollection<Message>();
            MessagesListView.ItemTemplate = new MyDataTemplateSelector();
            MessagesListView.ItemsSource = _messages;          
        }
        public ChatPage (string nickname)
		{
            InitializeComponent();
         
            var mData = new MemberData { Name = nickname, Color = GetRandomColor() };
            _scaledrone = new Scaledrone("ORZLEvNn5v2xcH33", mData);
            _scaledrone.OnOpened += Scaledrone_OnOpened;
            _scaledrone.OnRoomMessage += Scaledrone_OnRoomMessage;
            _scaledrone.Connect();
            _messages = new ObservableCollection<Message>();
            MessagesListView.ItemTemplate =new MyDataTemplateSelector();
            MessagesListView.ItemsSource = _messages;
           

        }

        private static string GetRandomColor()
        {
            string[] colorArray = new[] { "#c2dfed", "#c2c8ed", "#d9c2ed", "#edc2c2", "#ede7c2", "#dcedc2", "#c2edce", "#c2ede6" };
            Random random = new Random();
            int randomNumber = random.Next(0, colorArray.Length);
            String randomColor = colorArray[randomNumber];
            return randomColor;

        }


        void OnButtonClicked(object sender, EventArgs args)
        {
            _scaledrone.Publish(RoomName, entry1.Text);
            entry1.Placeholder = "Write more text";
            entry1.Text = "";
        }
        

        private void Scaledrone_OnRoomMessage(Room room, Newtonsoft.Json.Linq.JToken message, Member member)
        {
            Message msg = new Message();
            msg.MessageText = message.ToString();
            msg.Member = member.ClientData.ToObject<MemberData>();
            msg.IsMyMessage = member.Id == _scaledrone.ClientId; 
            _messages.Add(msg);
     

        }




        private void Scaledrone_OnOpened()
        {
            _scaledrone.Subscribe(RoomName);
        }
    }
}