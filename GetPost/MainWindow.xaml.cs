using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GetPost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
            public MainWindow()
            {
                InitializeComponent();
                PostRequest("http://easyscooter.co.in/android/test.php");
            }
            async void GetRequest(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                    {
                        using (HttpContent content = responseMessage.Content)
                        {
                            string cont = await content.ReadAsStringAsync();
                            mytext.Text = cont;
                        }
                    }
                }
            }

            async void PostRequest(string url)
            {
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("fname","qwe"),
                new KeyValuePair<string, string>("lname","aaaa"),
                new KeyValuePair<string, string>("email","aa@gmail.com"),
                new KeyValuePair<string, string>("number","12321231"),
                new KeyValuePair<string, string>("password","1231322"),
                new KeyValuePair<string, string>("fileToUpload","1232332"),
                new KeyValuePair<string, string>("fileToUpload1","3213")
            };

                HttpContent httpContent = new FormUrlEncodedContent(queries);
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage responseMessage = await client.PostAsync(url, httpContent))
                    {
                        using (HttpContent content = responseMessage.Content)
                        {
                            string cont = await content.ReadAsStringAsync();
                            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(cont);

                        //setting message
                            mytext.Text = loginModel.message;
                        }
                    }
                }
            }

        }
    }
