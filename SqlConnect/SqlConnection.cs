internal class SqlConnection
{
    private string sqlStringConnection;

    public SqlConnection()
    {
    }

    public SqlConnection(string sqlStringConnection)
    {
        this.sqlStringConnection = sqlStringConnection;
    }

    public bool State { get; internal set; }

    internal void Close()
    {
        throw new NotImplementedException();
    }

    internal void Open()
    {
        throw new NotImplementedException();
    }
}