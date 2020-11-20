using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollandMethods.GeneticClasses
{
    public class Generation
    {
        public static Random rng = new Random();
        public List<Specie> Species { get; private set; } = new List<Specie>();
        public int[,] Tasks { get; private set; }
        public int T { get; private set; }

        public Generation(int[,] tasks, int speciesCount)
        {
            Tasks = tasks;
            for (int i = 0; i < speciesCount; i++)
            {
                Species.Add(new Specie(tasks));
            }

            T = Species.Sum(c => c.Fitness);
        }
        public Generation(Generation gen)
        {
            for (int i = 0; i < gen.Species.Count; i++)
            {
                Species.Add(new Specie(gen.Species[i]));
            }
        }

        Specie[] SpeciesForCrossover()
        {
            Specie[] species = Species.OrderBy(c => c.Adaptation(T)).Take(2).ToArray();

            return species;
        }

        Specie SpecieForExchange()
        {
            Specie specie = Species.OrderByDescending(c => c.Adaptation(T)).FirstOrDefault();

            return specie;
        }

        Specie Crossover()
        {
            Specie[] parents = SpeciesForCrossover();

            Specie parent1 = parents[0];
            Specie parent2 = parents[1];
            int crossoverPoint = rng.Next(1, Tasks.GetLength(0));
            Specie child1 = new Specie(Tasks, isClear: true);
            Specie child2 = new Specie(Tasks, isClear: true);
            for (int i = 0; i < Tasks.GetLength(0); i++)
            {
                if (i < crossoverPoint)
                {
                    child1.Genes[i] = new Gene(parent1.Genes[i]);
                    child2.Genes[i] = new Gene(parent2.Genes[i]);
                }
                else
                {
                    child1.Genes[i] = new Gene(parent2.Genes[i]);
                    child2.Genes[i] = new Gene(parent1.Genes[i]);
                }
            }

            if (rng.NextDouble() < 0.5)
                return child1;
            else
                return child2;
        }

        public void SpecieExchange()
        {
            Specie toExchange = SpecieForExchange();
            Specie newGeneration = Crossover();

            int indexExchange = Species.IndexOf(toExchange);
            Species[indexExchange] = new Specie(newGeneration);
        }
    }
}