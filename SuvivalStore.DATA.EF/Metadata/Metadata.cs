using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuvivalStore.DATA.EF.Models//.Metadata
{
    public class CategoryMetadata
    {
        [Required(ErrorMessage = "* Required Field")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        [StringLength(500, ErrorMessage = "* Must not exceed 500 characters")]
        [DisplayFormat(NullDisplayText = "* No Description")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? CategoryDescription { get; set; }
    }

    public class GearMetadata
    {
        [Required(ErrorMessage = "* Required Field")]
        [StringLength(75, ErrorMessage = "* Must not exceed 75 characters")]
        [Display(Name = "Gear")]
        public string GearName { get; set; } = null!;

        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "* Must not exceed 500 characters")]
        [DisplayFormat(NullDisplayText = "No Description")]
        [DataType(DataType.MultilineText)]
        public string? GearDescription { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:c}")]
        [Display(Name = "Price")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal? GearPrice { get; set; }

        [Range(0, short.MaxValue)]
        [Display(Name = "In Stock")]
        public short? UnitsInStock { get; set; }

        [Range(0, short.MaxValue)]
        [Display(Name = "On Order")]
        public short? UnitsOnOrder { get; set; }

        [Display(Name = "Discontinued")]
        public bool? IsDiscontinued { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Gear Status")]
        public int? StatusId { get; set; }

        [StringLength(75)]
        [Display(Name = "Image")]
        public string? GearImage { get; set; }
    }

    public class GearStatusMetadata
    {
        [Required(ErrorMessage = "* Required Field")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        [Display(Name = "Gear Status")]
        public string StatusName { get; set; } = null!;
    }

    public class OrderMetadata
    {
        [Display(Name = "Order Date")]
        [DisplayFormat(NullDisplayText = "N/A", ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? OrderDate { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(100, ErrorMessage = "* Must not exceed 100 characters")]
        [Display(Name = "Ship To")]
        public string? ShipToName { get; set; }

        [Display(Name = "Address")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(100, ErrorMessage = "* Must not exceed 100 characters")]
        public string? ShipToAddress { get; set; }

        [Display(Name = "City")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(100, ErrorMessage = "* Must not exceed 100 characters")]
        public string? ShipToCity { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(2, ErrorMessage = "* Must not exceed 2 characters")]
        [Display(Name = "State")]
        public string? ShipToState { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(5, ErrorMessage = "* Must not exceed 5 characters")]
        [Display(Name = "Zip")]
        [DataType(DataType.PostalCode)]
        public string? ShipToZip { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(24, ErrorMessage = "* Must not exceed 24 characters")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string? ShipToPhone { get; set; }
    }

    public class UserDetailMetadata
    {
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "* Required Field")]
        public string FirstName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "* Required Field")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Address")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(100, ErrorMessage = "* Must not exceed 100 characters")]
        public string? Address { get; set; }

        [Display(Name = "City")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(50, ErrorMessage = "* Must not exceed 50 characters")]
        public string? City { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(2, ErrorMessage = "* Must not exceed 2 characters")]
        [Display(Name = "State")]
        public string? State { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(5, ErrorMessage = "* Must not exceed 5 characters")]
        [Display(Name = "Zip")]
        [DataType(DataType.PostalCode)]
        public string? Zip { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [StringLength(24, ErrorMessage = "* Must not exceed 24 characters")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
    }
}
