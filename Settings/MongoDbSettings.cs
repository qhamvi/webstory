namespace webstory.Settings
{
    public class  MongoDbSettings
    {
        public string Host {get;set;}
        public int Port { get; set; }
        public string User {get; set;}
        public string Password {get; set;}
        public string ConnectionString 
        { 
            get
            { 
                
                return "mongodb+srv://qhamvi:W4fnTIKr3eO5AEDh@cluster0.vcaxilj.mongodb.net/?retryWrites=true&w=majority"; //--mongo atlas
            }
        }
    }
}