namespace SchoolManagement_Logic.DbAccesss
{
    public interface IConnection
    {
        Task ConncetionToDB(string connectionId = "Default");
    }
}