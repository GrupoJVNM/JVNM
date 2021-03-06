﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVNM
{
    public class Insert : MiniSQLQuery
    {
       public  string TableName = null;
       public List<String> List = null;

        public Insert(string tableName, List<String> list) {
            TableName = tableName;
            List = list;
        }
        public string Execute(Database database)
        {
            if (MiniSQLTester.database.permission(TableName, "INSERT") || MiniSQLTester.database.User.Equals("admin"))
            {

                try
                {
                    database.Insert(TableName, List);
                    return Query.InsertSuccess;
                }
                catch
                {
                    return Query.TableDoesNotExist;
                }
            }
            else
            {
                return Query.SecurityNotSufficientPrivileges;
            }
        }
    }
}

