using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhodeDatabase_wpf
{
    class CompileData
    {
        private dynamic Database = "";
        public string Name = "";
        public string PrefabKey = "";
        public int Rarity = 0;
        public string Nation = "";
        public string Group = "";
        public string Team = "";
        public string Position = "";
        public string Profession = "";
        public string SubProfession = "";
        public string Obtain = "";

        public int MaxHp = 0;
        public int atk = 0;
        public int def = 0;
        public int MagicRes = 0;
        public int cost = 0;
        public int block = 0;
        public int atkspd = 0;
        public int respawn = 0;
        //public string Team = "";
        public CompileData()
        {

        }
        public void Input_Dynamic_Files(dynamic InputDatabase)
        {
            Database = InputDatabase;
            CompileInformation_Database();
        }
        public void CompileInformation_Database()
        {
            Name = Database.Value.name;
            PrefabKey = Database.Value.phases[0].characterPrefabKey;
            Nation = Database.Value.nationId;
            Group = Database.Value.groupId;
            Team = Database.Value.teamId;
            Position = Database.Value.position;
            Rarity = Database.Value.rarity + 1;
            Profession = Database.Value.profession;
            Profession = Database.Value.subProfessionId;
            Obtain = Database.Value.itemObtainApproach;
            ///////////
            MaxHp = Database.Value.phases[2].attributesKeyFrames[1].data.maxHp;
        }
    }
}
