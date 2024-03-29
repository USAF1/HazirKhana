﻿using EntityLibrary.CuisineManagment;
using EntityLibrary.LocationManagment;
using EntityLibrary.ProductsManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary.RestaurantManagment
{
    public class Restaurant
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar(100)")]
        public string Name { get; set; }

        [Required]
        public long ContactMob { get; set; }

        public long ConatctTel { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Address { get; set; }

        public Provience Provience { get; set; }

        public City City { get; set; }

        public int PostalCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Discription { get; set; }

        public List<Cuisine> Cuisines { get; set; }

        public List<Product> Products { get; set; }

        [Required]
        public int SalesTax { get; set; }
        
        [Required]
        public int OrderLedTime { get; set; }

        [Required]
        public int PercentageCutOff { get; set; }

        [Required]
        public string Reservation { get; set; }

        [Required]
        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Banner { get; set; }

    }
}
