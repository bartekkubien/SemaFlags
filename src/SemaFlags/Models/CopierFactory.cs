using SemaFlags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public class CopierFactory
    {

        //public IBaseCopier<TEntity> CreateCopier()
        //{
        //    return new BoardCopier();
        //}

        internal static IBaseCopier<IEntity> CreateCopier(Type type)
        {
            switch (type.ToString())
            {
                case "SemaFlags.Models.Board":
                    return new BoardCopier();
                case "SemaFlags.Models.Node":
                    return new NodeCopier();
                case "SemaFlags.Models.Group":
                    return new GroupCopier();
                //case "SemaFlags.Models.UserBoardAffiliation":
                //return new UserBoardAffiliationCopier();
                default:
                    return null;
            }
        }

        //public IBaseCopier<T> CreateCopier<T>(String type)
        //{

        //    switch (type)
        //    {
        //        case "SemaFlags.Models.Board":
        //            return (IBaseCopier<T>)new BoardCopier();
        //        case "SemaFlags.Models.Node":
        //            return new NodeCopier();
        //        case "SemaFlags.Models.Group":
        //            return new GroupCopier();
        //        //case "SemaFlags.Models.UserBoardAffiliation":
        //        //return new UserBoardAffiliationCopier();
        //        default:
        //            return null;
        //    }
        //}
    }
}
