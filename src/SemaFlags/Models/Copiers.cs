using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class BoardCopier : IBaseCopier
    {
        public Base CopyProperties(Base objTo, Base objFrom)
        {
            return CopyBoardProperties((Board)objTo, (Board)objFrom);
        }

        Board CopyBoardProperties(Board objTo, Board objFrom)
        {
            if (objFrom.Name != objTo.Name) objTo.Name = objFrom.Name;
            if (objFrom.Description != objTo.Description) objTo.Description = objFrom.Description;
            if (objFrom.SequenceNumber != 0 && objFrom.SequenceNumber != objTo.SequenceNumber) objTo.SequenceNumber = objFrom.SequenceNumber;
            if (objFrom.Color != 0 && objFrom.Color != objTo.Color) objTo.Color = objFrom.Color;
            if (objFrom.BoardOwnerId != 0) objTo.BoardOwnerId = objFrom.BoardOwnerId;
            return objTo;
        }
    }

    public class NodeCopier : IBaseCopier
    {
        public Base CopyProperties(Base objTo, Base objFrom)
        {
            return CopyBoardProperties((Node)objTo, (Node)objFrom);
        }

        Node CopyBoardProperties(Node objTo, Node objFrom)
        {
            if (objFrom.Name != objTo.Name) objTo.Name = objFrom.Name;
            if (objFrom.Description != objTo.Description) objTo.Description = objFrom.Description;
            if (objFrom.SequenceNumber != 0 && objFrom.SequenceNumber!= objTo.SequenceNumber) objTo.SequenceNumber = objFrom.SequenceNumber;
            if (objFrom.Color != 0 && objFrom.Color != objTo.Color) objTo.Color = objFrom.Color;
            if (objFrom.GroupId != 0) objTo.GroupId = objFrom.GroupId;
            return objTo;
        }
    }

    public class GroupCopier : IBaseCopier
    {
        public Base CopyProperties(Base objTo, Base objFrom)
        {
            return CopyBoardProperties((Group)objTo, (Group)objFrom);
        }

        Group CopyBoardProperties(Group objTo, Group objFrom)
        {
            if (objFrom.Name != objTo.Name) objTo.Name = objFrom.Name;
            if (objFrom.Description != objTo.Description) objTo.Description = objFrom.Description;
            if (objFrom.SequenceNumber != 0 && objFrom.SequenceNumber != objTo.SequenceNumber) objTo.SequenceNumber = objFrom.SequenceNumber;
            if (objFrom.Color != 0 && objFrom.Color != objTo.Color) objTo.Color = objFrom.Color;
            if (objFrom.BoardId != 0) objTo.BoardId = objFrom.BoardId;
            return objTo;
        }
    }

    public class UserBoardAffiliationCopier : IBaseCopier
    {
        public Base CopyProperties(Base objTo, Base objFrom)
        {
            return CopyBoardProperties((UserBoardAffiliation)objTo, (UserBoardAffiliation)objFrom);
        }

        UserBoardAffiliation CopyBoardProperties(UserBoardAffiliation objTo, UserBoardAffiliation objFrom)
        {
            if (objFrom.userId != 0 && objFrom.userId != objTo.userId) objTo.userId = objFrom.userId;
            if (objFrom.boardId != 0 && objFrom.boardId != objTo.boardId) objTo.boardId = objFrom.boardId;
            return objTo;
        }
    }

}
