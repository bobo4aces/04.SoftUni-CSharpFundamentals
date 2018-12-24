namespace _11._Threeuple
{
    class Threeuple<T, U, V> : Tuple<T, U>
    {
        public V Item3 { get; set; }

        public Threeuple(T item1, U item2, V item3)
            : base(item1, item2)
        {
            this.Item3 = item3;
        }
    }
}
