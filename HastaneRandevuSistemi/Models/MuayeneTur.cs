﻿using System;
using System.ComponentModel.DataAnnotations;
namespace HastaneRandevuSistemi.Models
{
	public class MuayeneTur
	{
		public int MuayeneTurID { get; set; }
        public string MuayeneTurAdi { get; set; }
		public ICollection<Randevu> Randevular { get; set; }
    }
}

