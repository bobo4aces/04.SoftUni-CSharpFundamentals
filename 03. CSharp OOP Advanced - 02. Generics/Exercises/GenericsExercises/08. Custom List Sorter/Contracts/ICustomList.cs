namespace _08._Custom_List_Sorter
{
    public interface ICustomList<T>
    {
        void Add(T element);
        T Remove(uint index);
        bool Contains(T element);
        void Swap(uint index1, uint index2);
        uint CountGreaterThan(T element);
        T Max();
        T Min();
    }
}
