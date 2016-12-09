namespace SemaFlags.Models
{
    //public interface IBaseCopier<TEntity>
    //{
    //    TEntity CopyProperties(TEntity objTo, TEntity objFrom );
    //}

    public interface IBaseCopier<TEntity> where TEntity : class, IEntity
    {
        //Base CopyProperties(Base objTo, Base objFrom);
        TEntity CopyProperties(TEntity objTo, TEntity objFrom);
    }
}
