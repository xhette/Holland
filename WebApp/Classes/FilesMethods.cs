using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings;
using System.Xml.Serialization;

using WebApp.XmlModels;

namespace WebApp.Classes
{
	public static class FilesMethods
	{
		public static byte[] FromXml(string rootPath, string folderName, int id, int startType)
		{
			string startFolder = "";

			switch (startType)
			{
				case 1:
					startFolder = "Random";
					break;
				case 2:
					startFolder = "CriticalWay";
					break;
				default:
					startFolder = "Random";
					break;
			}

			string filePath = $"{rootPath}\\{folderName}\\{startFolder}\\{id}.xml";

			//XmlDocument xDoc = new XmlDocument();
			//xDoc.Load(filePath);

			XmlSerializer formatter = new XmlSerializer(typeof(Root));
			Root root;
			using (FileStream fs = new FileStream(filePath, FileMode.Open))
			{
				root = (Root)formatter.Deserialize(fs);
			}

			return Create(root, startType, $"{rootPath}\\{folderName}\\{startFolder}\\{id}.pdf");
		}

		static byte[] Create(Root root, int startType, string rootPath)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<body face='Arial' encoding='koi8-r' leftmargin=\"50px\">");

			string startTypeName = "";

			switch (startType)
			{
				case 1:
					startTypeName = "Случайно";
					break;
				case 2:
					startTypeName = "Критический путь";
					break;
				default:
					startTypeName = "Случайно";
					break;
			}

			sb.AppendFormat("<p><b>Начальное приближение:</b> {0}</p>", startTypeName);
			sb.Append("<p><b>Задания:</b></p>");
			sb.Append("<p></p>");
			sb.Append("<table cellspacing=\"15px\">");

			foreach (var row in root.Tasks.Rows)
			{
				sb.Append("<tr>");
				foreach (var col in row.Cols)
				{
					sb.AppendFormat("<td>{0}</td>", col);
				}
				sb.Append("</tr>");
			}
			sb.Append("</table>");

			sb.Append("<p></p>");
			sb.Append("<p><b>Поколения:</b></p>");

			int i = 1, j = 1;

			foreach (var generation in root.Generations)
			{
				sb.AppendFormat("<p><u>Поколение {0}</u></p>", i);
				sb.Append("<p></p>");

				foreach (var specie in generation.Species)
				{
					sb.AppendFormat("<p>Особь {0}</p>", j);
					sb.Append("<p>Гены: </p>");

					int[,] genes = GetGenesMatrix(specie.Genes, root.Tasks.Rows[0].Cols.Count);

					sb.Append("<table cellspacing=\"15px\">");

					for (int row = 0; row < genes.GetLength(0); row++)
					{
						sb.Append("<tr>");

						for (int col = 0; col < genes.GetLength(1); col++)
						{
							sb.AppendFormat("<td>{0}</td>", genes[row, col]);
						}

						sb.Append("</tr>");
					}

					sb.Append("</table>");

					sb.AppendFormat("<p>Фитнес: {0}</p>", specie.Fitness);
					sb.AppendFormat("<p>Адаптация: {0}</p>", specie.Adaptation);

					j++;
				}

				j = 1;
				i++;
			}
			sb.Append("</body>");

			var stringBytes = Encoding.UTF8.GetBytes(sb.ToString());

			using (var memoryStream = new MemoryStream())

			{
				memoryStream.Write(stringBytes, 0, stringBytes.Length);

				byte[] bytes = memoryStream.ToArray();

				return bytes;
			}

		}


		static int[,] GetGenesMatrix(List<Gene> genes, int colsCount)
		{
			int[,] result = new int[1, colsCount];
			int row = 0;

			foreach (var gene in genes)
			{
				if (result[row, gene.Processor] != 0)
				{
					row++;
				}

				if (row == result.GetLength(0))
				{
					result = (int[,])HollandMethods.Methods.CommonMatrixMethods.ResizeMatrix(result, result.GetLength(0) + 1, result.GetLength(1));
				}

				result[row, gene.Processor] = gene.ProcessingTime;
			}

			return result;
		}
	}
}
