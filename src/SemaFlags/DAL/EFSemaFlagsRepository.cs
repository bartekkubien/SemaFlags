using System;
using System.Collections.Generic;
using System.Linq;
using SemaFlags.Models;

namespace SemaFlags.DAL

{
    //public class EFSemaFlagsRepository : ISemaFlagsRepository
    //{
    //    private SemaFlagsDBContext context;

    //    public EFSemaFlagsRepository(SemaFlagsDBContext ctx)
    //    {
    //        context = ctx;
    //    }
    //   public IQueryable<Board> Boards => context.Boards;
    //    public void SaveElement(Board element)
    //    {

    //        if (element.Id == 0)

    //            context.Boards.Add(element);
    //        else
    //        {
    //            Board dbEntry = context.Boards.FirstOrDefault(e => e.Id == element.Id);
    //            if (dbEntry != null) {
    //                dbEntry.Name = element.Name;
    //                dbEntry.Description = element.Name;
    //                dbEntry.Color = element.Color;
    //                dbEntry.SequenceNumber = element.SequenceNumber;
    //            }
    //        }
    //        context.SaveChanges();
    //    }

    //    public Base RemoveElement(int id)
    //    {
    //        Board dbEntry = context.Boards.FirstOrDefault(e => e.Id == id);
    //        if (dbEntry != null) {
    //            context.Boards.Remove(dbEntry);
    //            context.SaveChanges();
    //        }
    //        return dbEntry;
    //    }
    //    public IQueryable<Group> Groups => context.Groups;
    //    public void SaveGroup(Group element)
    //    {

    //        if (element.Id == 0)

    //            context.Groups.Add(element);
    //        else
    //        {
    //            Group dbEntry = context.Groups.FirstOrDefault(e => e.Id == element.Id);
    //            if (dbEntry != null)
    //            {
    //                dbEntry.Name = element.Name;
    //                dbEntry.Description = element.Name;
    //                dbEntry.Color = element.Color;
    //                dbEntry.BoardId = element.BoardId;
    //                dbEntry.SequenceNumber = element.SequenceNumber;
    //            }
    //        }
    //        context.SaveChanges();
    //    }

    //    public Base RemoveGroup(int id)
    //    {
    //        Group dbEntry = context.Groups.FirstOrDefault(e => e.Id == id);
    //        if (dbEntry != null)
    //        {
    //            context.Groups.Remove(dbEntry);
    //            context.SaveChanges();
    //        }
    //        return dbEntry;
    //    }

    //    public IQueryable<Node> Nodes => context.Nodes;
    //    public void SaveNode(Node element)
    //    {

    //        if (element.Id == 0)

    //            context.Nodes.Add(element);
    //        else
    //        {
    //            Node dbEntry = context.Nodes.FirstOrDefault(e => e.Id == element.Id);
    //            if (dbEntry != null)
    //            {
    //                dbEntry.Name = element.Name;
    //                dbEntry.Description = element.Name;
    //                dbEntry.Color = element.Color;
    //                dbEntry.SequenceNumber = element.SequenceNumber;
    //                dbEntry.GroupId = element.GroupId;
    //                dbEntry.AssignedUserId = element.AssignedUserId;
    //            }
    //        }
    //        context.SaveChanges();
    //    }

    //    public Base RemoveNode(int id)
    //    {
    //        Node dbEntry = context.Nodes.FirstOrDefault(e => e.Id == id);
    //        if (dbEntry != null)
    //        {
    //            context.Nodes.Remove(dbEntry);
    //            context.SaveChanges();
    //        }
    //        return dbEntry;
    //    }

    //    public IQueryable<User> Users => context.Users;
    //    public void SaveUser(User element)
    //    {

    //        if (element.Id != 0 )

    //            context.Users.Add(element);
    //        else
    //        {
    //            User dbEntry = context.Users.FirstOrDefault(e => e.Id == element.Id);
    //            if (dbEntry != null)
    //            {
    //                dbEntry.Name = element.Name;
    //                dbEntry.Description = element.Name;
    //                dbEntry.Color = element.Color;
    //                dbEntry.SequenceNumber = element.SequenceNumber;
    //            }
    //        }
    //        context.SaveChanges();
    //    }

    //    public User RemoveUser(int id)
    //    {
    //        User dbEntry = context.Users.FirstOrDefault(e => e.Id == id);
    //        if (dbEntry != null)
    //        {
    //            context.Users.Remove(dbEntry);
    //            context.SaveChanges();
    //        }
    //        return dbEntry;
    //    }
    //}
}
