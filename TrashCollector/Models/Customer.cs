//using PayPal.PayPalAPIInterfaceService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public double? paymentDue { get; set; }
        public double? monthlyPayment { get; set; }
        public DateTime? paymentDay { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public byte? pickupDay { get; set; }
        public DateTime? suspendStart { get; set; }
        public DateTime? suspendEnd { get; set; }
        public DateTime? OneTimePickup { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId {get;set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}