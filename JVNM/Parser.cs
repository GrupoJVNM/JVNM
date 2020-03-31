using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JVNM
{
    class Parser
    {

        public static MiniSQLQuery Parse(string miniSQLQuery)
        {

            //const string selectPattern = "SELECT ([\\w,\\s]+) FROM (\\w+)\\s*;";
            const string selectPattern = "SELECT [(\\w+)](\\w+)(\\,(\\s)?(\\w+))? FROM (\\w+) WHERE (\\w+)(\\s)?[=,<,>](\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)?;";
            const string selectAllPattern = "SELECT \\* FROM (\\w+) WHERE (\\w+)(\\s)?[=,<,>](\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)?;";
            const string selectWithOutCPattern = "SELECT [(\\w+)](\\w+)(\\,(\\s)?(\\w+))? FROM (\\w+);";
            const string selectAllWithOutCPattern = "SELECT \\* FROM (\\w+);";

            const string insertPattern = "INSERT INTO (\\w+) VALUES (\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?([0-9]+)?(\\,(\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)?)?;";
            const string deletePattern = "DELETE FROM (\\w+) WHERE (\\w+)(\\s)?[=,<,>](\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?([0-9]+)?(( AND )((\\w+)(\\s)?[=,<,>](\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)?)?;";
            const string updatePattern = "UPDATE (\\w+) SET (\\w+)(\\s)?=(\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)? WHERE (\\w+)(\\s)?[=,<,>](\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)?(( AND )((\\w+)(\\s)?[=,<,>](\\s)?(\\'[A-Za-z0-9(\\s)(\\.)(\\,)]+\\')?((\\-)?[0-9]+)?))?;";

            const string createPattern = "";
            const string dropPattern = "";

            //Select
            Match match = Regex.Match(miniSQLQuery, selectPattern);
            if (match.Success)
            {
                List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
                string table = match.Groups[2].Value;
                List<string> condition = Condition(match.Groups[3].Value);
                TableColumn condiC = new TableColumn(condition[0], );
                //for (int i=0; i< table.GetListTableColumn(); i++)
                //{
                //    if (condition[0].Equals(table.GetListTableColumn()[i].Name))
                //    {
                //        condiC = table.GetListTableColumn()[i].Name;
                //    }
                //}
                
                DataComparator compare;
                if (condition[1].Equals("="))
                {
                    compare = DataComparator.Equal;
                } 
                else if (condition[1].Equals(">"))
                {
                    compare = DataComparator.Bigger;
                } 
                else
                {
                    compare = DataComparator.Less;
                }
                string value = condition[2];

                return new Select(table, columnNames, compare, condiC, value);
            }

            //SelectWithOutC
            match = Regex.Match(miniSQLQuery, selectWithOutCPattern);
            if (match.Success)
            {
                List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
                string table = match.Groups[2].Value;
                return new SelectWithOutC(table, columnNames);
            }

            //SelectAllWithOutC
            match = Regex.Match(miniSQLQuery, selectAllWithOutCPattern);
            if (match.Success)
            {
                string table = match.Groups[2].Value;
                return new SelectAllWithOutC(table);
            }

            //Insert
            match = Regex.Match(miniSQLQuery, insertPattern);
            if (match.Success)
            {
                //...
            }

            //Delete
            match = Regex.Match(miniSQLQuery, deletePattern);
            if (match.Success)
            {
                //  List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
                string table = match.Groups[2].Value;
                //  return new Select(table, columnNames);
            }

            //Update
            match = Regex.Match(miniSQLQuery, updatePattern);
            if (match.Success)
            {
                //  List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
                string table = match.Groups[2].Value;
                //  return new Select(table, columnNames);
            }

            return null;
        }

        static List<string> CommaSeparatedNames(string text)
        {
            string t = text.Trim(' ');
            string[] columnNames = t.Split(',');
                      
            return columnNames.ToList();
        }

        static List<string> Condition(string text)
        {
            List<string> t = text.Split();

            return t;
        }
    }
}

