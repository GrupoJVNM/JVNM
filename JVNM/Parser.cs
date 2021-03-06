﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JVNM
{
    public class Parser
    {

        public static MiniSQLQuery Parse(string miniSQLQuery)
        {


            const string selectPattern = "SELECT ([(\\w+)](\\w+)(\\,(\\s)?(\\w+))?) FROM (\\w+) WHERE (\\w+[<|=|>](.+));";
            const string selectAllPattern = "SELECT \\* FROM (\\w+) WHERE (\\w+[<|=|>](.+));";
            const string selectWithOutCPattern = "SELECT (((\\w+)(\\,(\\s)?(\\w+))+)?) FROM (\\w+);";
            const string selectAllWithOutCPattern = "SELECT \\* FROM (\\w+);";
            const string deletePattern = "DELETE\\s+FROM\\s+(\\w+)\\s+WHERE\\s+(\\w+[<|=|>](.+));";
            const string insertPattern = "INSERT\\s+INTO\\s+(\\w+)(?:|\\s+\\(([\\w=,]+)\\))\\s+VALUES\\s+\\((.+)\\);";
            const string updatePattern = "UPDATE (\\w+) SET (.+) WHERE (.+)(( AND )(.+))?;";
            const string createSecurity = "CREATE SECURITY PROFILE (\\w+);";
            const string dropSecurity = "DROP SECURITY PROFILE (\\w+);";
            const string grant = "GRANT (\\w+) ON (\\w+) TO (\\w+);";
            const string revoke = "REVOKE (\\w+) ON (\\w+) TO (\\w+);";
            const string dropPattern = "DROP TABLE (\\w+);";
            const string createTablePattern = "CREATE TABLE (\\w+) (\\((\\w+ \\w+)((\\,(\\s)?(\\w+ \\w+))+)?\\));";
            const string addUser = "ADD USER \\((.+)\\);";
            const string deleteUser = "DELETE USER (\\w+)";
            const string createDB = "(\\w+)\\,(\\w+)\\,(\\w+)";

            //Select
            Match match = Regex.Match(miniSQLQuery, selectPattern);
            if (match.Success)
            {
                string texto = match.Groups[1].Value;
                List<string> columnNames = CommaSeparatedNames(texto);
                string table = match.Groups[6].Value;


                DataComparator compare;
                if (match.Groups[7].Value.Contains("="))
                {
                    compare = DataComparator.Equal;

                }
                else if (match.Groups[7].Value.Contains(">"))
                {
                    compare = DataComparator.Bigger;

                }
                else
                {
                    compare = DataComparator.Less;

                }

                List<string> condition = Condition(match.Groups[7].Value);
                String column = condition[0];
                String value = condition[1];


                return new Select(table, columnNames, compare, column, value);
            }
            //SelectAll
            match = Regex.Match(miniSQLQuery, selectAllPattern);
            if (match.Success)
            {

                string table = match.Groups[1].Value;


                DataComparator compare;
                if (match.Groups[2].Value.Contains("="))
                {
                    compare = DataComparator.Equal;

                }
                else if (match.Groups[2].Value.Contains(">"))
                {
                    compare = DataComparator.Bigger;

                }
                else
                {
                    compare = DataComparator.Less;

                }

                List<string> condition = Condition(match.Groups[2].Value);
                String column = condition[0];
                String value = condition[1];


                return new SelectAll(table, compare, column, value);
            }

            //SelectWithOutC
            match = Regex.Match(miniSQLQuery, selectWithOutCPattern);
            if (match.Success)
            {
                string texto = match.Groups[1].Value;
                List<string> columnNames = CommaSeparatedNames(texto);
                string table = match.Groups[7].Value;
                return new SelectWithOutC(table, columnNames);
            }

            //SelectAllWithOutC
            match = Regex.Match(miniSQLQuery, selectAllWithOutCPattern);
            if (match.Success)
            {
                string table = match.Groups[1].Value;
                return new SelectAllWithOutC(table);
            }

            //Insert
            match = Regex.Match(miniSQLQuery, insertPattern);
            if (match.Success)
            {
                string table = match.Groups[1].Value;
                List<string> columnNames = insertSeparated(match.Groups[3].Value);
                return new Insert(table, columnNames);
            }

            //Delete
            match = Regex.Match(miniSQLQuery, deletePattern);
            if (match.Success)
            {

                string table = match.Groups[1].Value;


                DataComparator compare;
                if (match.Groups[2].Value.Contains("="))
                {
                    compare = DataComparator.Equal;

                }
                else if (match.Groups[2].Value.Contains(">"))
                {
                    compare = DataComparator.Bigger;

                }
                else
                {
                    compare = DataComparator.Less;

                }

                List<string> condition = Condition(match.Groups[2].Value);
                String column = condition[0];
                String value = condition[1];


                return new DeleteTuple(table, column, compare, value);
            }

            //Update
            match = Regex.Match(miniSQLQuery, updatePattern);
            if (match.Success)
            {
                //update
                string table = match.Groups[1].Value;
                //set
                List<string> set = updateSeparated(match.Groups[2].Value);
                string c = set[0];
                string d = set[1];


                DataComparator compare;
                if (match.Groups[3].Value.Contains("="))
                {
                    compare = DataComparator.Equal;

                }
                else if (match.Groups[3].Value.Contains(">"))
                {
                    compare = DataComparator.Bigger;

                }
                else
                {
                    compare = DataComparator.Less;

                }

                List<string> condition = updateSeparated(match.Groups[3].Value);
                string column = condition[0];
                string value = condition[1];


                return new Update(table, c, d, compare, value, column);

            }
            //Drop
            match = Regex.Match(miniSQLQuery, dropPattern);
            if (match.Success)
            {
                string table = match.Groups[1].Value;

                return new DropTable(table);
            }


            //create table 
            match = Regex.Match(miniSQLQuery, createTablePattern);
            if (match.Success)
            {
                string name = match.Groups[1].Value;
                List<String> columns = createTable(match.Groups[2].Value);

                return new CreateTable(name, columns);
            }

        
            //ADD USER
            match = Regex.Match(miniSQLQuery, addUser);
            if (match.Success)
            {
                List<String> p = insertSeparated(match.Groups[1].Value);


                return new AddUser(p[0], p[1], p[2]);
            }

            //DELETE USER
            match = Regex.Match(miniSQLQuery, deleteUser);
            if (match.Success)
            {
                String user = (match.Groups[1].Value);


                return new DeleteUser(user);
            }


            //GRANT

            //GRANT DELETE ON Employees_Public TO Employee;
            match = Regex.Match(miniSQLQuery, grant);
            if (match.Success)
            {
                string priv = match.Groups[1].Value;
                string table = match.Groups[2].Value;
                string nameProf = match.Groups[3].Value;

                return new Grant(nameProf, table, priv);
            }

            //REVOKE
            //REVOKE INSERT ON Employees_Public TO Employee;
            match = Regex.Match(miniSQLQuery, revoke);
            if (match.Success)
            {
                string priv = match.Groups[1].Value;
                string table = match.Groups[2].Value;
                string nameProf = match.Groups[3].Value;

                return new Revoke(nameProf, table, priv);
            }

            //CREATE SECUTIY PROFILE
           // CREATE SECURITY PROFILE Employee;
            match = Regex.Match(miniSQLQuery, createSecurity);
            if (match.Success)
            {
                string privName = match.Groups[1].Value;
                return new CreateSecurityProfile(privName);
            }

            //DROP SECURITY PROFILE
            //DROP SECURITY PROFILE Employee;
            match = Regex.Match(miniSQLQuery, dropSecurity);
            if (match.Success)
            {
                string privName = match.Groups[1].Value;
                return new DropSecurityProfile(privName);
            }

            //CREATE DATABASE
            //Database1,admin,admin
            match = Regex.Match(miniSQLQuery, createDB);
            if (match.Success)
            {
                string dbName = match.Groups[1].Value;
                string userName = match.Groups[2].Value;
                string psw = match.Groups[3].Value;

                return new CreateDB(dbName, userName, psw);
            }

            return null;
        }
            static List<string> CommaSeparatedNames(string text)
            {
                string t = text.Trim(' ');
                string[] columnNames = t.Split(',');

                return columnNames.ToList();
            }
            static List<string> insertSeparated(string text)
            {

                string t = text.Trim(' ');

                string[] columnNames = t.Split(',');
                columnNames[0].Replace("(", " ").Trim(' ');
                columnNames[columnNames.Length - 1].Replace(")", " ").Trim(' ');
                for (int i = 0; i < columnNames.Length; i++)
                {

                    columnNames[i] = columnNames[i].Replace("'", " ").Trim(' ');

                }
                return columnNames.ToList();
            }

            static List<string> updateSeparated(string text)
            {
                string t = text.Trim(' ');
                Char[] array = { '=', '>', '<', ',' };
                string c= t.Replace("'", "");
                string[] a= c.Split(array);

                return a.ToList();
            }

            static List<string> Condition(string text)
            {
                Char[] array = { '=', '>', '<' };
                string t = text.Trim(' ');
            string c = t.Replace("'", "");
            string[] a = c.Split(array);


                return a.ToList();
            }

            static List<string> createTable(string text)
            {
                    char[] elem = { '(', ')'};
                string sql2 = text.Replace(", ", " ").Trim(elem);
              
                string[] a = sql2.Split(' ');

                return a.ToList();
            }
    }
}


