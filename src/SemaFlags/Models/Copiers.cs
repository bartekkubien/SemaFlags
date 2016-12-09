using SemaFlags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class BoardCopier : IBaseCopier<IEntity>
    {
        public IEntity CopyProperties(IEntity objTo, IEntity objFrom)
        {
            return CopyBoardProperties((Board)objTo, (Board)objFrom);
        }

        virtual protected Board CopyBoardProperties(Board objTo, Board objFrom)
        {
            if (objFrom.Name != objTo.Name) objTo.Name = objFrom.Name;
            if (objFrom.Description != objTo.Description) objTo.Description = objFrom.Description;
            if (objFrom.SequenceNumber != 0 && objFrom.SequenceNumber != objTo.SequenceNumber) objTo.SequenceNumber = objFrom.SequenceNumber;
            if (objFrom.Color != 0 && objFrom.Color != objTo.Color) objTo.Color = objFrom.Color;
            if (objFrom.BoardOwnerId != 0) objTo.BoardOwnerId = objFrom.BoardOwnerId;
            return objTo;
        }

    }

    public class NodeCopier : IBaseCopier<IEntity>
    {
        public IEntity CopyProperties(IEntity objTo, IEntity objFrom)
        {
            return CopyNodeProperties((Node)objTo, (Node)objFrom);
        }

        Node CopyNodeProperties(Node objTo, Node objFrom)
        {
            if (objFrom.Name != objTo.Name) objTo.Name = objFrom.Name;
            if (objFrom.Description != objTo.Description) objTo.Description = objFrom.Description;
            if (objFrom.SequenceNumber != 0 && objFrom.SequenceNumber!= objTo.SequenceNumber) objTo.SequenceNumber = objFrom.SequenceNumber;
            if (objFrom.Color != 0 && objFrom.Color != objTo.Color) objTo.Color = objFrom.Color;
            if (objFrom.GroupId != 0) objTo.GroupId = objFrom.GroupId;
            return objTo;
        }
    }

    public class GroupCopier : IBaseCopier<IEntity>
    {
        public IEntity CopyProperties(IEntity objTo, IEntity objFrom)
        {
            return CopyGroupProperties((Group)objTo, (Group)objFrom);
        }

        Group CopyGroupProperties(Group objTo, Group objFrom)
        {
            if (objFrom.Name != objTo.Name) objTo.Name = objFrom.Name;
            if (objFrom.Description != objTo.Description) objTo.Description = objFrom.Description;
            if (objFrom.SequenceNumber != 0 && objFrom.SequenceNumber != objTo.SequenceNumber) objTo.SequenceNumber = objFrom.SequenceNumber;
            if (objFrom.Color != 0 && objFrom.Color != objTo.Color) objTo.Color = objFrom.Color;
            if (objFrom.BoardId != 0) objTo.BoardId = objFrom.BoardId;
            return objTo;
        }
    }

    public class UserBoardAffiliationCopier : IBaseCopier<IEntity>
    {
        public IEntity CopyProperties(IEntity objTo, IEntity objFrom)
        {
            return CopyUserBoardAffiliationProperties((UserBoardAffiliation)objTo, (UserBoardAffiliation)objFrom);
        }

        UserBoardAffiliation CopyUserBoardAffiliationProperties(UserBoardAffiliation objTo, UserBoardAffiliation objFrom)
        {
            if (objFrom.userId != 0 && objFrom.userId != objTo.userId) objTo.userId = objFrom.userId;
            if (objFrom.boardId != 0 && objFrom.boardId != objTo.boardId) objTo.boardId = objFrom.boardId;
            return objTo;
        }
    }

}
