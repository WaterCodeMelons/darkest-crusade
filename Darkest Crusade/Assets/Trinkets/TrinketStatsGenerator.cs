using System;
using System.Collections.Generic;

namespace Assets
{
    public class TrinketStatsGenerator
    {
        private readonly Random _random;
        private int _probability;

        public TrinketStatsGenerator()
        {
            _random = new Random();
        }

        public TrinketClassEnum GenerateClass()
        {
            _probability = _random.Next(0, 100);

            if (_probability < 75)
            {
                return TrinketClassEnum.Common;
            }
            else if (_probability >= 75 && _probability < 94)
            {
                return TrinketClassEnum.Rare;
            }
            else
            {
                return TrinketClassEnum.Epic;
            }                    
        }

        public int TrinketValueGenerator(TrinketClassEnum trinketClass)
        {
            int value=0;
            switch (trinketClass)
            {
                case TrinketClassEnum.Common:
                    value = _random.Next(50, 121);
                    break;
                case TrinketClassEnum.Rare:
                    value = _random.Next(200, 301);
                    break;
                case TrinketClassEnum.Epic:
                    value = _random.Next(350, 501);
                    break;
            }
            return value;
        }

        public Dictionary<TrinketBuffEnum,int> StatsRandomizer(Dictionary<TrinketBuffEnum, int> statsDictionary, int minValue, int maxValue)
        {
            var array = Enum.GetValues(typeof(TrinketBuffEnum));

            for (int i = 0; i < array.Length; i++)
            {
                statsDictionary.Add((TrinketBuffEnum) array.GetValue(i),
                    i == _probability ? _random.Next(minValue, maxValue) : 0);
            }
            return statsDictionary;
        }

        public Dictionary<TrinketBuffEnum,int> BuffGenerator(TrinketClassEnum trinketClass)
        {
            var statsDictionary = new Dictionary<TrinketBuffEnum, int>();

            _probability = _random.Next(0, 5);

            switch (trinketClass)
            {
                case TrinketClassEnum.Common:
                    StatsRandomizer(statsDictionary, 1, 6);
                    break;
            
                case TrinketClassEnum.Rare:
                    StatsRandomizer(statsDictionary, 6, 11);
                    break;

                case TrinketClassEnum.Epic:
                    StatsRandomizer(statsDictionary, 10, 16);
                    break;
            }

            return statsDictionary;
        }

        public Dictionary<TrinketBuffEnum, int> DebuffGenerator(TrinketClassEnum trinketClass)
        {
            var statsDictionary = new Dictionary<TrinketBuffEnum, int>();
           
            _probability = _random.Next(0, 5);

            switch (trinketClass)
            {
                case TrinketClassEnum.Common:
                    StatsRandomizer(statsDictionary, -6, -2);
                    break;

                case TrinketClassEnum.Rare:
                    StatsRandomizer(statsDictionary, -3, 0);
                    break;

                case TrinketClassEnum.Epic:
                    break;
            }

            return statsDictionary;
        }
    }
}