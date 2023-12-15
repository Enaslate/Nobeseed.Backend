namespace Nobeseed.Application.Interfaces
{
    public interface IBaseResponse<T>
    {
        T? Data { get; set; }
    }
}
