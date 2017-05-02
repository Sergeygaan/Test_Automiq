using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDK
{
    public interface ISort
    {
        string SortData(string textFile, Dictionary<char, int> weightLetter);


    }
}
