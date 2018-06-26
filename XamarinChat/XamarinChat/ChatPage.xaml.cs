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
        //private readonly BindingBase messageBinding;

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
            var mData = new MemberData { Name = nickname, Color = "green" };
            _scaledrone = new Scaledrone("ORZLEvNn5v2xcH33", mData);
            _scaledrone.OnOpened += Scaledrone_OnOpened;
            _scaledrone.OnRoomMessage += Scaledrone_OnRoomMessage;
            _scaledrone.Connect();
            _messages = new ObservableCollection<Message>();
            MessagesListView.ItemTemplate =new MyDataTemplateSelector();
            MessagesListView.ItemsSource = _messages;
            OutGoingText = "Ini";

        }

        string outgoingText = "Selective";

        public string OutGoingText
        {
            get { return outgoingText; }
            set { SetValue ( outgoingText, value); }
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
            msg.MemberData = member.ClientData.ToObject<MemberData>();
            msg.IsMyMessage = member.Id == _scaledrone.ClientId; 
            _messages.Add(msg);
            
            //Debug.WriteLine(messageText.Text);
            var nickname = new Label();
            nickname.SetBinding(Label.TextProperty, "Name");
            nickname.BindingContext = new { Name = "John Doe" };

        }




        private void Scaledrone_OnOpened()
        {
            _scaledrone.Subscribe(RoomName);
        }
    }
}