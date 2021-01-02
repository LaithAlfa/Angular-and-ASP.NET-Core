using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCities.Data.Models
{
    public class City
    {
        #region Constructor 
        public City()
        {

        }
         #endregion
        
        #region Properties
        ///<summary>
        /// The unique ID and primary key for this City
        ///</sumary>
        [Key]
        [Required]
        public int Id {get; set;}
        ///<summary>
        /// City name (in UTF* format)
        ///</sumary>
        public string Name {get; set;}
        ///<summary>
        /// City name (in ASCII format)
        ///</sumary>
        public string Name_ASCII {get; set;}
        ///<summary>
        /// City latitude
        ///</sumary>
        [Column(TypeName = "decimal(7,4)")]
        public decimal Lat {get; set;}

        ///<summary>
        /// City longitude
        ///</sumary>
        [Column(TypeName = "decimal(7,4)")]
        public decimal Lon {get; set;}
        #endregion

        #region Navigation Properties
        ///<summary>
        ///The country related to this city
        ///</summary>
        public virtual Country Country {get; set;}
        #endregion

        ///<summary>
        /// Country Id (Foreign key)
        ///</sumary>
        public int CountryId {get; set;}





    }   
}
