namespace pa4_lfcoffman
{
    public class ConnectionString
    {
        public string cs {get; set;}
        public ConnectionString(){
            string server = "w3epjhex7h2ccjxx.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "oraen47cbvx8z1bm";
            string username = "y24rkydfxh6s7s5f";
            string password = "cd2iolr5ritqtr0f";
            string port = "3306";
            
            cs=$"server={server};user={username};database={database};port={port};password={password}";
        }
    }
}