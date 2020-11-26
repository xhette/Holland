using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using HollandMethods.GeneticClasses;

namespace HollandMethods.StatisticClasses
{
	public class Logging
	{
		XDocument xdoc;
		XElement generation;
		XElement root;

		public string DocumentName { get; private set; }

		public string FolderPath { get; private set; }

		public string FolderName { get; private set; }

		public string SubFolderName { get; private set; }

		public string DocumentPath { get => $"{ FolderPath }\\{ FolderName }\\{ SubFolderName }"; }

		public string DocumentFullPath { get => $"{ FolderPath }\\{ FolderName }\\{ SubFolderName }\\{ DocumentName }"; }

		public Logging(string folderPath, string folderName, int id, StartGenerationTypeEnum startGenerationType, int[,] tasks)
		{
			FolderPath = folderPath;
			FolderName = folderName;
			SubFolderName = startGenerationType.ToString();

			DocumentName = $"{ id }.xml";

			var directoryInfo = new DirectoryInfo(folderPath);
			if (directoryInfo.Exists)
			{
				BuildRootCatalogStruct();

				var folderInfo = new DirectoryInfo($"{ FolderPath }\\{ FolderName }");

				if (folderInfo.Exists)
				{
					var ducFolderInfo = folderInfo.CreateSubdirectory(SubFolderName);
				}
			}

			xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null));
			root = new XElement("Root");

			generation = new XElement("Generations");

			XElement xtasks = new XElement("Tasks");
			XElement rows = new XElement("Rows");

			for (int i = 0; i < tasks.GetLength(0); i++)
			{
				XElement row = new XElement("Row");
				XElement col = new XElement("Cols");

				for (int j = 0; j < tasks.GetLength(1); j++)
				{
					col.Add(new XElement("Col", tasks[i, j]));
				}

				row.Add(col);
				rows.Add(row);
			}

			xtasks.Add(rows);
			root.Add(xtasks);

		}

		public void WriteGeneration(Generation gen)
		{
			XElement element = new XElement("Generation");
			XElement species = new XElement("Species");

			foreach (var specie in gen.Species)
			{
				XElement xspecie = new XElement("Specie");
				XElement genes = new XElement("Genes");

				foreach (var gene in specie.Genes)
				{
					genes.Add(new XElement("Gene",
						new XElement("Row", gene.Row),
						new XElement("Processor", gene.Processor),
						new XElement("ProcessingTime", gene.ProcessingTime)
						));
				}

				xspecie.Add(genes);
				xspecie.Add(new XElement("Fitness", specie.Fitness));
				xspecie.Add(new XElement("Adaptation", specie.Adaptation(gen.T)));

				species.Add(xspecie);
			}

			element.Add(species);
			generation.Add(element);
		}

		public void StopLogging()
		{
			root.Add(generation);
			xdoc.Add(root);
			xdoc.Save(DocumentFullPath);
		}

		private void BuildRootCatalogStruct()
		{
			try
			{
				if (!Directory.Exists($"{ FolderPath }\\{ FolderName }"))
				{
					Directory.CreateDirectory($"{ FolderPath }\\{ FolderName }");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
