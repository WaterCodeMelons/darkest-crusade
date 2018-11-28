using System;
using Core.Extensions;

namespace Assets
{
    public class HeroStatsGenerator
    {
        private Random _random;

        public HeroStatsGenerator()
        {
            _random = new Random();
        }

        public HeroClassEnum GenerateClass()
        {
            return _random.RandomEnumValue<HeroClassEnum>();
        }

        public float GenerateAccuracyModifier(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float) _random.Next(70, 90);
                case HeroClassEnum.Warrior:
                    return (float) _random.Next(60, 80);
                case HeroClassEnum.Rogue:
                    return (float) _random.Next(50, 70);
                case HeroClassEnum.Cleric:
                    return (float) _random.Next(70, 80);
                default:
                    return 0;
            }
        }

        public float GenerateCriticalChance(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float) _random.Next(15, 30);
                case HeroClassEnum.Warrior:
                    return (float) _random.Next(35, 50);
                case HeroClassEnum.Rogue:
                    return (float) _random.Next(40, 60);
                case HeroClassEnum.Cleric:
                    return (float) _random.Next(5, 15);
                default:
                    return 0;
            }
        }

        public float GenerateValue(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float) _random.Next(100, 200);
                case HeroClassEnum.Warrior:
                    return (float) _random.Next(200, 400);
                case HeroClassEnum.Rogue:
                    return (float) _random.Next(100, 200);
                case HeroClassEnum.Cleric:
                    return (float) _random.Next(200, 400);
                default:
                    return 0;
            }
        }

        public float GenerateDamage(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float) _random.Next(6, 10);
                case HeroClassEnum.Warrior:
                    return (float) _random.Next(4, 7);
                case HeroClassEnum.Rogue:
                    return (float) _random.Next(6, 9);
                case HeroClassEnum.Cleric:
                    return (float) _random.Next(2, 4);
                default:
                    return 0;
            }
        }

        public float GenerateDodge(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float)_random.Next(1, 3);
                case HeroClassEnum.Warrior:
                    return (float)_random.Next(4, 8);
                case HeroClassEnum.Rogue:
                    return (float)_random.Next(6, 10);
                case HeroClassEnum.Cleric:
                    return (float)_random.Next(1, 3);
                default:
                    return 0;
            }
        }

        public float GenerateProtection(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float)_random.Next(4, 6);
                case HeroClassEnum.Warrior:
                    return (float)_random.Next(6, 10);
                case HeroClassEnum.Rogue:
                    return (float)_random.Next(4, 7);
                case HeroClassEnum.Cleric:
                    return (float)_random.Next(4, 6);
                default:
                    return 0;
            }
        }

        public float GenerateSpeed(HeroClassEnum heroHeroClass)
        {
            switch (heroHeroClass)
            {
                case HeroClassEnum.Mage:
                    return (float)_random.Next(2, 4);
                case HeroClassEnum.Warrior:
                    return (float)_random.Next(1, 3);
                case HeroClassEnum.Rogue:
                    return (float)_random.Next(3, 5);
                case HeroClassEnum.Cleric:
                    return (float)_random.Next(2, 4);
                default:
                    return 0;
            }
        }


    }
}