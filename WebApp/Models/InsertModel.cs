using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
	public class InsertModel
	{
		public int TaskCount { get; set; }

		public int ProcCount { get; set; }

		public int SpeciesCount { get; set; }

		public int MinLoad { get; set; }

		public int MaxLoad { get; set; }

		public int RepeatsCount { get; set; }

		public int MatrixCount { get; set; }
	}
}