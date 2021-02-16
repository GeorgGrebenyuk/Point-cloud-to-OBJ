using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PointCloudToOBJ
{
	public static class Actions
	{
		public static StringBuilder OBJ_File = new StringBuilder();
		public static StringBuilder MTL_File = new StringBuilder();
		public static long PointNumber = 0;
		public static int TypeOfTranslation =0;


		public static void ConvertToOBJ (string PathToSourcePC, string PathToSave, double Precision)
		{
			PointNumber = 0;
			OBJ_File.Clear();
			MTL_File.Clear();
			string File_Name = Path.GetFileNameWithoutExtension(PathToSave);
			OBJ_File.AppendLine($"mtllib {File_Name}.mtl");
			long Counter = 0;
			foreach (string PointStr in File.ReadLines(PathToSourcePC))
			{
				PointNumber++;
				Counter++;
				double X_coord = Convert.ToDouble(PointStr.Split(' ')[0]);
				double Y_coord = Convert.ToDouble(PointStr.Split(' ')[2]);
				double Z_coord = Convert.ToDouble(PointStr.Split(' ')[1]);

				if (TypeOfTranslation == 1) Geometry.CubeStructure(X_coord, Y_coord, Z_coord, Precision);
				else if (TypeOfTranslation == 2) Geometry.OctahedronStructure(X_coord, Y_coord, Z_coord, Precision);
				else if (TypeOfTranslation == 3) Geometry.TetrahedronStructure(X_coord, Y_coord, Z_coord, Precision);
				else break;

				int R_Color = Convert.ToInt32(PointStr.Split(' ')[3]);
				int G_Color = Convert.ToInt32(PointStr.Split(' ')[4]);
				int B_Color = Convert.ToInt32(PointStr.Split(' ')[5]);
				AddCollorOfPoint(R_Color, G_Color, B_Color);

				if (Counter == 50000)
				{
					File.AppendAllText(PathToSave, OBJ_File.ToString(), Encoding.ASCII); //для файла OBJ
					File.AppendAllText(PathToSave.Replace(".obj", ".mtl"), MTL_File.ToString(), Encoding.ASCII); //для файла MTL
					OBJ_File.Clear();
					MTL_File.Clear();
					Counter = 0;
				}
			}

			File.AppendAllText(PathToSave, OBJ_File.ToString(), Encoding.ASCII); //для файла OBJ
			File.AppendAllText(PathToSave.Replace(".obj", ".mtl"), MTL_File.ToString(), Encoding.ASCII); //для файла MTL
			OBJ_File.Clear();
			MTL_File.Clear();
		}
		public static void AddCollorOfPoint(int R_Color, int G_Color, int B_Color)
		{
			double r = Math.Round(R_Color / 255d, 3);
			double g = Math.Round(G_Color / 255d, 3);
			double b = Math.Round(B_Color / 255d, 3);

			MTL_File.AppendLine($"newmtl p{PointNumber}");
			MTL_File.AppendLine("Kd " + r + ' ' + g + ' ' + b);
			MTL_File.AppendLine("Ns 1");
		}
	}
}
