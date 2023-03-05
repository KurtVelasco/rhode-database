using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace RhodeDatabase_wpf
{
    class ReadData
    {
        private string DatabaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database_text", "ArknightDatabase.txt");
        private string ProfileFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database_text", "ArknightProfiles.txt");
        private string Databasetxt = "";
        private string Profiletxt = "";
        public dynamic Dynamic_Database = "";
        public dynamic Dynamic_Profile = "";

        public ReadData()
        {
            Read_Operator_Database();
            Read_Operator_Profile();
            Dynamic_JSON();
        }

        public void Read_Operator_Database()
        {
            Databasetxt = File.ReadAllText(DatabaseFilePath);
        }

        public void Read_Operator_Profile()
        {
            Profiletxt = File.ReadAllText(ProfileFilePath);
        }
        public void Dynamic_JSON()
        {
            Dynamic_Database = JsonConvert.DeserializeObject(Databasetxt);
            Cleartxt();
        }
        public void Cleartxt()
        {
            Databasetxt = string.Empty;
            Profiletxt = string.Empty;
        }
    }
}
