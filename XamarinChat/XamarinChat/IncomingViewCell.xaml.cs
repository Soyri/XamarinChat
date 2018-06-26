using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinChat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomingViewCell : ViewCell
    {
        public object messageTextViewProperty;

        public IncomingViewCell()
        {
            InitializeComponent();
        }

        


    }   
}