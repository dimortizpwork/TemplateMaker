namespace Gimme.Host.Lambda
{
    public interface IOracleSettings
    {
        string OracleUserName { get; set; }
        string OraclePassword { get; set; }
        string OracleHostName { get; set; }
        string OracleConnectionString { get; set; }
    }
}