using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        string web_link = "https://webapp.liteon.com/EPHealthFormWeb";
        bool is_sec_page = false;
        string[] text_file= new string[20];
        public static string week = DateTime.Today.DayOfWeek.ToString();


        public Form1()
        {

            InitializeComponent();

            // open list //
            text_file = System.IO.File.ReadAllLines(@".\List.txt");

            // open web //
            webBrowser1.Navigate(web_link);


            Uri u = new Uri(web_link);
            UriBuilder ub = new UriBuilder(u);
            ub.UserName = text_file[0];
            ub.Password = text_file[1];
            webBrowser1.Url = ub.Uri;

            // delay 0.2s for check //
            Thread.Sleep(200);

            // if webside compilite
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {   
                //get page element with id
                //webBrowser1.Document.GetElementById("txtCName").InnerText = text_file[3];
                //webBrowser1.Document.GetElementById("txtEmpId").InnerText = text_file[4];
                if (week== "Saturday" || week == "Sunday")
                    webBrowser1.Document.GetElementById("ddlShiftType").InnerText = "假日";
                else 
                    webBrowser1.Document.GetElementById("ddlShiftType").InnerText = "正常上班不分班別";



            //webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("optionsRadios").GetElementById("rbWorkLocationType2").InvokeMember("click");


                if (text_file[7] == "中和")
                webBrowser1.Document.GetElementById("ddlWorkLocation").SetAttribute("Value", "中和");

                else if (text_file[7] == "新莊")
                    webBrowser1.Document.GetElementById("ddlWorkLocation").InnerText = "新莊";
                else if (text_file[7] == "龍潭")
                    webBrowser1.Document.GetElementById("ddlWorkLocation").InnerText = "龍潭";
                else if (text_file[7] == "大園")
                    webBrowser1.Document.GetElementById("ddlWorkLocation").InnerText = "大園";
                else if (text_file[7] == "新竹")
                    webBrowser1.Document.GetElementById("ddlWorkLocation").InnerText = "新竹";
                else if (text_file[7] == "高雄")
                    webBrowser1.Document.GetElementById("ddlWorkLocation").InnerText = "高雄";
                else if (text_file[7] == "台南")
                    webBrowser1.Document.GetElementById("ddlWorkLocation").InnerText = "台南";
                else
                    webBrowser1.Document.GetElementById("rbWorkLocation").InnerText = "請選擇[廠區]";

                webBrowser1.Document.GetElementById("txtEnergPhone").InnerText = text_file[8];

                Random rnd = new Random();
                int temp_rnd = rnd.Next(1, 16);
                webBrowser1.Document.GetElementById("txtTemp").InnerText = (35.5 + (0.1 * temp_rnd)).ToString("0.0");

                webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("cbHealthStatus")[0].InvokeMember("click");
                webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("rbRelationHealthStatus")[0].InvokeMember("click");

                if (text_file[12] == "0")
                    webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("rbVaccinationStatus")[0].InvokeMember("click");
                else if (text_file[12] == "1")
                    webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("rbVaccinationStatus")[1].InvokeMember("click");
                else if (text_file[12] == "2")
                    webBrowser1.Document.GetElementsByTagName("input").GetElementsByName("rbVaccinationStatus")[2].InvokeMember("click");

            // delay 2s for check //
            Thread.Sleep(2000);
                //webBrowser1.Document.GetElementById("Submit").InvokeMember("click");

                // delay 2s for check //
                Thread.Sleep(2000);

        }
    }
}
