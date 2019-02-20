using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DateTimeParse
{
    class Program
    {

            

public class Example
        {
            public static void Main()
            {
                string dateString;
                CultureInfo culture;
                DateTimeStyles styles;
                DateTime dateResult;

                // Parse a date and time with no styles.
                dateString = "03/01/2009 10:00 AM";
               // culture = CultureInfo.CreateSpecificCulture("en-US");
                culture = CultureInfo.GetCultures(CultureTypes.AllCultures);
                styles = DateTimeStyles.None;
                if (DateTime.TryParse(dateString, culture, styles, out dateResult))
                    Console.WriteLine("{0} converted to {1} {2}.",
                                      dateString, dateResult, dateResult.Kind);
                else
                    Console.WriteLine("Unable to convert {0} to a date and time.",
                                      dateString);

                // Parse the same date and time with the AssumeLocal style.
                styles = DateTimeStyles.AssumeLocal;
                if (DateTime.TryParse(dateString, culture, styles, out dateResult))
                    Console.WriteLine("{0} converted to {1} {2}.",
                                      dateString, dateResult, dateResult.Kind);
                else
                    Console.WriteLine("Unable to convert {0} to a date and time.", dateString);

                // Parse a date and time that is assumed to be local.
                // This time is five hours behind UTC. The local system's time zone is 
                // eight hours behind UTC.
                dateString = "2009/03/01T10:00:00-5:00";
                styles = DateTimeStyles.AssumeLocal;
                if (DateTime.TryParse(dateString, culture, styles, out dateResult))
                    Console.WriteLine("{0} converted to {1} {2}.",
                                      dateString, dateResult, dateResult.Kind);
                else
                    Console.WriteLine("Unable to convert {0} to a date and time.", dateString);

                // Attempt to convert a string in improper ISO 8601 format.
                dateString = "03/01/2009T10:00:00-5:00";
                if (DateTime.TryParse(dateString, culture, styles, out dateResult))
                    Console.WriteLine("{0} converted to {1} {2}.",
                                      dateString, dateResult, dateResult.Kind);
                else
                    Console.WriteLine("Unable to convert {0} to a date and time.", dateString);

                // Assume a date and time string formatted for the fr-FR culture is the local 
                // time and convert it to UTC.
                dateString = "2008-03-01 10:00";
                culture = CultureInfo.CreateSpecificCulture("fr-FR");
                styles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal;
                if (DateTime.TryParse(dateString, culture, styles, out dateResult))
                    Console.WriteLine("{0} converted to {1} {2}.",
                                      dateString, dateResult, dateResult.Kind);
                else
                    Console.WriteLine("Unable to convert {0} to a date and time.", dateString);

            }
        }
    
    }
}
