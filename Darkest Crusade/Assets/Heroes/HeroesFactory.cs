using System.Collections.Generic;
using UnityEngine;
using Core;
using UniRx;

namespace Assets
{
    // TODO, fix positions
    public class HeroesFactory : MonoBehaviour
    {
        public GameObject Mage;
        public GameObject Warrior;
        public GameObject Rogue;
        public GameObject Cleric;
        private Vector3 _spawnPosition;

        private HeroStatsGenerator _heroStatsGenerator = new HeroStatsGenerator();

        public void Start()
        {   
            //Mocks below
            _spawnPosition = new Vector3(-6f, -2f, 0);

            GameState.Instance.teamHeroes = new ReactiveCollection<GameObject>(
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

            GameObject hero = Instantiate(obj, _spawnPosition, Quaternion.identity);
            hero.transform.parent = transform;

            ChangeSpawnPosition();

            return hero;
        }

        public GameObject SpawnOnUI(GameObject obj, GameObject parent, HeroStatusEnum status)
        {
            GenerateBaseStats(obj);
            SetStatus(obj, status);
            GameObject hero = Instantiate(obj, _spawnPosition, Quaternion.identity, parent.transform);
            return hero;
        }

        private void SetStatus(GameObject obj, HeroStatusEnum status) {
            obj.GetComponent<Hero>().HeroStatus.Value = status;
        }

        private void GenerateBaseStats(GameObject obj)
        {
            var hero = obj.GetComponent<Hero>();

            hero.Level.Value = 1;
            hero.HealthPoint.Value = 1;
            hero.ManaPoint.Value = 100;
            hero.HeroClass.Value = HeroClassEnum.Warrior;
            //hero.HeroClass.Value = _heroStatsGenerator.GenerateClass();
            hero.AccuracyModifier.Value = _heroStatsGenerator.GenerateAccuracyModifier(hero.HeroClass.Value);
            hero.CriticalChance.Value = _heroStatsGenerator.GenerateCriticalChance(hero.HeroClass.Value);
            hero.Damage.Value = _heroStatsGenerator.GenerateDamage(hero.HeroClass.Value);
            hero.Dodge.Value = _heroStatsGenerator.GenerateDodge(hero.HeroClass.Value);
            hero.Protection.Value = _heroStatsGenerator.GenerateProtection(hero.HeroClass.Value);
            hero.Speed.Value = _heroStatsGenerator.GenerateSpeed(hero.HeroClass.Value);
        }

        private void ChangeSpawnPosition()
        {
            _spawnPosition = new Vector3(_spawnPosition.x + 1.5f, _spawnPosition.y, _spawnPosition.z);
        }
    }
}
