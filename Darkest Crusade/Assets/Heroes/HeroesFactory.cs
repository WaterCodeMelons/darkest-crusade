using UnityEngine;

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

            CreateMage();
            CreateWarrior();
            CreateRogue();
            CreateCleric();
        }


        public void CreateMage()
        {
            Spawn(Mage);
        }

        public void CreateWarrior()
        {
            Spawn(Warrior);
        }

        public void CreateRogue()
        {
            Spawn(Rogue);
        }

        public void CreateCleric()
        {
            Spawn(Cleric);
        }

        private void Spawn(GameObject obj)
        {
            GenerateBaseStats(obj);

            Instantiate(obj, spawnPosition, Quaternion.identity).transform.parent = transform;

            ChangeSpawnPosition();
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
