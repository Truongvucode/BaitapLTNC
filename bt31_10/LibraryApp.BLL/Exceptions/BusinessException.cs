namespace LibraryApp.BLL.Exceptions
{
    /// <summary>
    /// Ngoại lệ xử lý vi phạm quy tắc nghiệp vụ
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
