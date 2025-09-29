namespace skterminal_fuel_skids_api.Utils.DatetimeUtils
{
  public class DatetimeMethods
  {
    public static DateTime GetStartDateOfWeek(DateTime referenceDate)
    {
      DateTime dateFilter = new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day, 5, 0, 0);

      while (dateFilter.DayOfWeek != DayOfWeek.Sunday)
        dateFilter = dateFilter.AddDays(-1);

      return dateFilter;
    }

    public static DateTime GetStartOfDay(DateTime date, int hour)
    {
      return new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
    }
  }
}
