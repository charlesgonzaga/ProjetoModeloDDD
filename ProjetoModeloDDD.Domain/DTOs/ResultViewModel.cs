namespace ProjetoModeloDDD.Domain.DTOs
{
    public class ResultViewModel<T>
    {
        public bool Success => string.IsNullOrEmpty(Message);
        public T Result { get; private set; }
        public string Message { get; private set; }

        public ResultViewModel()
        {
        }

        public ResultViewModel(T value)
        {
            Result = value;
        }

        public ResultViewModel<T> AddResult(T result)
        {
            Result = result;
            return this;
        }

        public ResultViewModel<T> AddMessage(string message)
        {
            Message = message;
            return this;
        }
    }
}
