
namespace OrdemServico.Domain.Dtos.Http
{
    public class ServerHttpResponse<T> where T : class
    {
        public bool Success { get; set; } 
        public string ErrorMessage { get; set; } = "";
        public T? Content { get; set; } = null;
    }
}
