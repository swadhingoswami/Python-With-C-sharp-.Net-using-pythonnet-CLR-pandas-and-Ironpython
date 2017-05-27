using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace DataFrameBuilder
{
    public class DataFrame
    {
        private int DataFrameMatrixColumn = 0;
        private int DataFrameMatrixRow = 0;
        private int[,] DataFrameMatrix;
        //private IList<IList<int>> list;
        private List<List<int>> list;
        private List<List<object>> listData;
        private List<string> finalDataFrameStringList;

        //public IList<IList<int>> getList()
        public List<List<int>> getList()
        {
            //List<List<int>> list1 = new List<List<int>>();
            //IList<IList<int>> ret = new List<IList<int>>();
            return list;
        }

        public List<List<object>> getListOfListsObject()
        {
            return listData;
        }

        public void fillDataFrameInStringList( List<List<object>> mData)
        {
            //finalDataFrameStringList = new List<string>();
            finalDataFrameStringList = mData.SelectMany(x => x).Cast<String>().ToList();
        }

        public List<string> getListDataFrame()
        {
            return finalDataFrameStringList;
        }

        public DataFrame( int rows, int cols)
        {
            this.DataFrameMatrixRow = rows;
            this.DataFrameMatrixColumn = cols;

            // Get The DataFrame data and store in a list of lists 
            listData = new List<List<object>>()
            {
                new List<object> {"A","B","C","D","E" },
                new List<object> {"A","B","C","D","E" },
                new List<object> {"A","B","C","D","E" },
                new List<object> {"A","B","C","D","E" },
                new List<object> {"A","B","C","D","E" }
            };

            // Fill the data from list of lists to a single string list 
            fillDataFrameInStringList(listData);

            //----------------[Testing Part]-----------------------

            //list = new List<IList<int>>()
            list = new List<List<int>>()
            {
              new List<int>{ 0, 1, 2, 3, 4 },
              new List<int>{ 5, 6, 7, 8, 9 },
              new List<int>{ 10, 11, 12, 13, 14 },
              new List<int>{ 15, 16, 17, 18, 19 },
              new List<int>{ 20, 21, 22, 23, 24 }
            };

            double[,] array = new double[rows, cols];
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    array[i, j] = list[i][j];

            DataFrameMatrix = new int[5, 5]
            {
                { 0, 1, 2, 3, 4 },
                { 5, 6, 7, 8, 9 },
                { 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19 },
                { 20, 21, 22, 23, 24 }
            };

        //--------------------------------------------------
        }

        public int DataFrameColumn
        {
            get
            {
                return DataFrameMatrixColumn;
            }

            protected set
            {
                DataFrameMatrixColumn = value;
            }
        }
        public int DataFrameRow
        {
            get
            {
                return DataFrameMatrixRow;
            }

            protected set
            {
                DataFrameMatrixRow = value;
            }
        }

        public void setDataFrameMatrixSize( int mRow, int mColoum)
        {
            this.DataFrameMatrixRow = mRow;
            this.DataFrameMatrixColumn = mColoum;
        }

        public int[,] DataFrameMatrixBuilder()
        {
            return DataFrameMatrix;
        }

        public static DataFrame GetInstance()
        {
            DataFrame obj = new DataFrame(5,5);
            return obj;
        }

        public int[,] doOperation()
        {
            setDataFrameMatrixSize( 5, 5 );
            return DataFrameMatrixBuilder();
        }        

    }
}
