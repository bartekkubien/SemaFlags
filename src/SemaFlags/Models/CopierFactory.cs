using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.Models
{
    public static class CopierFactory
    {
        public static IBaseCopier CreateCopier(String type) {

            switch (type)
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
    }
}
