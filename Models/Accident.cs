using System;
using System.ComponentModel.DataAnnotations;

namespace intex2.Models
{
    public class Accident
    {
        public static int Count { get; internal set; }
        [Key]
        [Required]
        public int CRASH_ID { get; set; }

        [Required(ErrorMessage = "Enter route as numbers: 2040 ")]
        public string ROUTE { get; set; }

        [Required(ErrorMessage = "Enter Milepoint as numbers: 2040 ")]
        public int MILEPOINT { get; set; }

        [Required(ErrorMessage = "Enter Latitude as number : 2040 ")]
        public int LAT_UTM_Y { get; set; }

        [Required(ErrorMessage = "Enter numbers: 2040 ")]
        public int LONG_UTM_X { get; set; }

        [Required(ErrorMessage = "Enter text: I-15 HILL RD ")]
        public string MAIN_ROAD_NAME { get; set; }

        [Required(ErrorMessage = "Enter City: Provo ")]
        public string CITY { get; set; }

        [Required(ErrorMessage = "Enter numbers: 2040 ")]
        public string COUNTY_NAME { get; set; }

        [Required(ErrorMessage = "Enter Crash Severity: Fatal ")]
        public string CRASH_SEVERITY_ID { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string WORK_ZONE_RELATED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string PEDESTRIAN_INVOLVED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string BICYCLIST_INVOLVED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string MOTORCYCLE_INVOLVED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string IMPROPER_RESTRAINT { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string UNRESTRAINED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string DUI { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string INTERSECTION_RELATED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string WILD_ANIMAL_RELATED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string DOMESTIC_ANIMAL_RELATED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string OVERTURN_ROLLOVER { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string COMMERCIAL_MOTOR_VEH_INVOLVED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string TEENAGE_DRIVER_INVOLVED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string OLDER_DRIVER_INVOLVED { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string NIGHT_DARK_CONDITION { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string SINGLE_VEHICLE { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string DISTRACTED_DRIVING { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string DROWSY_DRIVING { get; set; }

        [Required(ErrorMessage = "Enter True or False ")]
        public string ROADWAY_DEPARTURE { get; set; }

        [Required(ErrorMessage = "Enter Crash time: 18:42:00 ")]
        public string CRASH_TIME { get; set; }

        [Required(ErrorMessage = "Enter Crash Day numeric: 20 ")]
        public int DAY { get; set; }

        [Required(ErrorMessage = "Enter Crash month numeric: 2 ")]
        public int MONTH { get; set; }

        [Required(ErrorMessage = "Enter Crash year numeric: 2020 ")]
        public int YEAR { get; set; }

    }
}



