using System;

public class DateModifier
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public DateModifier(string fromDate, string toDate)
    {
        this.FromDate = DateTime.Parse(fromDate);
        this.ToDate = DateTime.Parse(toDate);
    }

    public int GetDifference(DateTime fromDate, DateTime toDate)
    {
        int days = 0;
        int compare = DateTime.Compare(fromDate, toDate);
        if (compare < 0)
        {
            for (DateTime i = fromDate; i < toDate; i=i.AddDays(1))
            {
                days++;
            }
        }
        else if (compare > 0)
        {
            for (DateTime i = toDate; i < fromDate; i = i.AddDays(1))
            {
                days++;
            }
        }
        return days;
    }
}
