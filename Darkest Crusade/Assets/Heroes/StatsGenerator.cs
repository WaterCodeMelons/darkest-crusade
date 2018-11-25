using System;

namespace Assets
{
    public class StatsGenerator
    {
        private Random _random;

        public StatsGenerator()
        {
            _random = new Random();
        }

        public float GenerateAccuracyModifier(ClassEnum heroClass)
        {
            switch (heroClass)
            {
                case ClassEnum.Mage:
                    return (float) _random.Next(70, 90);
                case ClassEnum.Warrior:
                    return (float) _random.Next(60, 80);
                case ClassEnum.Rouge:
                    return (float) _random.Next(50, 70);
                case ClassEnum.Cleric:
                    return (float) _random.Next(70, 80);
                default:
                    return 0;
            }
        }

        public float GenerateCriticalChance(ClassEnum heroClass)
        {
            switch (heroClass)
            {
                case ClassEnum.Mage:
                    return (float) _random.Next(15, 30);
                case ClassEnum.Warrior:
                    return (float) _random.Next(35, 50);
                case ClassEnum.Rouge:
                    return (float) _random.Next(40, 60);
                case ClassEnum.Cleric:
                    return (float) _random.Next(5, 15);
                default:
                    return 0;
            }
        }

        public float GenerateDamage(ClassEnum heroClass)
        {
            switch (heroClass)
            {
                case ClassEnum.Mage:
                    return (float) _random.Next(6, 10);
                case ClassEnum.Warrior:
                    return (float) _random.Next(4, 7);
                case ClassEnum.Rouge:
                    return (float) _random.Next(6, 9);
                case ClassEnum.Cleric:
                    return (float) _random.Next(2, 4);
                default:
                    return 0;
            }
        }

        public float GenerateDodge(ClassEnum heroClass)
        {
            switch (heroClass)
            {
                case ClassEnum.Mage:
                    return (float)_random.Next(1, 3);
                case ClassEnum.Warrior:
                    return (float)_random.Next(4, 8);
                case ClassEnum.Rouge:
                    return (float)_random.Next(6, 10);
                case ClassEnum.Cleric:
                    return (float)_random.Next(1, 3);
                default:
                    return 0;
            }
        }

        public float GenerateProtection(ClassEnum heroClass)
        {
            switch (heroClass)
            {
                case ClassEnum.Mage:
                    return (float)_random.Next(4, 6);
                case ClassEnum.Warrior:
                    return (float)_random.Next(6, 10);
                case ClassEnum.Rouge:
                    return (float)_random.Next(4, 7);
                case ClassEnum.Cleric:
                    return (float)_random.Next(4, 6);
                default:
                    return 0;
            }
        }

        public float GenerateSpeed(ClassEnum heroClass)
        {
            switch (heroClass)
            {
                case ClassEnum.Mage:
                    return (float)_random.Next(2, 4);
                case ClassEnum.Warrior:
                    return (float)_random.Next(1, 3);
                case ClassEnum.Rouge:
                    return (float)_random.Next(3, 5);
                case ClassEnum.Cleric:
                    return (float)_random.Next(2, 4);
                default:
                    return 0;
            }
        }


    }
}