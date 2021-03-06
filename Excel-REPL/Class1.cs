using clojure.lang;
using ExcelDna.Integration;
using System;
using System.Windows.Forms;
using System.Threading;
//using System.Text.RegularExpressions;

public class Class1
{
    private static IFn ifn_list;

    public Class1(IFn foo)
    {
        foo;
    }

    private void Poo() { }

    private static Object cleanValue(object o)
    {
        if (o == null)
        {
            return "";
        }
        if (o is bool)
        {
            return o;
        }
        if (o is Ratio)
        {
            return ((Ratio)o).ToDouble(null);
        }
        if (o is sbyte
            || o is byte
            || o is short
            || o is ushort
            || o is int
            || o is uint
            || o is long
            || o is ulong
            || o is float
            || o is double
            || o is decimal)
        {
            return o;
        }
        else
        {
            return o.ToString();
        }
    }

    public static Object RaggedArray(Object arrayCandidate)
    {
        var input = arrayCandidate as Object[,];
        if (input == null)
        {
            return arrayCandidate;
        }
        int m = input.GetUpperBound(0) + 1;
        int n = input.GetUpperBound(1) + 1;
        Object[][] output = new Object[m][];
        for (int i = 0; i < m; i++)
        {
            Object[] row = new Object[n];
            for (int j = 0; j < n; j++)
            {
                row[j] = input[i, j];
            }
            output[i] = row;
        }
        return output;
    }
    

}
