using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WorldCities.Data.Models
{
    public class Country
    {
        #region Constructor
        public Country()
        {

        }
        #endregion
        

        #region Properties
        ///<summary>
        /// The unique id and primart key for this Country
        ///</summary>
        [Key]
        [Required]
        public int Id {get; set;}

        ///<summary>
        /// Country name (in UTF8 format)
        ///</summary>
        public string Name {get; set;}

        ///<summary>
        /// Country code (in ISO 3166-ALPHA-2 format)
        ///</summary>
        public string ISO2 {get; set;}
        
        #region Navigation Properties
        ///<summary>
        /// alist containing all the cites related to this country.
        ///</summary>
        public virtual List<City> Cities {get; set;}
        #endregion

        ///<summary>
        /// Country code (in IS 3166-1 ALPHA format)
        ///</summary>
        public string ISO3 {get; set;}
        #endregion
    }


}