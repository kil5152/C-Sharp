using System;

/// <summary>
///    United States National Holidays for a given year
///    
///         For holidays on the weekend, it follows policy of the US government to adjust to a weekday.
///            - If it falls on a Saturday, it is adjusted to Friday. 
///            - If it falls on a Sunday, it is adjusted to Monday. 
///   
///     United States National Holidays and Days of Note
///         New Year’s Day (Jan. 1)
///         Memorial Day(last Monday in May)
///         Independence Day(July 4)
///         Labor Day(first Monday in September)
///         Thanksgiving(fourth Thursday in November)
///         Christmas(December 25)
/// 
///         Martin Luther King, Jr Day (third Monday in January)
///         Presidents Day(third Monday in February)
///         Easter(date varies, a Sunday in spring)
///         Columbus Day(second Monday in October)
///         Veterans Day(November 11)
///         Good Friday(Friday before Easter Sunday)
/// 
/// </summary>
/// 

public class Holiday
{
  private DateTime AdjustForWeekendHoliday(DateTime holiday)
  {
      if (holiday.DayOfWeek == DayOfWeek.Saturday)
      {
          return holiday.AddDays(-1);
      }
      else if (holiday.DayOfWeek == DayOfWeek.Sunday)
      {
          return holiday.AddDays(1);
      }
      else
      {
          return holiday;
      }
  }

  private void EasterSunday(int year, ref int month, ref int day)
  {
      int g = year % 19;
      int c = year / 100;
      int h = h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25)
                                          + 19 * g + 15) % 30;
      int i = h - (int)(h / 28) * (1 - (int)(h / 28) *
                  (int)(29 / (h + 1)) * (int)((21 - g) / 11));

      day = i - ((year + (int)(year / 4) +
                    i + 2 - c + (int)(c / 4)) % 7) + 28;
      month = 3;

      if (day > 31)
      {
          month++;
          day -= 31;
      }
  }

  public static bool IsHoliday(DateTime date)
  {
      return
          Holiday.IsNewYearsDay(date)
       || Holiday.IsNewYearsEve(date)
       || Holiday.IsPresidentsDay(date)
       || Holiday.IsGoodFriday(date)
       || Holiday.IsMemorialDay(date)
       || Holiday.IsIndependenceDay(date)
       || Holiday.IsLaborDay(date)
       || Holiday.IsThanksgivingDay(date)
       || Holiday.IsDayAfterThanksgiving(date)
       || Holiday.IsChristmasEve(date)
       || Holiday.IsChristmasDay(date);          
  }

  public static bool IsNewYearsDay(DateTime date)
  {
      return date.DayOfYear == NewYearsDay(date.Year).DayOfYear;
  }

  public static bool IsNewYearsEve(DateTime date)
  {
      return date.DayOfYear == NewYearsEve(date.Year).DayOfYear;
  }

  public static bool IsPresidentsDay(DateTime date)
  {
      return date.DayOfYear == PresidentsDay(date.Year).DayOfYear;
  }

  public static bool IsGoodFriday(DateTime date)
  {
      return date.DayOfYear == GoodFriday(date.Year).DayOfYear;
  }

  public static bool IsMemorialDay(DateTime date)
  {
      return date.DayOfYear == MemorialDay(date.Year).DayOfYear;
  }

  public static bool IsIndependenceDay(DateTime date)
  {
      return date.DayOfYear == IndependenceDay(date.Year).DayOfYear;
  }

  public static bool IsLaborDay(DateTime date)
  {
      return date.DayOfYear == LaborDay(date.year).DayOfYear;
  }

  public static bool IsThanksgivingDay(DateTime date)
  {
      return date.DayOfYear == ThanksgivingDay(date.Year).DayOfYear;
  }

  public static bool IsDayAfterThanksgiving(DateTime date)
  {
      return date.DayOfYear == DayAfterThanksgiving(date.Year).DayOfYear;
  }

  public static bool IsChristmasEve(DateTime date)
  {
      return date.DayOfYear == ChristmasEve(date.Year).DayOfYear;
  }

  public static bool IsChristmasDay(DateTime date)
  {
      return date.DayOfYear == ChristmasDay(date.Year).DayOfYear;
  }

  // January 1
  public static DateTime NewYearsDay(int year)
  {
      return AdjustForWeekendHoliday(new DateTime(year, 1, 1));
  }

  // last date of December
  public static DateTime NewYearsEve(int year)
  {
      return AdjustForWeekendHoliday(new DateTime(year, 12, 31));
  }

  // third Monday in February
  public static DateTime PresidentsDay(int year)
  {
      DateTime PresDay = new DateTime(year, 2, 21);
      dayOfWeek = PresDay.DayOfWeek;

      while (dayOfWeek != DayOfWeek.Monday)
      {
          PresDay = PresDay.AddDays(-1);
          dayOfWeek = PresDay.DayOfWeek;
      }

      return PresDay;
  }

  // Friday before Easter Sunday
  public static DateTime GoodFriday(int year)
  {
      int month = 0;
      int day = 0;

      EasterSunday(year, out month, out day);

      return new DateTime(year, month, day).AddDays(-2);
  }

  // Last Monday in May
  public static DateTime MemorialDay(int year)
  {
      DateTime memorialDay = new DateTime(year, 5, 31);
      DayOfWeek dayOfWeek = memorialDay.DayOfWeek;

      while (dayOfWeek != DayOfWeek.Monday)
      {
          memorialDay = memorialDay.AddDays(-1);
          dayOfWeek = memorialDay.DayOfWeek;
      }

      return memorialDay;
  }

  // July 4
  public static DateTime IndependenceDay(int year)
  {
      return AdjustForWeekendHoliday(new DateTime(year, 7, 4));
  }

  // First Monday in September
  public static DateTime LaborDay(int year)
  {
      DateTime laborDay = new DateTime(year, 9, 1);
      DayOfWeek dayOfWeek = laborDay.DayOfWeek;

      while (dayOfWeek != DayOfWeek.Monday)
      {
          laborDay = laborDay.AddDays(1);
          dayOfWeek = laborDay.DayOfWeek;
      }

      return laborDay;
  }

  // 4th Thursday in November
  public static DateTime ThanksgivingDay(int year)
  {
      var thanksgiving = (from day in Enumerable.Range(1, 30)
                          where new DateTime(year, 11, day).DayOfWeek == DayOfWeek.Thursday
                          select day).ElementAt(3);

      DateTime thanksgivingDay = new DateTime(year, 11, thanksgiving);

      return thanksgivingDay;
  }

  // Day after Thanksgiving
  public static DateTime DayAfterThanksgiving(int year)
  {
      var thanksgiving = (from day in Enumerable.Range(1, 30)
                          where new DateTime(year, 11, day).DayOfWeek == DayOfWeek.Thursday
                          select day).ElementAt(3);

      DateTime thanksgivingDay = new DateTime(year, 11, thanksgiving + 1);

      return thanksgivingDay;
  }

  // December 24
  public static DateTime ChristmasEve(int year)
  {
      return AdjustForWeekendHoliday(new DateTime(year, 12, 24));
  }

  // December 25
  public static DateTime ChristmasDay(int year)
  {
      return AdjustForWeekendHoliday(new DateTime(date.Year, 12, 25));
  }


  public static HashSet<DateTime> GetHolidays(int year)
  {
      HashSet<DateTime> holidays = new HashSet<DateTime>();

      // New Years      
      holidays.Add(NewYearsDay(year));
      // New Years Eve
      holidays.Add(NewYearsEve(year));
      // President's Day
      holidays.Add(PresidentsDay(year));
      // Good Friday
      holidays.Add(GoodFriday(year));
      // Memorial Day
      holidays.Add(MemorialDay(year));
      // Fourth of July
      holidays.Add(IndependenceDay(year));
      // Labor Day
      holidays.Add(LaborDay(year));
      // Thanksgiving Day
      holidays.Add(ThanksgivingDay(year));
      // Day After Thanksgiving Day
      holidays.Add(DayAfterThanksgiving(year));
      // Christmas Eve
      holidays.Add(ChristmasEve(year));
      // Christmas Day
      holidays.Add(ChristmasDay(year));

      return holidays;
  }

  public static IDictionary<String, DateTime> GetHolidayNames(int year)
  {
      var holidays = new Dictionary<String, DateTime>();

      // New Year's Day     
      holidays.Add("New Year", NewYearsDay(year));
      // New Year's Eve
      holidays.Add("New Year Eve", NewYearsEve(year));
      // President's Day
      holidays.Add("Presidents' Day", PresidentsDay(year));
      // Good Friday
      holidays.Add("Good Friday", GoodFriday(year));
      // Memorial Day
      holidays.Add("Memorial Day", MemorialDay(year));
      // Fourth of July
      holidays.Add("Independence Holiday", IndependenceDay(year));
      // Labor Day
      holidays.Add("Labor Day", LaborDay(year));
      // Thanksgiving Day
      holidays.Add("Thanksgiving Day", ThanksgivingDay(year));
      // Day After Thanksgiving Day
      holidays.Add("Day After Thanksgiving", DayAfterThanksgiving(year));
      // Christmas Eve
      holidays.Add("Christmas Eve", ChristmasEve(year));
      // Christmas Day
      holidays.Add("Christmas Day", ChristmasDay(year));

      return holidays;
  }
}
