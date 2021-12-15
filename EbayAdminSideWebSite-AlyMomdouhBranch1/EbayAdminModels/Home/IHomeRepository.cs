namespace Models
{
    using System.Threading.Tasks;

    public interface IHomeRepository
    {
        Task<DataCount> GetDataCountAsync();
    }
}
