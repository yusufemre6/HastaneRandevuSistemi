﻿using System;
using System.ComponentModel.DataAnnotations;
namespace HastaneRandevuSistemi.Models
{
	public class KisiTipi
	{
        public int KisiTipiID{ get; set; }
        public string KisiTipiAdi { get; set; }
        public ICollection<Rol> Roller { get; set; }
    }
}

