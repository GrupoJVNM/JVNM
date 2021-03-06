﻿using System;
using System.Collections.Generic;
using JVNM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTable
    {

        [TestMethod]
        public void AddTupleCount()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);

            List<String> list2 = new List<String>();
            list2.Add("18");
            list2.Add("22,6");
            list2.Add("higb");

            Assert.IsTrue(table.GetListTableColumn().Count == 3);
            table.AddTuple(list2);
            Assert.IsTrue(table.GetListTableColumn()[0].GetList().Count != 0);
            Assert.IsTrue(table.GetListTableColumn()[1].GetList().Count != 0);
            Assert.IsTrue(table.GetListTableColumn()[2].GetList().Count != 0);

        }

        [TestMethod]
        public void AddTupleINT()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            columnList.Add(columnInt);
            Table table = new Table("myTable", columnList);
            List<String> list2 = new List<String>();
            list2.Add("18");
            table.AddTuple(list2);

            Assert.IsTrue(table.GetListTableColumn().Find(f => f.GetColumnName().Equals("columnInt")).DataList.Contains("18"));

        }

        [TestMethod]
        public void AddTupleDOUBLE()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnD = new TableColumn("columnD", DataType.Double);
            columnList.Add(columnD);
            Table table = new Table("myTable", columnList);
            List<String> list2 = new List<String>();
            list2.Add("18,5");
            table.AddTuple(list2);

            Assert.IsTrue(table.GetListTableColumn().Find(f => f.GetColumnName().Equals("columnD")).DataList.Contains("18,5"));
        }

        [TestMethod]
        public void AddTupleText()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnT = new TableColumn("columnT", DataType.Text);
            columnList.Add(columnT);
            Table table = new Table("myTable", columnList);
            List<String> list2 = new List<String>();
            list2.Add("Ane");
            table.AddTuple(list2);

            Assert.IsTrue(table.GetListTableColumn().Find(f => f.GetColumnName().Equals("columnT")).DataList.Contains("Ane"));
        }


        [TestMethod]
        public void SelectTEXT()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");
            List<List<String>> returnList = table.Select(dataList2, DataComparator.Equal, ColumnText, "Hola");


            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Hola");
            listText.Add("Hola");
            listInt.Add("1");
            listInt.Add("3");
            listDouble.Add("1,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);
            Assert.IsTrue(resultOk[0].Count == 2);
            Assert.IsTrue(resultOk[1].Count == 2);
            Assert.IsTrue(resultOk[2].Count == 2);

            for (int i = 0; i < returnList.Count; i++)
            {
                for (int j = 0; j < returnList[i].Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], returnList[i][j]);
                }

            }

        }


        [TestMethod]
        public void SelectINT_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Less, ColumnInt, "2");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listInt2.Add("1");
            listText2.Add("Hola");
            listDouble2.Add("1,1");
           
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }

        }

        [TestMethod]
        public void SelectINT_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Equal, ColumnInt, "1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listInt2.Add("1");
            listText2.Add("Hola");
            listDouble2.Add("1,1");

            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }

        }

        [TestMethod]
        public void SelectINT_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Bigger, ColumnInt, "1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listText2.Add("Adios");
            listText2.Add("Hola");
            listInt2.Add("2");
            listInt2.Add("3");
            listDouble2.Add("2,1");
            listDouble2.Add("3,1");
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }

        }


        [TestMethod]
        public void SelectDOUBLE_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Less, ColumnDouble, "3,1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listText2.Add("Hola");
            listText2.Add("Adios");
            listInt2.Add("1");
            listInt2.Add("2");
            listDouble2.Add("1,1");
            listDouble2.Add("2,1");
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }
        }

        [TestMethod]
        public void SelectDOUBLE_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Bigger, ColumnDouble, "1,1");


            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listText2.Add("Adios");
            listText2.Add("Hola");
            listInt2.Add("2");
            listInt2.Add("3");
            listDouble2.Add("2,1");
            listDouble2.Add("3,1");
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }
         
        }

        [TestMethod]
        public void SelectDOUBLE_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Equal, ColumnDouble, "3,1");


            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            
            listText2.Add("Hola");
            listInt2.Add("3");
            listDouble2.Add("3,1");
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }

        }


        [TestMethod]
        public void SelectEmpty()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<String> dataList2 = new List<String>();
            dataList2.Add("ColumnInt");
            dataList2.Add("ColumnDouble");
            dataList2.Add("ColumnText");

            List<List<String>> returnList2 = table.Select(dataList2, DataComparator.Bigger, ColumnDouble, "3,1");

            Assert.IsTrue(returnList2.Count == 0);

        }

        [TestMethod]
        public void SelectAll_TEXT_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<List<String>> returnList = table.SelectAll(DataComparator.Equal, ColumnText, "Hola");

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Hola");
            listText.Add("Hola");
            listInt.Add("1");
            listInt.Add("3");
            listDouble.Add("1,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);
            Assert.IsTrue(resultOk[0].Count == 2);
            Assert.IsTrue(resultOk[1].Count == 2);
            Assert.IsTrue(resultOk[2].Count == 2);

            for (int i = 0; i < returnList.Count; i++)
            {
                for (int j = 0; j < returnList[i].Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], returnList[i][j]);
                }

            }

        }

        [TestMethod]
        public void SelectAll_INT_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
     
            List<List<String>> returnList2 = table.SelectAll(DataComparator.Bigger, ColumnText, "1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listText2.Add("Adios");
            listText2.Add("Hola");
            listInt2.Add("2");
            listInt2.Add("3");
            listDouble2.Add("2,1");
            listDouble2.Add("3,1");
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }

        }

        [TestMethod]
        public void SelectAll_INT_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");

            List<List<String>> returnList2 = table.SelectAll(DataComparator.Less, ColumnDouble, "2");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
       
            listText2.Add("Hola");
            listInt2.Add("1");
            listDouble2.Add("1,1");
       
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }


        }

        [TestMethod]
        public void SelectAll_INT_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");

            List<List<String>> returnList2 = table.SelectAll(DataComparator.Less, ColumnDouble, "1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();

            listText2.Add("Hola");
            listInt2.Add("1");
            listDouble2.Add("1,1");

            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }


        }

        [TestMethod]
        public void SelectAll_DOUBLE_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");

            List<List<String>> returnList2 = table.SelectAll(DataComparator.Bigger, ColumnText, "1,1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();
            listText2.Add("Adios");
            listText2.Add("Hola");
            listInt2.Add("2");
            listInt2.Add("3");
            listDouble2.Add("2,1");
            listDouble2.Add("3,1");
            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }

        }

        [TestMethod]
        public void SelectAll_DOUBLE_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");

            List<List<String>> returnList2 = table.SelectAll(DataComparator.Less, ColumnDouble, "2,1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();

            listText2.Add("Hola");
            listInt2.Add("1");
            listDouble2.Add("1,1");

            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }


        }

        [TestMethod]
        public void SelectAll_DOUBLE_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");

            List<List<String>> returnList2 = table.SelectAll(DataComparator.Less, ColumnDouble, "1,1");

            List<List<String>> resultOk2 = new List<List<String>>();

            List<String> listInt2 = new List<string>();
            List<String> listDouble2 = new List<string>();
            List<String> listText2 = new List<string>();

            listText2.Add("Hola");
            listInt2.Add("1");
            listDouble2.Add("1,1");

            resultOk2.Add(listInt2);
            resultOk2.Add(listDouble2);
            resultOk2.Add(listText2);

            for (int i = 0; i < returnList2.Count; i++)
            {
                for (int j = 0; j < returnList2[i].Count; j++)
                {
                    Assert.AreEqual(resultOk2[i][j], returnList2[i][j]);
                }

            }


        }


        [TestMethod]
        public void SelectAll_Empty()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");

            List<List<String>> returnList2 = table.SelectAll(DataComparator.Less, ColumnDouble, "1");

            Assert.IsTrue(returnList2.Count == 0);
           

        }


        [TestMethod]
        public void selectWithOutC()
        {
            //SELECT nombre, edad FROM tabla;

            List<TableColumn> columnList = new List<TableColumn>();
            List<String> selectC = new List<String>();
            List<List<String>> returnList = new List<List<String>>();



            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            selectC.Add("ColumnInt");

            returnList = table.SelectWithOutC(selectC);
            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            listInt.Add("1");
            listInt.Add("2");
            listInt.Add("3");
            resultOk.Add(listInt);

            for (int i = 0; i < returnList.Count; i++)
            {
                for (int j = 0; j < returnList[i].Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], returnList[i][j]);
                }

            }



        }

        [TestMethod]
        public void selectAllWithOutC()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn ColumnInt = new TableColumn("ColumnInt", DataType.Int);
            TableColumn ColumnDouble = new TableColumn("ColumnDouble", DataType.Double);
            TableColumn ColumnText = new TableColumn("ColumnText", DataType.Text);
            columnList.Add(ColumnInt);
            columnList.Add(ColumnDouble);
            columnList.Add(ColumnText);
            Table table = new Table("myTable", columnList);
            ColumnText.Add("Hola");
            ColumnText.Add("Adios");
            ColumnText.Add("Hola");
            ColumnInt.Add("1");
            ColumnInt.Add("2");
            ColumnInt.Add("3");
            ColumnDouble.Add("1,1");
            ColumnDouble.Add("2,1");
            ColumnDouble.Add("3,1");
            List<List<String>> returnList = table.SelectAllWithOutC();

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Hola");
            listText.Add("Adios");
            listText.Add("Hola");
            listInt.Add("1");
            listInt.Add("2");
            listInt.Add("3");
            listDouble.Add("1,1");
            listDouble.Add("2,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < returnList.Count; i++)
            {
                for (int j = 0; j < returnList[i].Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], returnList[i][j]);
                }

            }

        }
       



        [TestMethod]
        public void AddColumn_INT()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            Table table = new Table("myTable", columnList);

            table.AddColumn("column2", DataType.Int);
            Assert.AreEqual(columnList[0].GetColumnName(), "column2");
            Assert.IsTrue(columnList[0].GetTypeC().Equals("Int"));


        }
        [TestMethod]
        public void AddColumn_DOUBLE()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            Table table = new Table("myTable", columnList);
           
            table.AddColumn("column2", DataType.Double);
            Assert.AreEqual(columnList[0].GetColumnName(), "column2");
            Assert.IsTrue(columnList[0].GetTypeC().Equals("Double"));
           

        }
        [TestMethod]
        public void AddColumn_TEXT()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            Table table = new Table("myTable", columnList);
            table.AddColumn("column1", DataType.Text);
            Assert.IsTrue(columnList.Count == 1);
            Assert.IsNotNull(columnList);
            Assert.AreEqual(columnList[0].GetColumnName(), "column1");
            Assert.IsTrue(columnList[0].GetTypeC().Equals("Text"));
        }

     /*   [TestMethod]
        public void Delete()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTuple(columnText, "Hola");

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Adios");
            listInt.Add("2");
            listDouble.Add("2,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }
        */
        

        [TestMethod]
        public void DeleteWithC_INT_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnInt, "2", DataComparator.Bigger);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            
            listText.Add("Hola");
            listText.Add("Adios");
            listInt.Add("1");
            listInt.Add("2");
            listDouble.Add("1,1");
            listDouble.Add("2,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }


        [TestMethod]
        public void DeleteWithC_INT_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnInt, "2", DataComparator.Less);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Adios");
            listText.Add("Hola");
            listInt.Add("2");
            listInt.Add("3");
            listDouble.Add("2,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }

        [TestMethod]
        public void DeleteWithC_INT_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnInt, "1", DataComparator.Equal);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Adios");
            listText.Add("Hola");
            listInt.Add("2");
            listInt.Add("3");
            listDouble.Add("2,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }
        [TestMethod]
        public void DeleteWithC_DOUBLE_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnDouble, "2,1", DataComparator.Bigger);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();

            listText.Add("Hola");
            listText.Add("Adios");
            listInt.Add("1");
            listInt.Add("2");
            listDouble.Add("1,1");
            listDouble.Add("2,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }


        [TestMethod]
        public void DeleteWithC_DOUBLE_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnDouble, "2,1", DataComparator.Less);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Adios");
            listText.Add("Hola");
            listInt.Add("2");
            listInt.Add("3");
            listDouble.Add("2,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }

        [TestMethod]
        public void DeleteWithC_DOUBLE_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnDouble, "1,1", DataComparator.Equal);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Adios");
            listText.Add("Hola");
            listInt.Add("2");
            listInt.Add("3");
            listDouble.Add("2,1");
            listDouble.Add("3,1");
            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }

        [TestMethod]
        public void DeleteWithC_TEXT()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnText, "Hola", DataComparator.Equal);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Adios");
            listInt.Add("2");
            listDouble.Add("2,1");

            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }


        [TestMethod]
        public void DeleteWithC_Empty()
        {
            List<TableColumn> columnList = new List<TableColumn>();

            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            TableColumn columnDouble = new TableColumn("columnDouble", DataType.Double);
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            columnList.Add(columnDouble);
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Hola");
            columnText.Add("Adios");
            columnText.Add("Hola");
            columnInt.Add("1");
            columnInt.Add("2");
            columnInt.Add("3");
            columnDouble.Add("1,1");
            columnDouble.Add("2,1");
            columnDouble.Add("3,1");

            table.DeleteTupleWithC(columnText, "Paco", DataComparator.Equal);

            List<List<String>> resultOk = new List<List<String>>();

            List<String> listInt = new List<string>();
            List<String> listDouble = new List<string>();
            List<String> listText = new List<string>();
            listText.Add("Hola");
            listText.Add("Adios");
            listText.Add("Hola");
            listInt.Add("1");
            listInt.Add("2");
            listInt.Add("3");
            listDouble.Add("1,1");
            listDouble.Add("2,1");
            listDouble.Add("3,1");

            resultOk.Add(listInt);
            resultOk.Add(listDouble);
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }

            }
        }

        [TestMethod]
        public void UpdateTestTXT()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnText = new TableColumn("columnText", DataType.Text);
            List<String> list2 = new List<String>();
            columnList.Add(columnText);
            Table table = new Table("myTable", columnList);
            columnText.Add("Adios");

            table.Update(columnText, "Que", DataComparator.Equal, "Adios", columnText);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listText = new List<string>();
            listText.Add("Que");
            resultOk.Add(listText);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }

        [TestMethod]
        public void UpdateTest_INT_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            Table table = new Table("myTable", columnList);
            columnInt.Add("3");

            table.Update(columnInt, "8", DataComparator.Less, "5", columnInt);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listInt = new List<string>();
            listInt.Add("8");
            resultOk.Add(listInt);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }


        [TestMethod]
        public void UpdateTest_INT_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            Table table = new Table("myTable", columnList);
            columnInt.Add("3");

            table.Update(columnInt, "8", DataComparator.Bigger, "2", columnInt);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listInt = new List<string>();
            listInt.Add("8");
            resultOk.Add(listInt);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }

        [TestMethod]
        public void UpdateTest_INT_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnInt = new TableColumn("columnInt", DataType.Int);
            List<String> list2 = new List<String>();
            columnList.Add(columnInt);
            Table table = new Table("myTable", columnList);
            columnInt.Add("3");

            table.Update(columnInt, "8", DataComparator.Equal, "3", columnInt);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listInt = new List<string>();
            listInt.Add("8");
            resultOk.Add(listInt);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }

        [TestMethod]
        public void UpdateTest_DOUBLE_BIGGER()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnD = new TableColumn("columnD", DataType.Double);
            List<String> list2 = new List<String>();
            columnList.Add(columnD);
            Table table = new Table("myTable", columnList);
            columnD.Add("3,3");

            table.Update(columnD, "6,7", DataComparator.Bigger, "2,1", columnD);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listD = new List<string>();
            listD.Add("6,7");
            resultOk.Add(listD);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }

        [TestMethod]
        public void UpdateTest_DOUBLE_LESS()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnD = new TableColumn("columnD", DataType.Double);
            List<String> list2 = new List<String>();
            columnList.Add(columnD);
            Table table = new Table("myTable", columnList);
            columnD.Add("3,3");

            table.Update(columnD, "6,7", DataComparator.Less, "4,1", columnD);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listD = new List<string>();
            listD.Add("6,7");
            resultOk.Add(listD);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }

        [TestMethod]
        public void UpdateTest_DOUBLE_EQUALS()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnD = new TableColumn("columnD", DataType.Double);
            List<String> list2 = new List<String>();
            columnList.Add(columnD);
            Table table = new Table("myTable", columnList);
            columnD.Add("3,3");

            table.Update(columnD, "6,7", DataComparator.Equal, "3,3", columnD);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listD = new List<string>();
            listD.Add("6,7");
            resultOk.Add(listD);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }

        [TestMethod]
        public void UpdateTest_Empty()
        {
            List<TableColumn> columnList = new List<TableColumn>();
            TableColumn columnD = new TableColumn("columnD", DataType.Double);
            List<String> list2 = new List<String>();
            columnList.Add(columnD);
            Table table = new Table("myTable", columnList);
            columnD.Add("3,3");

            table.Update(columnD, "6,7", DataComparator.Equal, "5,2", columnD);

            List<List<String>> resultOk = new List<List<String>>();
            List<String> listD = new List<string>();
            listD.Add("3,3");
            resultOk.Add(listD);

            for (int i = 0; i < table.GetListTableColumn().Count; i++)
            {
                for (int j = 0; j < table.GetListTableColumn()[i].GetList().Count; j++)
                {
                    Assert.AreEqual(resultOk[i][j], table.GetListTableColumn()[i].GetList()[j]);
                }
            }
        }



    }
}



