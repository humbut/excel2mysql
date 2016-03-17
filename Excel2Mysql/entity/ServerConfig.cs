namespace Excel2Mysql.entity
{
    class ServerConfig
    {
        public string host { get; set; }

        public string port { get; set; }

        public string user { get; set; }

        public string password { get; set; }

        public string database { get; set; }

        public string desc { get; set; }

        public string charset {get;set;}

        public string hookUrl { get; set; }
    }

}
