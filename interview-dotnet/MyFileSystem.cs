using Microsoft.Extensions.Logging.EventLog;

namespace interview_dotnet
{
    public class MyFileSystem
    {
        private static ILogger _logger;

        public void SaveData(string filename, ICustomer customer )
        {
            using (StreamWriter writer = new StreamWriter( filename, true ))
            {
                writer.WriteLine(customer.firstName + "," + customer.lastName + "," + customer.phoneNumber);
            }
        }

        public List<ICustomer> ReadData(string filename)
        {
            List<ICustomer> customers = new List<ICustomer>();
            try
            {
                using (StreamReader reader = new StreamReader( filename ))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        Customer customer = new Customer() { firstName = values[0], lastName = values[1], phoneNumber = values[2] };
                        customers.Add(customer);
                        LogData(customer);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return customers;
        }

        public void LogData(Customer cust)
        {
            if (_logger == null)
            {
                ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddEventLog();
                });
                _logger = loggerFactory.CreateLogger<ICustomer>();
            }

            _logger.LogInformation(cust.ToString(), cust.firstName);
        }
    }
}
