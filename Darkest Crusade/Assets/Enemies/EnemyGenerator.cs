using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Extensions;

namespace Assets.Enemies
{
    public class EnemyGenerator
    {
        private Random _random;

        public EnemyGenerator()
        {
            _random = new Random();
        }

        public void GenerateEnemy(Enemy enemy)
        {
            enemy.Name.Value = string.Concat(
                NamePrefix.PickRandom(), NamePostfix.PickRandom());

            enemy.Level.Value = (int) GetHeroes().Average(x => x.Level.Value) + _random.Next(-1,4);

            enemy.Type.Value = _random.RandomEnumValue<EnemyTypeEnum>();

            enemy.HealthPoints.Value = GetHeroes().Sum(x => x.HealthPoint.Value) *
                                       (_random.Next(7,17) / 100);

            enemy.ManaPoints.Value = GetHeroes().Sum(x => x.ManaPoint.Value);

            enemy.Damage.Value = (GetHeroes().Average(x => x.Damage.Value) / GetHeroes().Count) * 
                                 (1 + (enemy.Level.Value / 100));

            enemy.Dodge.Value = GetHeroes().Max(x => x.Dodge.Value) *
                                (1 + (enemy.Level.Value / 100));

            enemy.Speed.Value = GetHeroes().Min(x => x.Speed.Value) * GetHeroes().Count;
        }

        private List<Hero> GetHeroes()
        {
            var gameObjects = GameState.Instance.heroes;
            var heroes = new List<Hero>();

            foreach (var gameObject in gameObjects)
            {
                heroes.Add(gameObject.GetComponent<Hero>());
            }

            return heroes;
        }

        private readonly List<string> NamePrefix = new List<string>
        {
            "Spierre ",
            "De' ",
            "Gee Ser ",
            "Swoy ",
            "Won'",
            "Shine ",
            "Seba ",
            "Jan ",
            "Pio ",
            "Tsu",
            "Soul",
            "Rotflayer ",
            "The Broken ",
            "The Eternal ",
            "Ginekko",
            "The Grisly ",
            "Muted ",
            "Blue ",
            "Kamyl ",
            "David "
        };

        private readonly List<string> NamePostfix = new List<string>
        {
            "Lone",
            "Man",
            "Vampire",
            "Bonefang",
            "Gargoyle",
            "Oleg",
            "Howler",
            "Leviathan",
            "Lord",
            "Queen",
            "Monsta",
            "Beast",
            "Bear",
            "Wasp",
            "Eyes",
            "Abomination",
            "Hippo",
            "Cat",
            "Dragon",
            "Mutt"
        };
    }
}
