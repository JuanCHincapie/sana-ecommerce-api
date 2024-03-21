namespace Ecommerce.Domain.Shared
{
    public sealed class Response<T>
    {
        public bool Successful { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static Response<T> Success(T data) => new() { Successful = true, Data = data };

        public static Response<T> Failure(string message) => new() { Message = message };
    }
}
