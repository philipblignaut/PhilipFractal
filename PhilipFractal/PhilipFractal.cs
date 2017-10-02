using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornucopiaV2;

namespace PhilipFractal
{
	public class PhilipFractal
	{
		private const string leaf = "RRR";
		public PhilipFractal()
		{
		}

		public string Map(int level)
		{
			return
				MapCorner(level) + "F"
				+ MapCorner(level) + "F"
				+ MapCorner(level) + "F"
				+ MapCorner(level) + "F"
				;
		}
		private string MapCorner(int level)
		{
			string map = C.es;
			if (level == 1)
			{
				map = "F" + leaf + "F";
			}
			else if (level == 2)
			{
				map =
					"F".Repeat(3)
					+ MapCorner(level - 1)
					+ "F"
					+ MapCorner(level - 1)
					+ "F"
					+ MapCorner(level - 1)
					+ "F".Repeat(3)
					;
			}
			else
			{
				map =
					MapCorner(level - 1)
					+ "F"
					+ MapCorner(level - 1)
					+ "F"
					+ MapCorner(level - 1)
					+ "F".Repeat((int)(3 * Math.Pow(2, level - 1)))
					;
			}
			return map;
		}
	}

}
