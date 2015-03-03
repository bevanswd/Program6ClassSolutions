using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_ListeningHabits
{
    class Program
    {
        // Global List
        public static List<Play> musicDataList = new List<Play>();

        static void Main(string[] args)
        {
            // initalize dataset into list
            InitList();

            //call TotalPlays() function
            Console.WriteLine(TotalPlays());

            //call TotalPlaysByArtistName() function (by artistName)
            Console.WriteLine(TotalPlaysByArtistName("All Time Low"));

            //call TotalPlaysByArtistNameInYear() function (by artistName, year)
            //Console.WriteLine(TotalPlaysByArtistNameInYear("Skrillex","2014"));

            // keep console open
            Console.ReadLine();
        }

        /// <summary>
        /// A function to initalize the List from the csv file
        /// needed for testing
        /// </summary>
        public static void InitList()
        {
            // load data
            using (StreamReader reader = new StreamReader("scrobbledata.csv"))
            {
                // Get and don't use the first line
                string firstline = reader.ReadLine();
                // Loop through the rest of the lines
                while (!reader.EndOfStream)
                {
                    musicDataList.Add(new Play(reader.ReadLine()));
                }
            }
        }

        /// <summary>
        /// A function that will return the total ammount of plays in the dataset
        /// </summary>
        /// <returns>total number of plays</returns>
        public static int TotalPlays()
        {
            return musicDataList.Count();
        }

        /// <summary>
        /// A function that returns the number of plays ever by an artist
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <returns>total number of plays</returns>
        public static int TotalPlaysByArtistName(string artistName)
        {
            return musicDataList.Count(x => x.Artist.ToLower().ToString().Contains(artistName.ToLower()));
        }

        /// <summary>
        /// A function that returns the number of plays by a specific artist in a specific year
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <param name="year">one year</param>
        /// <returns>total plays in year</returns>
        public static int TotalPlaysByArtistNameInYear(string artistName, string year)
        {
            //List<Play> artistSublist = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //List<Play> playsByArtistInACertainYear = artistSublist.Where(x => x.Time.Year.ToString() == year).ToList();
            //return playsByArtistInACertainYear.Count();

            return musicDataList.Count(x => x.Artist.ToLower() == artistName.ToLower() && x.Time.Year.ToString() == year);
            
            //int count = 0;
            //for (int i = 0; i < musicDataList.Count; i++)
            //{
            //    Play x = musicDataList[i];
            //    if (x.Artist.ToLower() == artistName.ToLower() && x.Time.Year.ToString() == year)
            //    {
            //        count++;
            //    }
            //}
            //return count;

            //SPECIAL
            //return musicDataList.Where(x => x.Time.DayOfWeek == DayOfWeek.Friday && x.Time.Hour >= 12 && x.Time.Hour <= 17).GroupBy(x => x.Artist).OrderByDescending(x => x.Count()).First();
            //return 0;
        }

        /// <summary>
        /// A function that returns the number of unique artists in the entire dataset
        /// </summary>
        /// <returns>number of unique artists</returns>
        public static int CountUniqueArtists()
        {
            //musicDataList[0];
            List<string> allArtistPlays = musicDataList.Select(x => x.Artist + " is the jam").ToList();
            List<string> allUniqueArtists = allArtistPlays.Distinct().ToList();
            return allUniqueArtists.Count;
        }

        /// <summary>
        /// A function that returns the number of unique artists in a given year
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns>unique artists in year</returns>
        public static int CountUniqueArtists(string year)
        {  
            //List<Play> allArtistsAndPlaysOfTheYear = musicDataList.Where(x => x.Time.Year.ToString() == year).ToList();
            //List<string> justArtistNames = allArtistsAndPlaysOfTheYear.Select(x => x.Artist).ToList();
            //List<string> justUniqueArtistNames = justArtistNames.Distinct().ToList();
            //return justUniqueArtistNames.Count();

            //one-line pro version
            return musicDataList.Where(x => x.Time.Year.ToString() == year).Select(x => x.Artist).Distinct().Count();
            //return 0;
        }

        /// <summary>
        /// A function that returns a List of unique strings which contains
        /// the Title of each track by a specific artists
        /// </summary>
        /// <param name="artistName">artist</param>
        /// <returns>list of song titles</returns>
        public static List<string> TrackListByArtist(string artistName)
        {
            //1. get all plays by artist
            List<Play> allPlaysByArtist = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //2. select all tracks
            List<string> allTracksByArtist = allPlaysByArtist.Select(x => x.Title).ToList();
            //3. select unique (distinct) tracks
            List<string> allDistinctTracksByArtist = allTracksByArtist.Distinct().ToList();
            //4. return output
            return allDistinctTracksByArtist;
        }

        /// <summary>
        /// A function that returns the first time an artist was ever played
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <returns>DateTime of first play</returns>
        public static DateTime FirstPlayByArtist(string artistName)
        {
            //1. filter all plays based on the artist
            //List<Play> playsByArtist = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //2. order the  plays by date
            //List<Play> playsByArtistByDate = playsByArtist.OrderBy(x => x.Time).ToList();
            //3. take the first play, return its DateTime
            //Play firstPlayEverByArtist = playsByArtistByDate.First();
            //return firstPlayEverByArtist.Time;

            //one-line pro version
            return musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).OrderBy(x => x.Time).First().Time;
            //return new DateTime(1);
        }

        /// <summary>
        ///                     ***BONUS***
        /// A function that will determine the most played artist in a specified year
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns>most popular artist in year</returns>
        public static string MostPopularArtistByYear(string year)
        {
            //1. filter plays by year
            List<Play> playsInTheYear = musicDataList.Where(x => x.Time.Year.ToString() == year).ToList();
            //2. group the plays by the artist
            //(using IEnumerable & IGrouping)
            IEnumerable<IGrouping<string, Play>> playsGroupedByArtist = playsInTheYear.GroupBy(x => x.Artist);
            //3. order them in the descending order based on the number of plays
            List<IGrouping<string, Play>> orderedPlaysGroupedByArtist = playsGroupedByArtist.OrderByDescending(x => x.Count()).ToList();
            //4. take the first item out
            IGrouping<string, Play> mostPopular = orderedPlaysGroupedByArtist.First();
            //5. return artist name
            return mostPopular.Key; //use .Key to return Artist value

            //one-line pro version
            //return musicDataList.Where(x => x.Time.Year.ToString() == year).GroupBy(x => x.Artist).OrderByDescending(x => x.ToArray().Length).First().First().Key;
        }
    }

    public class Play
    {
        // DEFINE PROPERTIES:

        //TIME
        private DateTime _time;
        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        //ARTIST
        private string _artist;
        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
            }
        }

        //TITLE
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        //ALBUM
        private string _album;
        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
            }
        }

        public Play(string lineInput)
        {
            // Split using the tab character due to the tab delimited data format
            string[] playData = lineInput.Split('\t');

            // Get the time in milliseconds and convert to C# DateTime
            DateTime posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            this.Time = posixTime.AddMilliseconds(long.Parse(playData[0]));

            // need to populate the rest of the properties

            //set artist
            this.Artist = playData[1];

            //set title
            this.Title = playData[2];

            //set album
            this.Album = playData[3];

        }
    }
}