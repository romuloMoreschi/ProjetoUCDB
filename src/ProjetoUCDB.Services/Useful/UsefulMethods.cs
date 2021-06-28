using System;
using System.Globalization;

namespace ProjetoUCDB.Services.Useful
{
    public abstract class UsefulMethods
    {
        public static string DateFormatForDateOnly(string date) => Convert.ToDateTime(date).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
