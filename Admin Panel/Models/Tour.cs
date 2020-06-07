using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Panel.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(50)")]

        [DisplayName("Starts At")]
        public string StartDate { get; set; }
        [Column(TypeName = "varchar(50)")]

        [DisplayName("Ends At")]
        public string EndDate { get; set; }
        [Column(TypeName = "varchar(50)")]

        [DisplayName("Categories")]

        public string Categories { get; set; }


    }
}
