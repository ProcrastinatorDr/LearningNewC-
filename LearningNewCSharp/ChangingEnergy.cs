using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNewCSharp
{
    /// <summary>
    /// The class to change energy of character from different sources.
    /// The character is loaded at the beginning of game and doesn't die, so his main resources should be static.
    /// </summary>
    internal static class ChangingEnergy
    {
        public static void TestClass()
        {
            Energy = 0;
            Effect wellFed = new Effect()
            {
                EffectDelay = 3000,
                MessageText = "You are well fed. Good food for good health.",
                Name = "Well fed",
                EnergyChanging = 8
            };
            Effect unhealthyEnergized = new Effect()
            {
                EffectDelay = 7000,
                MessageText = "You are energized. Beware this energy will cost you.",
                Name = "Unhealthy energized",
                EnergyChanging = -20
            };
            Food healthyFood = new Food()
            {
                Energy = 5,
                Duration = 3000,
                Effect = wellFed
            };
            Food energyDrink = new Food()
            {
                Energy = 15,
                Duration = 1,
                Effect = unhealthyEnergized
            };
            //ChangeEnergy(healthyFood);
            ChangeEnergy(energyDrink);
        }
        public static double Energy { get; set; }
        private static void ChangeEnergy(Food food)
        {
            
            int timer = 0;
            int timerInterval = 1000;
            while(timer < food.Duration)
            {
                Energy += food.Energy;
                timer += timerInterval;
                Console.WriteLine("Energy = " + Energy);
                Thread.Sleep(1000);
            }
            if(food.Effect is not null)
            {
                while (timer < food.Effect.Value.EffectDelay)
                {
                    timer += timerInterval;
                    Thread.Sleep(1000);
                }
                Energy += food.Effect.Value.EnergyChanging;
                Console.WriteLine($"You felt effect: {food.Effect.Value.Name}. Energy = {Energy}");
            }
        }
    }
    internal struct Food
    {
        public double Energy { get; set; }
        public int Duration {  get; set; }
        public Effect? Effect { get; set; }
    }
    /// <summary>
    /// Buff or debuff after eating food.
    /// </summary>
    internal struct Effect
    {
        public string Name { get; set; }
        public string MessageText { get; set; }
        public int EffectDelay { get; set; }
        public double EnergyChanging { get; set; }
    }
}
