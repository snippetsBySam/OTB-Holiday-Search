// See https://aka.ms/new-console-template for more information
using OTB_Holiday_Search.Models.Query;
using OTB_Holiday_Search.Models.Search;

Console.WriteLine("### Welcome to Holiday Search ###\n");

// Customer 1
var holidayQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
var holidaySearch = new HolidaySearch(holidayQuery);
//holidaySearch.Results().ForEach(result => Console.WriteLine(result.ToString()));
Console.WriteLine($"\nCustomer 1: From Manchester Airport (MAN), to Malaga Airport (AGP) on 2023/07/01 for 7 days.");
Console.WriteLine(holidaySearch.Results().First().ToString());

// Customer 2
holidayQuery = new HolidayQuery(new[] { "LTN","LGW" }, "PMI", DateTime.Parse("2023/06/15"), 10);
holidaySearch = new HolidaySearch(holidayQuery);
Console.WriteLine($"\nCustomer 2: From Any London Airport (LTN, LGW), to Mallorca Airport (PMI) on 2023/06/15 for 10 days.");
Console.WriteLine(holidaySearch.Results().First().ToString());


// Customer 3
holidayQuery = new HolidayQuery(new[] {"any"}, "LPA", DateTime.Parse("2022/11/10"), 14);
holidaySearch = new HolidaySearch(holidayQuery);
Console.WriteLine($"\nCustomer 3: From Any Airport, to Gran Canaria Airport (LPA) on 2022/11/10 for 14 days.");
Console.WriteLine(holidaySearch.Results().First().ToString());
Console.ReadLine();
