using SemaFlags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.DAL
{
    public class UnitOfWork
    {
        private SemaFlagsDBContext context;
        private GenericRepository<Board> boardRepository;
        private GenericRepository<Group> groupRepository;
        private GenericRepository<Node> nodeRepository;
        private GenericRepository<UserBoardAffiliation > userBoardAffiliationRepository;
        private UserRepository userRepository;
        
        public UnitOfWork(SemaFlagsDBContext ctx)
        {
            context = ctx;
        }

        public GenericRepository<Board> BoardRepository {
            get {
                if (boardRepository == null) {
                    boardRepository = new GenericRepository<Board>(context.Boards);
                }
                return boardRepository;
            }
        }

        public GenericRepository<Group> GroupRepository
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GenericRepository<Group>(context.Groups);
                }
                return groupRepository;
            }
        }

        public GenericRepository<Node> NodeRepository
        {
            get
            {
                if (nodeRepository == null)
                {
                    nodeRepository = new GenericRepository<Node>(context.Nodes);
                }
                return nodeRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context.Users);
                }
                return userRepository;
            }
        }

        public GenericRepository<UserBoardAffiliation> UserBoardAffiliationRepository
        {
            get
            {
                if (userBoardAffiliationRepository == null)
                {
                    userBoardAffiliationRepository = new GenericRepository<UserBoardAffiliation>(context.UserBoardAffiliations );
                }
                return userBoardAffiliationRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
