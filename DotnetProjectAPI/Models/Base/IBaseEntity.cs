namespace DotnetProjectAPI.Models.Base
{
    public interface IBaseEntity
    {
        Guid id { get; set; }
        DateTime? dateCreated { get; set; }
        DateTime? dateModified { get; set; }
    }
}
