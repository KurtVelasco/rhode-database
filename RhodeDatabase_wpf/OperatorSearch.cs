using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhodeDatabase_wpf
{
    class OperatorSearch
    {
        private string SearchedOperator = "";
        private dynamic Operator_Database = "";
        public bool flag = true;
        public OperatorSearch()
        {

        }
        public void SearchOperator(string InputName, dynamic UInput_Data)
        {
            SearchedOperator = InputName.ToLower();
            SearchedOperator.ToLower();
            Operator_Database = UInput_Data;
            DataSearch();
        }
        public void DataSearch()
        {
            foreach (var items in Operator_Database)
            {
                string ValueName = items.Value.name;
                string lowerValue = ValueName.ToLower();
                string lower = SearchedOperator;
                if (lowerValue == lower)
                {
                    Operator_Database = items;
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }

            }
        }
        public dynamic Return_Data()
        {
            return Operator_Database;
        }
    }
}
