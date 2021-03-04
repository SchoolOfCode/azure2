namespace LibraryApi.Queries
{
    public interface ICommandText
    {
        string GetBooks { get; }
        string GetBookById { get; }
        string AddBook { get; }
        string UpdateBook { get; }
        string RemoveBook { get; }
    }
}