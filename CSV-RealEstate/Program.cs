using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_RealEstate
{
    // WHERE TO START?
    // 1. Complete the RealEstateType enumeration
    // 2. Complete the RealEstateSale object.  Fill in all properties, then create the constructor.
    // 3. Complete the GetRealEstateSaleList() function.  This is the function that actually reads in the .csv document and extracts a single row from the document and passes it into the RealEstateSale constructor to create a list of RealEstateSale Objects.
    // 4. Start by displaying the the information in the Main() function by creating lambda expressions.  After you have acheived your desired output, then translate your logic into the function for testing.
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();

            //Display the average square footage of a Condo sold in the city of Sacramento, 
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine(GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento"));

            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetTotalSalesByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Residential, "Elk Grove"));

            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.
            Console.WriteLine(GetNumberOfSalesByRealEstateTypeAndZip(realEstateSaleList, RealEstateType.Residential, "95842"));

            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetAverageSalePriceByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Lot, "Sacramento"));

            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetAveragePricePerSquareFootByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento"));

            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.
            Console.WriteLine(GetNumberOfSalesByDayOfWeek(realEstateSaleList, DayOfWeek.Wednesday));

            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.
            Console.WriteLine(GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(realEstateSaleList, RealEstateType.Residential, "Sacramento", 300000));

            //Extra Credit:
            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.
            //Console.WriteLine(GetTop5CitiesByNumberOfHomesSold());
            Console.ReadKey();
        }

        public static List<RealEstateSale> GetRealEstateSaleList()
        {
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.  bool skipFirstLine = true;
            List<RealEstateSale> RealEstateData = new List<RealEstateSale>();
            StreamReader reader = new StreamReader("realestatedata.csv");
            string skipline = reader.ReadLine();
            while (!reader.EndOfStream)
            { 
                RealEstateData.Add(new RealEstateSale(reader.ReadLine()));
            }
            return RealEstateData;
        }

        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
            return GetRealEstateSaleList().Where(x => x.City.ToLower() == city.ToLower() && x.Type == realEstateType).Average(x => x.SqFt);
        }

        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return (decimal)realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Sum(x => x.Price);
        }

        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return realEstateDataList.Count(x => x.Type == realEstateType && x.Zip.ToString() == zipcode);
        }

        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return (decimal)Math.Round(realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Average(x => x.Price), 2);
        }
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return (decimal)Math.Round(realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower()).Average(x => x.Price / x.SqFt), 2);
        }

        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return realEstateDataList.Where(x => x.SaleDate.DayOfWeek == dayOfWeek).Count();
        }

        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            return Math.Round(realEstateDataList.Where(x => x.Type == realEstateType && x.City.ToLower() == city.ToLower() && (decimal)x.Price > price).Average(x => x.Beds), 2);
        }

        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            return new List<string>();
        }
    }

    public enum RealEstateType
    {
        //fill in with enum types: Residential, MultiFamily, Condo, Lot
        Residential,
        MultiFamily,
        Condo,
        Lot
    }

    class RealEstateSale
    {
        ///Create properties, using the correct data types (not all are strings) for all columns of the CSV
        ///
        //STREET
        public string Street
        { get; set; }

        //CITY
        public string City
        { get; set; }

        //ZIP
        public int Zip
        { get; set; }

        //STATE
        public string State
        { get; set; }

        //BEDS
        public int Beds
        { get; set; }

        //BATHS
        public int Baths
        { get; set; }

        //SQ FT
        public double SqFt
        { get; set; }

        //TYPE
        public RealEstateType Type
        { get; set; }

        //SALE DATE
        public DateTime SaleDate
        { get; set; }

        //PRICE
        public double Price
        { get; set; }

        //LATITUDE
        public double Latitude
        { get; set; }

        //LONGITUDE
        public double Longitude
        { get; set; }

        //The constructor will take a single string arguement.  This string will be one line of the real estate data.
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions
        public RealEstateSale(string lineInput)
        {
            // Split using the tab character due to the tab delimited data format
            List<string> placeData = lineInput.Split(',').ToList();

            //populate property values
            this.Street = placeData[0];
            this.City = placeData[1];
            this.Zip = int.Parse(placeData[2]);
            this.State = placeData[3];
            this.Beds = int.Parse(placeData[4]);
            this.Baths = int.Parse(placeData[5]);
            this.SqFt = double.Parse(placeData[6]);

            // When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
            // value of the "Type" column to determine its corresponding enumeration type.
            if (placeData[7].ToLower() == "residential")
            {
                this.Type = RealEstateType.Residential;
            }
            if (placeData[7].ToLower() == "condo")
            {
                this.Type = RealEstateType.Condo;
            }
            if (placeData[7].ToLower() == "multi-family")
            {
                this.Type = RealEstateType.MultiFamily;
            }

            if (SqFt == 0)
            {
                this.Type = RealEstateType.Lot;
            }

            this.SaleDate = DateTime.Parse(placeData[8]);
            this.Price = double.Parse(placeData[9]);
            this.Latitude = double.Parse(placeData[10]);
            this.Longitude = double.Parse(placeData[11]);
        }
    }
}