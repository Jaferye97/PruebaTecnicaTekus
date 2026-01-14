namespace RepositoryEntityFrameworkSqlServerV2.Entities.Constants;

public interface IEntity<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}

