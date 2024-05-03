namespace ReportGenerator
{
    class QuarterlyIncomeReport
    {
        static void Main(string[] args)
        {
            // create a new instance of the class
            QuarterlyIncomeReport report = new QuarterlyIncomeReport();

            // call the GenerateSalesData method
            SalesData[] salesData = report.GenerateSalesData();


            // call the QuarterlySalesReport method
            report.QuarterlySalesReport(salesData);

        }

        /* public struct SalesData includes the following fields: date sold, department name, product ID, quantity sold, unit price */
        public struct SalesData
        {
            public DateOnly dateSold;
            public string departmentName;
            public string productID;
            public int quantitySold;
            public double unitPrice;
            public double baseCost;
            public int volumeDiscount;
        }

        public struct ProdDepartments
        {
            public static string[] departmentNames = { "Men's Clothing", "Women's Clothing", "Children's Clothing", "Accessories", "Footwear", "Outerwear", "Sportswear", "Undergarments" };
            public static string[] departmentAbbreviations = { "MENS", "WOMN", "CHLD", "ACCS", "FOOT", "OUTR", "SPRT", "UNDR" };
        }

        public struct ManufacturingSites
        {
            public static string[] manufacturingSites = { "US1", "US2", "US3", "UK1", "UK2", "UK3", "JP1", "JP2", "JP3", "CA1" };
        }

        /* the GenerateSalesData method returns 1000 SalesData records. It assigns random values to each field of the data structure */
        public SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                salesData[i].dateSold = new DateOnly(2023, random.Next(1, 13), random.Next(1, 29));
                salesData[i].departmentName = ProdDepartments.departmentNames[random.Next(0, ProdDepartments.departmentNames.Length)];

                int indexOfDept = Array.IndexOf(ProdDepartments.departmentNames, salesData[i].departmentName);
                string deptAbb = ProdDepartments.departmentAbbreviations[indexOfDept];
                string firstDigit = (indexOfDept + 1).ToString();
                string nextTwoDigits = random.Next(1, 100).ToString("D2");
                string sizeCode = new string[] { "XS", "S", "M", "L", "XL" }[random.Next(0, 5)];
                string colorCode = new string[] { "BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY" }[random.Next(0, 8)];
                string manufacturingSite = ManufacturingSites.manufacturingSites[random.Next(0, ManufacturingSites.manufacturingSites.Length)];

                salesData[i].productID = $"{deptAbb}-{firstDigit}{nextTwoDigits}-{sizeCode}-{colorCode}-{manufacturingSite}";
                salesData[i].quantitySold = random.Next(1, 101);
                salesData[i].unitPrice = random.Next(25, 300) + random.NextDouble();
                salesData[i].baseCost = salesData[i].unitPrice * (1 - (random.Next(5, 21) / 100.0));
                salesData[i].volumeDiscount = (int)(salesData[i].quantitySold * 0.1);

            }

            return salesData;
        }


        public void QuarterlySalesReport(SalesData[] salesData)
        {
            // create a dictionary to store the quarterly sales data
            Dictionary<string, double> quarterlySales = new Dictionary<string, double>();
            Dictionary<string, double> quarterlyProfit = new Dictionary<string, double>();
            Dictionary<string, double> quarterlyProfitPercentage = new Dictionary<string, double>();

            // create a dictionary to store the quarterly sales data by department
            Dictionary<string, Dictionary<string, double>> quarterlySalesByDepartment = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, Dictionary<string, double>> quarterlyProfitByDepartment = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, Dictionary<string, double>> quarterlyProfitPercentageByDepartment = new Dictionary<string, Dictionary<string, double>>();

            // iterate through the sales data
            foreach (SalesData data in salesData)
            {
                // calculate the total sales for each quarter
                string quarter = GetQuarter(data.dateSold.Month);
                double totalSales = data.quantitySold * data.unitPrice;
                double totalCost = data.quantitySold * data.baseCost;
                double profit = totalSales - totalCost;
                double profitPercentage = (profit / totalSales) * 100;

                // calculate the total sales, profit, and profit percentage by department
                if (!quarterlySalesByDepartment.ContainsKey(quarter))
                {
                    quarterlySalesByDepartment.Add(quarter, new Dictionary<string, double>());
                    quarterlyProfitByDepartment.Add(quarter, new Dictionary<string, double>());
                    quarterlyProfitPercentageByDepartment.Add(quarter, new Dictionary<string, double>());
                }

                if (quarterlySalesByDepartment[quarter].ContainsKey(data.departmentName))
                {
                    quarterlySalesByDepartment[quarter][data.departmentName] += totalSales;
                    quarterlyProfitByDepartment[quarter][data.departmentName] += profit;
                }
                else
                {
                    quarterlySalesByDepartment[quarter].Add(data.departmentName, totalSales);
                    quarterlyProfitByDepartment[quarter].Add(data.departmentName, profit);
                }

                if (!quarterlyProfitPercentageByDepartment[quarter].ContainsKey(data.departmentName))
                {
                    quarterlyProfitPercentageByDepartment[quarter].Add(data.departmentName, profitPercentage);
                }

                // calculate the total sales and profit for each quarter
                if (quarterlySales.ContainsKey(quarter))
                {
                    quarterlySales[quarter] += totalSales;
                    quarterlyProfit[quarter] += profit;
                }
                else
                {
                    quarterlySales.Add(quarter, totalSales);
                    quarterlyProfit.Add(quarter, profit);
                }

                if (!quarterlyProfitPercentage.ContainsKey(quarter))
                {
                    quarterlyProfitPercentage.Add(quarter, profitPercentage);
                }
            }

            // display the quarterly sales report
            Console.WriteLine("Quarterly Sales Report");
            Console.WriteLine("----------------------");

            // sort the quarterly sales by key (quarter)
            var sortedQuarterlySales = quarterlySales.OrderBy(q => q.Key);

            foreach (KeyValuePair<string, double> quarter in sortedQuarterlySales)
            {
                // format the sales amount as currency using regional settings
                string formattedSalesAmount = quarter.Value.ToString("C");
                string formattedProfitAmount = quarterlyProfit[quarter.Key].ToString("C");
                string formattedProfitPercentage = quarterlyProfitPercentage[quarter.Key].ToString("F2");

                Console.WriteLine("{0}: Sales: {1}, Profit: {2}, Profit Percentage: {3}%", quarter.Key, formattedSalesAmount, formattedProfitAmount, formattedProfitPercentage);

                // display the quarterly sales, profit, and profit percentage by department
                Console.WriteLine("By Department:");
                var sortedQuarterlySalesByDepartment = quarterlySalesByDepartment[quarter.Key].OrderBy(d => d.Key);

                foreach (KeyValuePair<string, double> department in sortedQuarterlySalesByDepartment)
                {
                    string formattedDepartmentSalesAmount = department.Value.ToString("C");
                    string formattedDepartmentProfitAmount = quarterlyProfitByDepartment[quarter.Key][department.Key].ToString("C");
                    string formattedDepartmentProfitPercentage = quarterlyProfitPercentageByDepartment[quarter.Key][department.Key].ToString("F2");

                    Console.WriteLine("Department: {0}, Sales: {1}, Profit: {2}, Profit Percentage: {3}%", department.Key, formattedDepartmentSalesAmount, formattedDepartmentProfitAmount, formattedDepartmentProfitPercentage);
                }

                Console.WriteLine();
            }
        }

        public string GetQuarter(int month)
        {
            if (month >= 1 && month <= 3)
            {
                return "Q1";
            }
            else if (month >= 4 && month <= 6)
            {
                return "Q2";
            }
            else if (month >= 7 && month <= 9)
            {
                return "Q3";
            }
            else
            {
                return "Q4";
            }
        }
    }
}