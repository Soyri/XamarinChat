using System;

namespace XamarinChat
{
    class Message
    {
        public String MessageText { get; set; }
        public MemberData Member { get; set; }
        public bool IsMyMessage { get; set; }

        public String NickName
        {
            get { return Member.Name; }
        }

        public String MessageColor
        {
            get { return Member.Color; }
        }
    }
}
