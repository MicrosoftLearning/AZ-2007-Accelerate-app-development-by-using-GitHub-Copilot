# README - Update the APL2007M3 app for APL2007M4

This file explains how to update the final Module 3 application for use in Module 4 of the APL-2007 training.

## Create the ConstructProductId method

1. Open APL2007M3 app in Visual Studio Code.

1. Open the Program.cs file, locate the `GenerateSalesData` method, and then select the following code lines:

    ```csharp
    int indexOfDept = Array.IndexOf(ProdDepartments.departmentNames, salesData[i].departmentName);
    string deptAbb = ProdDepartments.departmentAbbreviations[indexOfDept];
    string firstDigit = (indexOfDept + 1).ToString();
    string nextTwoDigits = random.Next(1, 100).ToString("D2");
    string sizeCode = new string[] { "XS", "S", "M", "L", "XL" }[random.Next(0, 5)];
    string colorCode = new string[] { "BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY" }[random.Next(0, 8)];
    string manufacturingSite = ManufacturingSites.manufacturingSites[random.Next(0, ManufacturingSites.manufacturingSites.Length)];
    
    salesData[i].productID = $"{deptAbb}-{firstDigit}{nextTwoDigits}-{sizeCode}-{colorCode}-{manufacturingSite}";
    ```

1. Open the Chat view and then enter the following prompt:

    ```plaintext
    #selection Create a public static method named ConstructProductId that uses the current index element of the salesData array (salesData[i]) to construct and return a productID for that item.  
    ```

1. In the code editor, create a blank code line below the GenerateSalesData method.

1. In the Chat view, hover the mouse pointer over the code block containing the new method, and then select **Insert at Cursor**.

    The code should be similar to the following:

    ```csharp
    public static string ConstructProductId(SalesData salesDataItem)
    {
        Random random = new Random();
        int indexOfDept = Array.IndexOf(ProdDepartments.departmentNames, salesDataItem.departmentName);
        string deptAbb = ProdDepartments.departmentAbbreviations[indexOfDept];
        string firstDigit = (indexOfDept + 1).ToString();
        string nextTwoDigits = random.Next(1, 100).ToString("D2");
        string sizeCode = new string[] { "XS", "S", "M", "L", "XL" }[random.Next(0, 5)];
        string colorCode = new string[] { "BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY" }[random.Next(0, 8)];
        string manufacturingSite = ManufacturingSites.manufacturingSites[random.Next(0, ManufacturingSites.manufacturingSites.Length)];
    
        return $"{deptAbb}-{firstDigit}{nextTwoDigits}-{sizeCode}-{colorCode}-{manufacturingSite}";
    }

    ```

1. In the code editor, comment out the following code block:

    ```csharp
    int indexOfDept = Array.IndexOf(ProdDepartments.departmentNames, salesData[i].departmentName);
    string deptAbb = ProdDepartments.departmentAbbreviations[indexOfDept];
    string firstDigit = (indexOfDept + 1).ToString();
    string nextTwoDigits = random.Next(1, 100).ToString("D2");
    string sizeCode = new string[] { "XS", "S", "M", "L", "XL" }[random.Next(0, 5)];
    string colorCode = new string[] { "BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY" }[random.Next(0, 8)];
    string manufacturingSite = ManufacturingSites.manufacturingSites[random.Next(0, ManufacturingSites.manufacturingSites.Length)];
    
    salesData[i].productID = $"{deptAbb}-{firstDigit}{nextTwoDigits}-{sizeCode}-{colorCode}-{manufacturingSite}";
    ```

1. Create a blank code line below the commented code block.

    GitHub Copilot will suggest a code line completion that uses the new method to assign the productID value.

1. To accept the suggested code line completion, select **Accept**.

    Your updated `GenerateSalesData` method could should be similar to the following:

    ```csharp
        public SalesData[] GenerateSalesData()
        {
            SalesData[] salesData = new SalesData[1000];
            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                salesData[i].dateSold = new DateOnly(2023, random.Next(1, 13), random.Next(1, 29));
                salesData[i].departmentName = ProdDepartments.departmentNames[random.Next(0, ProdDepartments.departmentNames.Length)];

                // int indexOfDept = Array.IndexOf(ProdDepartments.departmentNames, salesData[i].departmentName);
                // string deptAbb = ProdDepartments.departmentAbbreviations[indexOfDept];
                // string firstDigit = (indexOfDept + 1).ToString();
                // string nextTwoDigits = random.Next(1, 100).ToString("D2");
                // string sizeCode = new string[] { "XS", "S", "M", "L", "XL" }[random.Next(0, 5)];
                // string colorCode = new string[] { "BK", "BL", "GR", "RD", "YL", "OR", "WT", "GY" }[random.Next(0, 8)];
                // string manufacturingSite = ManufacturingSites.manufacturingSites[random.Next(0, ManufacturingSites.manufacturingSites.Length)];
                //
                // salesData[i].productID = $"{deptAbb}-{firstDigit}{nextTwoDigits}-{sizeCode}-{colorCode}-{manufacturingSite}";
                salesData[i].productID = ConstructProductId(salesData[i]);
                salesData[i].quantitySold = random.Next(1, 101);
                salesData[i].unitPrice = random.Next(25, 300) + random.NextDouble();
                salesData[i].baseCost = salesData[i].unitPrice * (1 - (random.Next(5, 21) / 100.0));
                salesData[i].volumeDiscount = (int)(salesData[i].quantitySold * 0.1);

            }

            return salesData;
        }

    ```

## Create the DeconstructProductId method

The DeconstructProductId method will extract the department abbreviation, product serial number, size code, color code, and manufacturing site from the productID. The method will return a 2-dimensional array containing the description and value for each of these components.

The QuarterlySalesReport method will use the extracted product serial number from DeconstructProductId to identify the most profitable product for each quarter (ignoring size, color, and manufacturing location).

1. Create a blank code line below the ConstructProductId method.

1. Open inline chat and then enter the following prompt:

    ```plaintext
    Create a public static method named DeconstructProductId that takes a productID string as input and returns a 2-dimensional array containing the description and value for: department abbreviation, product serial number, size code, color code, and manufacturing site.
    ```

1. Review the suggested code update and then select **Accept**.

    ```csharp
        public static string[,] DeconstructProductId(string productID)
        {
            string[] parts = productID.Split('-');
            string[,] result = new string[5, 2];

            result[0, 0] = "Department Abbreviation";
            result[0, 1] = parts[0];

            result[1, 0] = "Serial Number";
            result[1, 1] = parts[1];

            result[2, 0] = "Size Code";
            result[2, 1] = parts[2];

            result[3, 0] = "Color Code";
            result[3, 1] = parts[3];

            result[4, 0] = "Manufacturing Site";
            result[4, 1] = parts[4];

            return result;
        }

    ```

## Update `QuarterlySalesReport` method to identify the most profitable product

1. Select the `QuarterlySalesReport` method in the code editor.

1. Open an inline chat and then enter the following prompt:

    ```plaintext
    Update the QuarterlySalesReport method to include a dictionary named quarterlyTopProfitForProductNumbers that uses the calendar quarter as the key and another dictionary as the value. The inner dictionary should use string for the key and it should have five values: integer, double, double, double, double. Inside the foreach loop that iterates through the SalesData array, use DeconstructProductId()[1, 1] to get the product serial number and GetQuarter to get the quarter. For each yearly quarter, build the inner dictionary as follows: If the product serial number isn't already a key in the inner dictionary for the quarter, add it the appropriate inner dictionary as a new key and set the associated values as follows: units sold, total sales amount, unit cost, total profit, and profit percentage for the current sales order. If the product serial number is already a key in the inner dictionary for the quarter, update the appropriate inner dictionary values as follows: sum the units sold, sum the total sales amount, calculate the average unit cost (total sales divided by units sold), sum the total profit, and calculate the average profit percentage.
    ```

1. Review the suggested code update and then select **Accept**.

1. Review the updates in the code editor and use GitHub Copilot to fix any errors or issues that are identified.

1. Locate the code line that assigns the value to the product serial number variable.

    For example:

    ```csharp
    string productSerialNumber = DeconstructProductId(data.productID)[1, 1];
    ```

1. Manually update the code line to include the abbreviation for the department and placeholders values for the other productId components as follows:

    ```csharp
    string[,] deconstructedProductId = DeconstructProductId(data.productID);
    string productSerialNumber = deconstructedProductId[0, 1] + "-" + deconstructedProductId[1, 1] + "-ss-cc-mmm";
    ```

1. Select the `QuarterlySalesReport` method in the code editor.

1. Open an inline chat and then enter the following prompt:

    ```plaintext
    Update the QuarterlySalesReport method to identify the three product serial numbers in quarterlyTopProfitForProductNumbers with highest profit during each quarter. Update the quarterly report to display the following data for the three most profitable product serial numbers in each quarter: the product serial number, the sum of units sold, the sum of total sales, the calculated average unit cost, the sum of total profit, and the calculated average profit percentage.
    ```

1. Review the suggested code update and then select **Accept**.

1. Review the updates in the code editor and use GitHub Copilot to fix any errors or issues that are identified.

    At this point GitHUb Copilot may have already displayed the top three product serial numbers in descending order and formatted the information as a table.

1. Save the changes to the Program.cs file, and then run the application to verify that the updates work as expected.

    If the output is not ordered correctly and displayed in a table format, use the following prompts to finish updating the QuarterlySalesReport method.

1. Select the `QuarterlySalesReport` method in the code editor.

1. Open an inline chat and then enter the following prompt:

    ```plaintext
    Update the QuarterlySalesReport method to list three most profitable product serial numbers in descending order of profit (highest to lowest).
    ```

    Save and run the application to verify that the updates work as expected before applying updates with the next prompt.

    ```plaintext
    Update the QuarterlySalesReport method to display all of information for the top three most profitable products in a table. The left column should be 22 characters wide. The remaining columns should be 20 characters wide. Each column should have a right-aligned header. The sales data should be right-aligned and padded to fit the column with.
    ```

    Save and run the application to verify that the updates work as expected before applying updates with the next prompt.

    ```output
    Use extended ASCII characters to add border lines to the top three most profitable products table. Border lines should enclose the table perimeter. Border lines should separate the interior columns of the table. 
    ```

