using Nobeseed.Application.Interfaces;
using Nobeseed.Domain.Enum;

namespace Nobeseed.Application.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public bool Success { get; set; }
        public string Description { get; set; } = null!;
        public T? Data { get; set; }
    }
}
