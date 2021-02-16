using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCloudToOBJ
{
	public static class Geometry
	{	
		public static void CubeStructure (double X_coord, double Y_coord, double Z_coord, double Precision)
		{
			double a = Precision;
			long p = Actions.PointNumber-1;
			var n = Environment.NewLine;
			string p1 = $"v {X_coord - a / 2} {Y_coord + a / 2} {Z_coord + a / 2}";
			string p2 = $"v {X_coord - a / 2} {Y_coord - a / 2} {Z_coord + a / 2}";
			string p3 = $"v {X_coord + a / 2} {Y_coord - a / 2} {Z_coord + a / 2}";
			string p4 = $"v {X_coord + a / 2} {Y_coord + a / 2} {Z_coord + a / 2}";

			string p5 = $"v {X_coord - a / 2} {Y_coord + a / 2} {Z_coord - a / 2}";
			string p6 = $"v {X_coord - a / 2} {Y_coord - a / 2} {Z_coord - a / 2}";
			string p7 = $"v {X_coord + a / 2} {Y_coord - a / 2} {Z_coord - a / 2}";
			string p8 = $"v {X_coord + a / 2} {Y_coord + a / 2} {Z_coord - a / 2}";

			string f1 = $"f {8 * p + 1} {8 * p + 2} {8 * p + 3} {8 * p + 4}";
			string f2 = $"f {8 * p + 5} {8 * p + 6} {8 * p + 7} {8 * p + 8}";
			string f3 = $"f {8 * p + 4} {8 * p + 3} {8 * p + 7} {8 * p + 8}";
			string f4 = $"f {8 * p + 1} {8 * p + 4} {8 * p + 8} {8 * p + 5}";
			string f5 = $"f {8 * p + 1} {8 * p + 2} {8 * p + 6} {8 * p + 5}";
			string f6 = $"f {8 * p + 2} {8 * p + 3} {8 * p + 7} {8 * p + 6}";

			Actions.OBJ_File.AppendLine($"g p{Actions.PointNumber}");
			Actions.OBJ_File.AppendLine(p1 + n + p2 + n + p3 + n + p4 + n + p5 + n + p6 + n + p7 + n + p8);
			Actions.OBJ_File.AppendLine($"usemtl p{Actions.PointNumber}");
			Actions.OBJ_File.AppendLine(f1 + n + f2 + n + f3 + n + f4 + n + f5 + n + f6);
		}
		public static void OctahedronStructure(double X_coord, double Y_coord, double Z_coord, double Precision)
		{
			double a = Precision;
			long p = Actions.PointNumber - 1;
			var n = Environment.NewLine;
			string p1 = $"v {X_coord + a / 2} {Y_coord - a / 2} {Z_coord}";
			string p2 = $"v {X_coord - a / 2} {Y_coord - a / 2} {Z_coord}";
			string p3 = $"v {X_coord - a / 2} {Y_coord + a / 2} {Z_coord}";
			string p4 = $"v {X_coord + a / 2} {Y_coord + a / 2} {Z_coord}";

			string p5 = $"v {X_coord} {Y_coord} {Z_coord + Math.Round(a / 1.414, 3)}";
			string p6 = $"v {X_coord} {Y_coord} {Z_coord - Math.Round(a / 1.414, 3)}";

			string f1 = $"f {6 * p + 1} {6 * p + 2} {6 * p + 5}";
			string f2 = $"f {6 * p + 2} {6 * p + 3} {6 * p + 5}";
			string f3 = $"f {6 * p + 3} {6 * p + 4} {6 * p + 5}";
			string f4 = $"f {6 * p + 1} {6 * p + 4} {6 * p + 5}";
			string f5 = $"f {6 * p + 1} {6 * p + 2} {6 * p + 6}";
			string f6 = $"f {6 * p + 2} {6 * p + 3} {6 * p + 6}";
			string f7 = $"f {6 * p + 3} {6 * p + 4} {6 * p + 6}";
			string f8 = $"f {6 * p + 1} {6 * p + 4} {6 * p + 6}";

			Actions.OBJ_File.AppendLine($"g p{Actions.PointNumber}");
			Actions.OBJ_File.AppendLine(p1 + n + p2 + n + p3 + n + p4 + n + p5 + n + p6);
			Actions.OBJ_File.AppendLine($"usemtl p{Actions.PointNumber}");
			Actions.OBJ_File.AppendLine(f1 + n + f2 + n + f3 + n + f4 + n + f5 + n + f6 + n + f7 + n + f8);
		}
		public static void TetrahedronStructure(double X_coord, double Y_coord, double Z_coord, double Precision)
		{
			double a = Precision;
			long p = Actions.PointNumber - 1;
			var n = Environment.NewLine;

			string p1 = $"v {X_coord + Math.Round(a / 0.289, 3)} {Y_coord - a / 2} {Z_coord - Math.Round(a / 0.272, 3)}";
			string p2 = $"v {X_coord - Math.Round(a / 0.577, 3)} {Y_coord} {Z_coord - Math.Round(a / 0.272, 3)}";
			string p3 = $"v {X_coord + Math.Round(a / 0.289, 3)} {Y_coord + a / 2} {Z_coord - Math.Round(a / 0.272, 3)}";
			string p4 = $"v {X_coord} {Y_coord } {Z_coord + Math.Round(a / 0.544, 3)}";

			string f1 = $"f {4 * p + 1} {4 * p + 2} {4 * p + 3}";
			string f2 = $"f {4 * p + 1} {4 * p + 2} {4 * p + 4}";
			string f3 = $"f {4 * p + 2} {4 * p + 3} {4 * p + 4}";
			string f4 = $"f {4 * p + 1} {4 * p + 3} {4 * p + 4}";

			Actions.OBJ_File.AppendLine($"g p{Actions.PointNumber}");
			Actions.OBJ_File.AppendLine(p1 + n + p2 + n + p3 + n + p4);
			Actions.OBJ_File.AppendLine($"usemtl p{Actions.PointNumber}");
			Actions.OBJ_File.AppendLine(f1 + n + f2 + n + f3 + n + f4);
		}
	}
}
