using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornucopiaV2;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PhilipFractal
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().Run(args);
		}
		private void Run(string[] args)
		{
			string versionFile = @"d:\numbers\philip\pv.txt";
			int version =
				int
				.Parse
				(File
					.ReadAllText
					(versionFile
					)
				)
				;
			string map = args[0];
			int imageWidth = int.Parse(args[1]);
			int imageHeight = int.Parse(args[2]);
			float unitWidth = float.Parse(args[3]);
			float unitHeight = float.Parse(args[4]);
			float lineWidth = float.Parse(args[5]);
			float borderPixels = float.Parse(args[6]);
			int level = 5;
			float levelEmSize = 18.5F;
			CurveType curveType = CurveType.ZigZag;
			CorImage image = new CorImage(imageWidth, imageHeight, Color.White);
			SizeF sizeF = image.MeasureString(level.ToString(), "arial", levelEmSize);
			image
				.DrawString
				(level.ToString()
				, "arial"
				, levelEmSize
				, Color.Black
				, imageWidth / 2 - sizeF.Width / 2
				, imageHeight / 2 - sizeF.Height / 2
				)
				;
			List<NavUnit> navUnits = new List<NavUnit>(level);
			PhilipFractal philipFractal = new PhilipFractal();
			map = philipFractal.Map(level);
			ConDeb.Print(map.ToUpper());
			navUnits
				.Drive
				(map
				, Direction.West
				, 0
				, 0
				, unitWidth
				, unitHeight
				)
				;
			List<Color> colors = SetupColors();
			ColorGradientFactory cgf =
				new ColorGradientFactory
				(colors.ToArray()
				)
				;
			navUnits.CentreGraph(imageWidth, imageHeight, borderPixels);
			navUnits.FitGraph(imageWidth, imageHeight, 10);
			navUnits.Draw(image, lineWidth, curveType, cgf);
			//image.DrawString("Hello", "Arial", 100.5F, Color.Black, 0, 0);
			image.Save(@"d:\numbers\philip\newphilip" + curveType.ToString() + level.ToString() +version.ToString() + ".gif", ImageFormat.Gif);
			image.Dispose();
			version++;
			File.WriteAllText(versionFile, version.ToString());
		}

		private static List<Color> SetupColors()
		{
			return new List<Color>
			{
				Color.Red,
				Color.Green,
				Color.Green,
				Color.Blue,
				Color.Blue,
				Color.Magenta,
				Color.Magenta,
				Color.Red,
				Color.Red,
				Color.Green,
				Color.Green,
				Color.Blue,
				Color.Blue,
				Color.Magenta,
				Color.Magenta,
				Color.Red,
				Color.Red,
				Color.Green,
				Color.Green,
				Color.Blue,
				Color.Blue,
				Color.Magenta,
				Color.Magenta,
				Color.Red,
				Color.Red,
				Color.Green,
				Color.Green,
				Color.Blue,
				Color.Blue,
				Color.Magenta,
				Color.Magenta,
				Color.Red
			};
		}
	}
}
