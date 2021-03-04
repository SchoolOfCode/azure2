namespace LibraryApi.Queries
{
    public class CommandText : ICommandText
    {
        public string GetBooks => "SELECT * FROM Books";
        public string GetBookById => "SELECT * FROM Books WHERE Id = @Id";
        public string AddBook => "INSERT INTO Books (Title, Author) VALUES (@Title, @Author)";
        public string UpdateBook => "UPDATE Books SET Title = @Title, Author = @Author WHERE Id = @Id";
        public string RemoveBook => "DELETE FROM Books WHERE Id = @Id";
    }
}