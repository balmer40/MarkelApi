using System;
using System.ComponentModel.DataAnnotations;

namespace MarkelApi.Models
{
	public class Claim
	{
        [Required]
        public string Ucr { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ClaimDate { get; set; }

        [Required]
        public DateTime LossDate { get; set; }

        [Required]
        public string AssuredName { get; set; }

        [Required]
        public double IncuredLoss { get; set; }

        [Required]
        public bool Closed { get; set; }
    }
}

