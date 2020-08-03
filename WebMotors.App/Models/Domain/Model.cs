using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.App.Models.Domain
{
	public class Model
	{
		public int ID { get; set; }
		public int MakeID { get; set; }
		public string Name { get; set; }
	}
}
