using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

using WebApp.XmlModels;

namespace WebApp.Classes
{
	public static class FilesMethods
	{
		public static void FromXml(string rootPath)
		{

			XmlSerializer formatter = new XmlSerializer(typeof(Root));
			using (FileStream fs = new FileStream(string.Format(rootPath + "\\6b2b8a13-86ed-4f4b-8777-5e013e04c4a8\\CriticalWay\\0.xml"), FileMode.Open))
			{
				Root newPerson = (Root)formatter.Deserialize(fs);
			}
		}

		/// <summary>
		/// Получить путь к корню каталога
		/// </summary>
		/// <returns>Путь к корню каталога</returns>
		public static string GetRootFilePath()
		{
			string rootFilepath;

			try
			{
				rootFilepath = @"D:\stud\KobakKurs";

				if (string.IsNullOrWhiteSpace(rootFilepath))
				{
					rootFilepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return rootFilepath;
		}
	}
}
