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

namespace SemaFlagsTray
{
    static class SemaFlagsTray
    {

        static HttpClient client = new HttpClient();
        static List<Group> Groups = new List<Group>();
        static List<Node> Nodes = new List<Node>();
        static List<User> Users = new List<User>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmBoard());
            RunAsync().Wait();
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
            catch (Exception ex) {
                Console.WriteLine("GetJSONasStream for Node failed with:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Dear sir, press any key to finish!");
                Console.ReadKey();
                return ;

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
    }
}
