using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Assets
{
    // TODO, fix positions
    public class HeroesFactory : MonoBehaviour
    {
        public GameObject Mage;
        public GameObject Warrior;
        public GameObject Rogue;
        public GameObject Cleric;
        private Vector3 spawnPosition;

        private StatsGenerator _statsGenerator;

        public void Start()
        {
            _statsGenerator = new StatsGenerator();

            //Mocks below
            spawnPosition = new Vector3(-6f, -2f, 0);

            GameState.Instance.heroes = new List<GameObject>(
              new GameObject[] {
                CreateMage(),
                CreateWarrior(),
                CreateRogue(),
                CreateCleric()
              }
            );
        }


        public GameObject CreateMage()
        {
            return Spawn(Mage);
        }

        public GameObject CreateWarrior()
        {
            return Spawn(Warrior);
        }

        public GameObject CreateRogue()
        {
            return Spawn(Rogue);
        }

        public GameObject CreateCleric()
        {
            return Spawn(Cleric);
        }

        private GameObject Spawn(GameObject obj)
        {
            GenerateBaseStats(obj);

            GameObject hero = Instantiate(obj, spawnPosition, Quaternion.identity);
            hero.transform.parent = transform;

            ChangeSpawnPosition();

            return hero;
        }

        private void GenerateBaseStats(GameObject obj)
        {
            var hero = obj.GetComponent<Hero>();

            hero.Level = 1;
            hero.AccuracyModifier = _statsGenerator.GenerateAccuracyModifier(hero.HeroClass);
            hero.CriticalChance = _statsGenerator.GenerateCriticalChance(hero.HeroClass);
            hero.Damage = _statsGenerator.GenerateDamage(hero.HeroClass);
            hero.Dodge = _statsGenerator.GenerateDodge(hero.HeroClass);
            hero.Protection = _statsGenerator.GenerateProtection(hero.HeroClass);
            hero.Speed = _statsGenerator.GenerateSpeed(hero.HeroClass);
        }

        private void ChangeSpawnPosition()
        {
            spawnPosition = new Vector3(spawnPosition.x + 1.5f, spawnPosition.y, spawnPosition.z);
        }
    }
}
