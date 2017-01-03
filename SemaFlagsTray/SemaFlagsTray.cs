using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemaFlagsTray.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing;

namespace SemaFlagsTray
{
    class SemaFlagsTray
    {

        static HttpClient client = new HttpClient();
        static List<Group> Groups = new List<Group>();
        static List<Node> Nodes = new List<Node>();
        static List<User> Users = new List<User>();

        static MainWindow appWindow;

        #region NotificationArea
        private static NotifyIcon trayIcon;
        private static ContextMenu trayMenu;
        #endregion NotificationArea

        #region Properties
        public bool Running { get; set; }
        public bool Visible {
            get {
                return SemaflagsWindow.Visibility == System.Windows.Visibility.Visible;
            }
        }

        public MainWindow SemaflagsWindow {
            get {
                if (appWindow == null)
                    appWindow = new MainWindow();
                return appWindow;
            }
        }

        #endregion Properties

        #region Helpers
        private void ShowSemaFlags()
        {
            SemaflagsWindow.Show();
        }

        private void HideSemaFlags()
        {
            SemaflagsWindow.Hide();
        }
        #endregion Helpers

        #region Events
        private void ExitSemaFlags(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            Running = false;
        }

        private void Click_SemaFlagsTray(object Sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs args = (System.Windows.Forms.MouseEventArgs)e;
            if (args.Button == MouseButtons.Left) {
                if (!Visible)
                    ShowSemaFlags();
                else
                    HideSemaFlags();
            }

           
            // Close the form, which closes the application.

        }

        #endregion Events

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SemaFlagsTray app = new SemaFlagsTray();
            while (app.Running)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
            Application.Exit();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //string jsongroups = await GetJSONasString ("api/APIGroup/0");
            //string jsontext = "[{\"sequenceNumber\":0,\"color\":0,\"boardId\":0,\"id\":0,\"name\":\"Dev\",\"description\":\"Development machines\"},{\"sequenceNumber\":0,\"color\":0,\"boardId\":0,\"id\":1,\"name\":\"QA\",\"description\":\"QA machines\"}]";
            //string jsontext2 = "{\"sequenceNumber\":0,\"color\":0,\"boardId\":0,\"id\":0,\"name\":\"Dev\",\"description\":\"Development machines\"}";
            //string jsontext3 = "{\"Color\":0,\"Description\":\"Development machines\",\"Id\":0,\"Name\":\"Dev\",\"SequenceNumber\":0,\"BoardId\":0}";
            //string js = "[{\"Id\":0,\"Name\":\"Dev\",\"Description\":\"Development machines\",\"SequenceNumber\":0,\"Color\":0,\"BoardId\":0},{\"Id\":1,\"Name\":\"QA\",\"Description\":\"QA machines\",\"SequenceNumber\":0,\"Color\":0,\"BoardId\":0}]";
            //string js2 = "{\"Id\":1,\"Name\":\"QA\",\"Description\":\"QA machines\",\"SequenceNumber\":0,\"Color\":0,\"BoardId\":0}";

            //MemoryStream myStream1 = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(js));
            //Group ge = new Models.Group();
            //ge.Name = "Dev";
            //ge.Description = "Development machines";
            //MemoryStream myStream = new MemoryStream();
            System.IO.Stream GroupsStream = null;
            try
            {
                GroupsStream = await GetJSONasStream("api/APIGroup/9");
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetJSONasStream for Group failed with:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Dear sir, press any key to finish!");
                Console.ReadKey();
                return;
            }

            DataContractJsonSerializer groupSerializer = new DataContractJsonSerializer(typeof(Group[]));
            GroupsStream.Position = 0;
            Group[] groupArray = (Group[])groupSerializer.ReadObject(GroupsStream);

            List<Task<System.IO.Stream>> tasks = new List<Task<System.IO.Stream>>();
            foreach (Group currentGroup in groupArray)
            {
                tasks.Add(GetJSONasStream("api/APINode/" + currentGroup.Id));
            }
            Console.WriteLine("Tasks added!");
            //tasks.Add(ThrowException());

            Groups.AddRange(groupArray);
            DataContractJsonSerializer nodeSerializer = new DataContractJsonSerializer(typeof(Node[]));
            DataContractJsonSerializer userSerializer = new DataContractJsonSerializer(typeof(User[]));

            try
            {
                foreach (Task<System.IO.Stream> t in tasks)
                {
                    System.IO.Stream nodesStream = await t;
                    Nodes.AddRange((Node[])nodeSerializer.ReadObject(nodesStream));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetJSONasStream for Node failed with:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Dear sir, press any key to finish!");
                Console.ReadKey();
                return;

            }


            System.IO.Stream usersStream = await GetJSONasStream("api/APIUser/");
            User[] usersArray = (User[])userSerializer.ReadObject(usersStream);
            Users.AddRange(usersArray);

            foreach (Group group in Groups)
            {
                Console.WriteLine(group.Id + "\t" + group.Name + "\t" + group.Description);
                foreach (Node node in Nodes.Where(n => n.GroupId == group.Id))
                {
                    Console.WriteLine(" - " + node.Id + "\t" + node.Name + "\t" + node.Description + "\t" + (node.AssignedUserId > 0 ? "Assigned user: " + Users.FirstOrDefault(u => u.Id == node.AssignedUserId).Name : ""));
                }
                Console.WriteLine("==================================================================");
            }

            Console.WriteLine("Dear sir, press any key to finish!");
            Console.ReadKey();
        }

        static async Task<String> GetJSONasString(string path)
        {
            String json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        static async Task<System.IO.Stream> GetJSONasStream(string path)
        {
            Console.WriteLine("Preparing " + path);
            String json;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                System.IO.Stream ret = await response.Content.ReadAsStreamAsync();
                Console.WriteLine("Got " + path);
                return ret;
            }
            return null;
        }

        static async Task<System.IO.Stream> ThrowException()
        {
            throw new Exception("No can do");
            return null;

        }

        public SemaFlagsTray()
        {
            Running = true;

            trayMenu = new ContextMenu();

            MenuItem exitMenuItem = new MenuItem();
            exitMenuItem.Index = 0;
            exitMenuItem.Text = "E&xit";
            exitMenuItem.Click += new System.EventHandler(this.ExitSemaFlags);

            trayMenu.MenuItems.Add(exitMenuItem);

            System.ComponentModel.Container components = new System.ComponentModel.Container();
            trayIcon = new NotifyIcon(components);
            trayIcon.Text = "SemaFlags";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Visible = true;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Click += new System.EventHandler(this.Click_SemaFlagsTray);
        }
    }
}
