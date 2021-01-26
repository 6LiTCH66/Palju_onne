using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;
using System.Net.Mail;  
using Xamarin.Forms; 


namespace Palju_onne
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class talv : TabbedPage
    {


        private string[] Aastaajad = { "Jaanuar", "Veebruar", "Detsember"};
        
        private string[] OnnitlusedJaanuar =
        {
            "Поздравляем с годом наступающим!", "Желаем вам удач, любви, тепла!",
            "Пусть ваш отдых будет потрясающим", "Год пусть новый деньги вам приносит",
            "Счастья вам, друзья, желаем от души!"
        };
        
        private string[] OnnitlusedVeebruar =
        {
            "Слесарь – это призвание", "Рук золотых старание!",
            "Как ловко работает он", "Он в деле своем – чемпион!",
            "Он в деле своем – чемпион!"
        };
        
        private string[] OnnitlusedDetsember =
        {
            "Сегодня первый день зимы настал", "Тебя я искренно от сердца поздравляю",
            "Зима уж снизошла на пьедестал", "И снегом нежно землю заметает",
            "Пускай она несет тебе удачу"
        };
        
        private ContentPage[] MainContentPage = new ContentPage[3];
        private StackLayout[] mainStackLayouts = new StackLayout[3];
        private Button[] mainButton = new Button[3];
        private Picker[] mainPicker = new Picker[3];
        private Random rnd;
        private Picker _picker;
        Inimesed _inimesed = new Inimesed();
        private string GetEmail;
        private Label[] mainLabel = new Label[3];
        public talv()
        {
            
            rnd = new Random();
            
            
            Title = "Talv";

            for (int i = 0; i < Aastaajad.Length; i++)
            {
                mainStackLayouts[i] = new StackLayout();
                
                mainLabel[i] = new Label()
                {
                    Text = Aastaajad[i],
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 24,
                    TextColor = Color.Black,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Padding = new Thickness(10, 10, 10, 10),
                };
                
                mainButton[i] = new Button()
                {
                    Text = "Send Email"
                };
                mainButton[i].Clicked += BtnOnClicked;
                
                mainPicker[i] = new Picker()
                {
                    Title = "Select",
                };
                
                mainPicker[i].SelectedIndexChanged += PickerOnSelectedIndexChanged;
            
                var InimObject = _inimesed.NimedList;
                
                foreach (var VARIABLE in InimObject)
                {
                    mainPicker[i].Items.Add(VARIABLE.Names);
                }
                
                MainContentPage[i] = new ContentPage()
                {
                    Title = Aastaajad[i],
                    
                };

                mainStackLayouts[i].Children.Add(mainLabel[i]);
                mainStackLayouts[i].Children.Add(mainPicker[i]);
                mainStackLayouts[i].Children.Add(mainButton[i]);
                
                
                MainContentPage[i].Content = new StackLayout()
                {
                    Children =
                    {
                        mainStackLayouts[i],
                    }
                };

                Children.Add(MainContentPage[i]);
            }
            
        }

        

        private void PickerOnSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;
            var SelectedPerson = _inimesed.NimedList;
            
            
            foreach (var VARIABLE in SelectedPerson)
            {
                if (selectedItem == VARIABLE.Names)
                {
                    GetEmail = VARIABLE.Email;
                }
            }
            

        }

        private void BtnOnClicked(object sender, EventArgs e)
        {
            
            Button button = sender as Button;

            try {
                MailMessage mail = new MailMessage();  
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");  
  
                mail.From = new MailAddress("iljaharbi@gmail.com");  
                mail.To.Add(GetEmail);
                
                if (button == mainButton[0])
                {
                    int randomNumber = rnd.Next(OnnitlusedJaanuar.Length);
                    mail.Subject = "Январь";
                    mail.Body = OnnitlusedJaanuar[randomNumber];
                    DisplayAlert("Январь", "Январь", "OK");
                }
                else if(button == mainButton[1])
                {
                    int randomNumber = rnd.Next(OnnitlusedJaanuar.Length);
                    mail.Subject = "Февраль";
                    mail.Body = OnnitlusedVeebruar[randomNumber];
                    DisplayAlert("Февраль", "Февраль", "OK");
                }
                else if (button == mainButton[2])
                {
                    int randomNumber = rnd.Next(OnnitlusedJaanuar.Length);
                    mail.Subject = "Декабрь";
                    mail.Body = OnnitlusedDetsember[randomNumber];
                    DisplayAlert("Декабрь", "Декабрь", "OK");
                }
                SmtpServer.Port = 587;  
                SmtpServer.Host = "smtp.gmail.com";  
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;  
                SmtpServer.Credentials = new System.Net.NetworkCredential("iljaharbi@gmail.com", "aa");
  
                SmtpServer.Send(mail);  
            }  
            catch(Exception ex)  
            {  
                DisplayAlert("Faild", ex.Message, "OK");  
            }
        }
    } 
}