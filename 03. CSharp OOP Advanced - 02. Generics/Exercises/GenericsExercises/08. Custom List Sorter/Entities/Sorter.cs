using System;

namespace _08._Custom_List_Sorter.Entities
{
    public static class Sorter
    {
        public static void Sort<T>(CustomList<T> customList)
            where T: IComparable<T>
        {
            for (uint i = 0; i < customList.Size - 1; i++)
            {
                for (uint j = 1; j < customList.Size; j++)
                {
                    if (customList[i].CompareTo(customList[j]) > 0)
                    {
                        customList.Swap(i, j);
                    }
                    
                }
            }
        }
    }
}
