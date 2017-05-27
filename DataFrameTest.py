"""
Author      : Swadhin Goswami
Email       : gsmswadhin@gmail.com
Description :
This program will call C# method which return list, list of lists etc.
Python will receive the data and covert it in list.
Finally it will convert that data set to DataFrame using pandas.
"""

import clr
import sys
import pandas
import numpy
#from collections import OrderedDict
#from datetime import date
#import collections

#clr.AddReference("System.Collections")
#clr.AddReference("System")
#from System import Array
#from System import Int32

#clr.AddReference("System.Core")
#import System
#from System.Collections.Generic import List, Dictionary

#def ProcessDotNetStyle(list):
#    list1 = List[int]([1, 2, 3])
#    return list1.Union(list).ToList()

#This python  method will split a single list in sub lists with the given size
def split(arr, size):
    arrs = []
    while len(arr) > size:
        pice = arr[:size]
        arrs.append(pice)
        arr = arr[size:]
    arrs.append(arr)
    return arrs

# Need to give the path for C# DLL file 
sys.path.append(r"C:\Users\sgoswami\Documents\Visual Studio 2015\Projects\DataFrameBuilder\DataFrameBuilder\obj\Debug")

# Need to load the DLL where DLL file name "DataFrameBuilder"
clr.AddReference('DataFrameBuilder')

# Here "DataFrameBuilder" is a namespace and "DataFrame" is the class name
from DataFrameBuilder import DataFrame

# Clreating instance of the class to call C# method from python
my_instance = DataFrame.GetInstance()

#my_instance.setDataFrameMatrixSize(5,5);
#res = list( my_instance.DataFrameMatrixBuilder() );

# Below i have Tested with different return type ex: 2D array, List<int>, List<List<object>> etc

#net_array = Array[int]( my_instance.doOperation() )
#int_list = List[int]([1,2,3])
#int_list.Add(1)
#print list(int_list);
#net_array = List[int][int]()
#new_list = map(lambda x:[x], my_instance.getList())

#net_array = my_instance.getList()
#new_list=[]
#new_list = my_instance.getList()

#new_list=[]
swadhin = list(my_instance.getList())
#for ilist in swadhin:
#    #print list(ilist)
#    new_list.append(list(ilist))

#print new_list
#df = pandas.DataFrame.from_records( new_list )
df = pandas.DataFrame.from_records( list(swadhin) )
print "df : \n",df

DataSet = list(my_instance.getListOfListsObject())
dataFrameObj = pandas.DataFrame.from_records( list( DataSet ) )
print "dataFrameObj : \n",dataFrameObj

listobj = my_instance.getListDataFrame()
#print "listobj : ",listobj
res = list( listobj )
dataFrameRow = split( res,int( my_instance.DataFrameColumn ) );
headers = ['one','two','three','four','five']
dataFrame = pandas.DataFrame.from_records( dataFrameRow, columns=headers )
print dataFrame;
