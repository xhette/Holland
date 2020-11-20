using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollandMethods.GeneticClasses
{
    public class Gene
    {
        private static readonly Random rng = new Random();
        public int[,] Tasks { get; private set; }
        public int Row { get; private set; }
        public int Processor { get; set; }
        public int ProcessingTime => Tasks[Row, Processor];

        public Gene(int[,] tasks, int row)
        {
            int procCount = tasks.GetLength(1);
            Tasks = tasks;
            Row = row;
            Processor = rng.Next(procCount);
        }
        public Gene(Gene gene)
        {
            Tasks = gene.Tasks;
            Row = gene.Row;
            Processor = gene.Processor;
        }
    }
}