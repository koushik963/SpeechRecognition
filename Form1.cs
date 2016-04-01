using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
namespace SpeechRecogDemo
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();
        SpeechSynthesizer MyRobot = new SpeechSynthesizer();
        string QEvent;
        string ProcWindow;
        double timer = 10;
        int count = 1;
        int flag = 0,fb_flag=0,c_flag=0,i=0,chrome_flag;
        int type_flag = 0;
        int cal_flag;
        int main_flag=1;
        int gmail_flag = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
          //  this.TopMost = true;
            string[] commands = (File.ReadAllLines(@"E:\commands_original.txt"));
            lstCommands.Items.Clear();
            lstCommands.SelectionMode = SelectionMode.None;
            lstCommands.Visible = true;
        }
        void SRE_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum = rnd.Next(1, 10);
            string speech = e.Result.Text;
           // MessageBox.Show(speech);
            listBox1.Items.Add(speech);
           // int flag = 0;
           // type(speech);
            if (speech == "start typing")
            {
                type_flag = 1;
                speech="";
                type(speech);
            }
            else if (speech == "stop typing")
            {
                type_flag = 0;
            }
            type(speech);
            if(type_flag==0)
            {
                switch (speech) 
                {
                    //GREETINGS
                    case "hello":
                        if (ranNum < 6) { MyRobot.Speak("Hello sir how are you"); }
                        else if (ranNum > 5) { MyRobot.Speak("Hi"); }
                        break;

                    //For Typing
                    case "typing start":
                        type_flag = 1;
                        break;
                    case "stop typing":
                        type_flag = 0;
                        break;
                    //calculator
                    case "one":
                        SendKeys.Send(Convert.ToString(Keys.NumPad1));
                        break;
                    case "two":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad2));
                        }
                        break;
                    case "three":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad3));
                        }
                        break;
                    case "four":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad4));

                        }
                        break;
                    case "five":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad5));

                        }
                        break;
                    case "six":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad6));

                        }
                        break;

                    case "seven":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad7));

                        }
                        break;
                    case "eight":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad8));

                        }
                        break;
                    case "nine":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send(Convert.ToString(Keys.NumPad9));

                        }
                        break;

                    case "addition":
                        if (cal_flag == 1)
                        {
                            SendKeys.Send("{ADD}");
                        }
                        break;

                    case "equals":
                        if (cal_flag == 1)
                        {

                            SendKeys.Send("{ENTER}");
                        }
                        break;
                    case "open calculator":
                        cal_flag = 1;
                        MessageBox.Show("calculator");
                        MyRobot.Speak("opening calculator");
                        System.Diagnostics.Process.Start("calc");
                        break;
                    case "type":
                        {
                            flag = 1;
                        }
                        break;

                    case "goodbye":
                    case "close":
                        MyRobot.Speak("Until next time");
                        Close();
                        break;

                    //WEBSITES
                    case "open google":
                        System.Diagnostics.Process.Start("http://www.google.com");
                        break;
                        chrome_flag = 1;
                    case "notepad":
                        MyRobot.Speak("opening notepad");
                        System.Diagnostics.Process.Start("notepad");
                        flag = 1;
                        break;
                    case "page down":
                        MyRobot.Speak("scrolling down");
                        SendKeys.Send("{PGDN}");
                        break;
                    case "page up":
                        MyRobot.Speak("scrolling UP");
                        SendKeys.Send("{PGUP}");
                        break;

                    //Gmail Commands
                    case "open gmail":
                        System.Diagnostics.Process.Start("http://www.gmail.com");
                        gmail_flag = 1;
                        break;
                    case "compose":
                        if (gmail_flag == 1) { SendKeys.Send("c"); }
                        
                        break;
                    case "compose in new tab":
                        if (gmail_flag == 1) { }
                        SendKeys.Send("d");
                        break;

                    case "Search":

                        if (gmail_flag == 1) { }
                        SendKeys.Send("/");
                        break;

                    case "open it":

                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("{ENTER}");
                        }
                        break;

                  case "next mail":
                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("k");
                        }
                        break;

                    case "previous mail":
                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("j");
                        }
                       
                        break;
                    case "archive it":

                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("e");
                        }
                        break;

                    case "select it":

                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("x");
                        }
                        break;
                    case "mark as important":

                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("{ADD}");
                        }
                        break;

                    case "mark as unimportant":

                        if (gmail_flag == 1) {
                            SendKeys.Send("-");
                        }
                        break;
                    case "send":

                        if (gmail_flag == 1)
                        {
                            SendKeys.Send("{TAB}+{ENTER}");
                        }
                        break;
                    case "show all of my mails":

                        if (gmail_flag == 1) { SendKeys.Send("ga"); }
                       
                        break;
                    case "starred messages":

                        if (gmail_flag == 1) { SendKeys.Send("gs"); }
                        
                        
                        break;

                    case "show my contacts":

                        if (gmail_flag == 1) { SendKeys.Send("gc"); }
                       
                        break;

                    case "show my drafts":

                        if (gmail_flag == 1) { SendKeys.Send("gd"); }
                        
                        break;

                    case "go to my inbox":

                        if (gmail_flag == 1) { SendKeys.Send("gi"); }
                      
                        break;

                    case "show my sent mails":

                        if (gmail_flag == 1) { SendKeys.Send("ga"); }
                        
                        break;
                    //SHELL COMMANDS
                    case "open vlc":
                        // System.Diagnostics.Process.Start("C:\Program Files\VideoLAN\VLC\vlc.exe");
                        MyRobot.Speak("Loading");
                        break;

                    //CLOSE PROGRAMS
                    case "close cleaner":
                        ProcWindow = "ccleaner ";
                        StopWindow();
                        break;

                    //CONDITION OF DAY
                    case "what time is it":
                        DateTime now = DateTime.Now;
                        string time = now.GetDateTimeFormats('t')[0];
                        MyRobot.Speak(time);
                        break;
                    case "what day is it":
                        MyRobot.Speak(DateTime.Today.ToString("dddd"));
                        break;
                    case "whats the date":
                    case "whats todays date":
                    case "date":
                        MyRobot.Speak(DateTime.Today.ToString("dd-MM-yyyy"));
                        break;

                    //OTHER COMMANDS
                    case "go fullscreen":
                        FormBorderStyle = FormBorderStyle.None;
                        WindowState = FormWindowState.Maximized;
                        TopMost = true;
                        MyRobot.Speak("expanding");
                        break;
                    case "exit fullscreen":
                        FormBorderStyle = FormBorderStyle.Sizable;
                        WindowState = FormWindowState.Normal;
                        TopMost = false;
                        break;
                    case "switch window":
                        MyRobot.Speak("switching window");
                        SendKeys.Send("%{TAB " + count + "}");
                        count += 1;
                        break;
                    case "close window":
                        SendKeys.Send("^w");
                        break;
                    case "reset":
                        count = 1;
                        timer = 11;
                        lblTimer.Visible = false;
                        ShutdownTimer.Enabled = false;
                        lstCommands.Visible = false;
                        break;
                    case "out of the way":
                        if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                        {
                            WindowState = FormWindowState.Minimized;
                            MyRobot.Speak("My apologies");
                        }
                        break;
                    case "come back":
                        if (WindowState == FormWindowState.Minimized)
                        {
                            MyRobot.Speak("Alright?");
                            WindowState = FormWindowState.Normal;
                        }
                        break;
                    case "show commands":
                        string[] commands = (File.ReadAllLines(@"E:\commands_original.txt"));
                        MyRobot.Speak("Very well");
                        lstCommands.Items.Clear();
                        lstCommands.SelectionMode = SelectionMode.None;
                        lstCommands.Visible = true;
                        foreach (string command in commands)
                        {
                            lstCommands.Items.Add(command);
                        }
                        break;
                    case "hide listbox":
                        lstCommands.Visible = false;
                        break;
                    //Facebook commands
                    case "open facebook":
                        System.Diagnostics.Process.Start("http://www.fb.com");
                        fb_flag = 1;
                        chrome_flag = 1;
                        break;

                    case "show timeline":
                        if (fb_flag == 1)
                        {
                            MyRobot.Speak("here is your timeline");
                            SendKeys.Send("%2");

                        }
                        break;
                    case "go to home":
                        if (fb_flag == 1)
                        {
                            MyRobot.Speak("Redirecting you to your facebook home");
                            SendKeys.Send("%1");

                        }
                        break;
                    case "show my friends list":
                        if (fb_flag == 1)
                        {
                            MyRobot.Speak("Showing your friends");
                            SendKeys.Send("%3");

                        }
                        break;
                    case "show my messages":
                        if (fb_flag == 1)
                        {
                            MyRobot.Speak("showing your messages");
                            SendKeys.Send("%4");

                        }
                        break;
                    case "do i have any notifications":
                        if (fb_flag == 1)
                        {
                            MyRobot.Speak("yes sir here are your notifications");
                            SendKeys.Send("%5");

                        }
                        break;
                    case "next":
                        if (fb_flag == 1)
                        {
                            // MyRobot.Speak("here is your timeline");
                            SendKeys.Send("j");

                        }
                        break;
                    case "previous":
                        if (fb_flag == 1)
                        {
                            //   MyRobot.Speak("here is your timeline");
                            SendKeys.Send("k");

                        }
                        break;
                    case "new status":
                        if (fb_flag == 1)
                        {
                            //MyRobot.Speak("here is your timeline");
                            SendKeys.Send("p");

                        }
                        break;
                    case "like it":
                    case "unlike it":
                        if (fb_flag == 1)
                        {
                            // MyRobot.Speak("here is your timeline");
                            SendKeys.Send("l");

                        }
                        break;
                    case "comment":
                        flag = 1;
                        c_flag = 1;
                        if (fb_flag == 1)
                        {
                            //  MyRobot.Speak("here is your timeline");
                            SendKeys.Send("c");

                        }
                        break;
                    case "post it":
                        c_flag = 1;
                        if (fb_flag == 1)
                        {
                            //MyRobot.Speak("here is your timeline");
                            SendKeys.Send("{ENTER}");

                        }
                        break;
                    //Chrome shortcuts

                    case "new tab":
                        if (chrome_flag == 1)
                        {
                            MyRobot.Speak("opening new tab");
                            SendKeys.Send("^t");
                        }
                        break;

                    case "switch tab":
                        if (chrome_flag == 1)
                        {
                            MyRobot.Speak("switching tab");
                            SendKeys.Send("^" + i);
                            i++;

                        }
                        break;
                    case "bookmark it":
                        if (chrome_flag == 1)
                        {
                            MyRobot.Speak("okay sir Bookmark added");
                            SendKeys.Send("^d");

                        }
                        break;
                    case "show my history":
                        if (chrome_flag == 1)
                        {
                            MyRobot.Speak("your chrome history");
                            SendKeys.Send("^h");

                        }
                        break;
                    case "save this page":
                        if (chrome_flag == 1)
                        {
                            MyRobot.Speak("saving the page");
                            SendKeys.Send("^s");
                            SendKeys.Send("{ENTER}");


                        }
                        break;
                    case "reload":
                        if (chrome_flag == 1)
                        {
                            MyRobot.Speak("reloading the page");
                            SendKeys.Send("^r");

                        }

                        break;

                    case "find":
                        {
                            SendKeys.Send("^f");
                            flag = 1;
                            //type();
                        }
                        break;


                    default:
                        MyRobot.Speak("sorry didn't catch that");
                        break;
                }

            }
            
        }
        private void type(string speech)
        {
            char ch;
           // main_flag=0;
            if (type_flag==1)
            {
                for (int i = 0; i<speech.Length ; i++)
                {
                    for (ch = 'a'; ch < 'z'; ch++)
                    { 
                        if (speech[i] == ch)
                        {
                            SendKeys.Send(ch + "");
                        }
                
                    }
                    
                }

            }
           // main_flag=1;
        }
        
       
        private void StopWindow()
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName(ProcWindow);
            foreach (System.Diagnostics.Process proc in procs)
            {
                proc.CloseMainWindow();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // StreamReader sr = new StreamReader(@"F:\keywords.txt");

                SRE.SetInputToDefaultAudioDevice();
                SRE.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"E:\commands_original.txt")))));
                // SRE.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(sr.ReadToEnd()))));

                SRE.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SRE_SpeechRecognized);
              //  SRE.RecognizeAsync(RecognizeMode.Multiple);
                cal_flag = 0;
                main_flag = 1;
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SRE.RecognizeAsync(RecognizeMode.Multiple);
              
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SRE.RecognizeAsyncStop();

        }
    }
}
