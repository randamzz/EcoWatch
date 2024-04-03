using System.ComponentModel.DataAnnotations;

namespace EcoWatchTan.Models
{
	public class City
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public double Lon { get; set; }
		public double Lat { get; set; }
		
	}
}
