using Sylvan.Data;
using Sylvan.Data.Excel;

namespace SylvanDataExcelTest.ReadAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var edr = ExcelDataReader.Create("TestData/EmptySheet.xlsx");

            // var reader = edr.Validate(context => true);

            Console.WriteLine("No columns:");

            try
            {
                var results = edr.GetRecords<UserRecord>(new DataBinderOptions { BindingMode = DataBindingMode.Any }).ToList();

                foreach (var userRecord in results)
                {
                    Console.WriteLine($"Age: {userRecord.Age}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("One column:");
            Works();
        }

        private static void Works()
        {
            using var edr = ExcelDataReader.Create("TestData/OnlyOneColumn.xlsx");

            // var reader = edr.Validate(context => true);

            try
            {
                var results = edr.GetRecords<UserRecord>(new DataBinderOptions { BindingMode = DataBindingMode.Any }).ToList();

                foreach (var userRecord in results)
                {
                    Console.WriteLine($"Age: {userRecord.Age}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public record UserRecord
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
