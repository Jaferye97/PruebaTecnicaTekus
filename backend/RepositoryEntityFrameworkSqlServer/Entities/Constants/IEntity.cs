namespace RepositoryEntityFrameworkSqlServer.Entities.Constants
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
