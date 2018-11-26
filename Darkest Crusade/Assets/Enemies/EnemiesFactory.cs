using System.Collections.Generic;
using Assets.Enemies;
using Core;
using Core.Extensions;
using UnityEngine;

public class EnemiesFactory : MonoBehaviour
{
    public List<GameObject> MonsterPrefabs;

    private EnemyGenerator _enemyGenerator;
    private Vector3 _spawnPosition;

    public void Start()
    {
        _enemyGenerator = new EnemyGenerator();
        _spawnPosition = new Vector3(0,0,0);
    }

    public void CreateEnemy()
    {
        var monster = MonsterPrefabs
            .PickRandom();

        _enemyGenerator.GenerateEnemy(
            monster.GetComponent<Enemy>());

        var hero = Instantiate(monster, _spawnPosition, Quaternion.identity);
        hero.transform.parent = transform;
    }
}