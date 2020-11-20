using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollandMethods.GeneticClasses
{
    public class Specie : IComparable
    {
        public Gene[] Genes { get; set; }
        public int[,] Tasks { get; private set; }

        public double Adaptation(int T)
        {
            double index = (double)Fitness / (double)T;
            return Math.Round(index, 2);
        }

        public Specie(int[,] tasks, bool isClear = false)
        {
            Tasks = tasks;
            int tasksCount = tasks.GetLength(0);
            Genes = new Gene[tasksCount];
            if (!isClear)
            {
                for (int i = 0; i < tasksCount; i++)
                {
                    Genes[i] = new Gene(tasks, i);
                }
            }
        }
        public Specie(Specie specie)
        {
            Tasks = specie.Tasks;
            int genesCount = specie.Genes.Length;
            Genes = new Gene[genesCount];
            for (int i = 0; i < genesCount; i++)
            {
                Genes[i] = new Gene(specie.Genes[i]);
            }
        }

        public int Fitness
        {
            get
            {
                List<int> load = new List<int>(new int[Tasks.GetLength(1)]);
                foreach (Gene gene in Genes)
                {
                    load[gene.Processor] += gene.ProcessingTime;
                }

                return load.Max();
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is Specie)
            {
                if (Fitness == ((Specie)obj).Fitness)
                {
                    return 0;
                }
                else if (Fitness < ((Specie)obj).Fitness)
                {
                    return -1;
                }
                else
                    return 1;
            }
            else
                throw new Exception("Попытка сравнения несравнимых типов!");

        }
    }
}