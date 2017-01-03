using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SemaFlags.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SemaFlags.ViewModels
{
    public class GroupView {

        public GroupView() {
            Groups = new List<Group>();
            Nodes = new List<Node>();
            Users = new List<User>();
        }
        public List<Group> Groups;
        public List<Node> Nodes;
        public List<User> Users;
        public int userId;
    }
}
