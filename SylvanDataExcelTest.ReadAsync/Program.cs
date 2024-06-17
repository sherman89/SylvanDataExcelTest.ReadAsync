using Sylvan.Data;
using Sylvan.Data.Excel;

namespace SylvanDataExcelTest.ReadAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var edr = await ExcelDataReader.CreateAsync("TestData/Data_ENG.xlsx");

            var reader = edr.Validate(context => true);

            var results = reader.GetRecords<UserRecord>().ToList();

            // Comment GetRecords above, uncomment below, observe how array with default values is produced
            // var results = await reader.GetRecordsAsync<UserRecord>().ToListAsync();

            foreach (var userRecord in results)
            {
                Console.WriteLine($"Id: {userRecord.Id}");
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
