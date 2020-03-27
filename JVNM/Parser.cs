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

        public static Query Parse(string miniSQLQuery)
        {
            //const string selectPattern = "SELECT ([\\w,\\s]+) FROM (\\w+)\\s*;";
            const string selectPattern = "SELECT [*,(\\w+)](\\w+)(\\,(\\s)?(\\w+))? FROM (\\w+)( WHERE (\\w+)(\\s)?([<,>])?[=,<,>](\\s)?\'(\\w+)\\')?;";
            const string insertPattern = "INSERT INTO (\\w+)((\\s)?\\(\\w+(\\,(\\s)?(\\w+))?\\))? VALUES \\'\\w+\'(\\,(\\s)?\'(\\w+)\\')?;";
            const string deletePattern = "DELETE FROM (\\w+) WHERE (\\w+)(\\s)?([<,>])?[=,<,>](\\s)?\\'(\\w+)\\'(( AND )((\\w+)(\\s)?([<,>])?[=,<,>](\\s)?\'(\\w+)\\'))?;";
            const string updatePattern = "UPDATE (\\w+) SET (\\w+)(\\s)?=(\\s)?\\'(\\w+)\\'( WHERE (\\w+)(\\s)?([<,>])?[=,<,>](\\s)?\'(\\w+)\\'(( AND )((\\w+)(\\s)?([<,>])?[=,<,>](\\s)?\'(\\w+)\\'))?)?;";
            //Select
            Match match = Regex.Match(miniSQLQuery, selectPattern);
            if (match.Success)
            {
              //  List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
                string table = match.Groups[2].Value;
              //  return new Select(table, columnNames);
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

       /* static List<string> CommaSeparatedNames(string text)
        {
            return text;
        }*/
    }
}

