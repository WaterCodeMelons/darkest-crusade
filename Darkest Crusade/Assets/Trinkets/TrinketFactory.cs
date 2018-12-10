using System;
using UnityEngine;
using Core;
using UniRx;
using Assets;
using System.Linq;
using System.Collections.Generic;

public class TrinketFactory : MonoBehaviour
{
    private TrinketStatsGenerator _trinketStatsGenerator;
    private Vector3 _spawnPosition;

    private void GenerateBaseStats(GameObject obj)
    {
        if (_trinketStatsGenerator == null)
        {
            _trinketStatsGenerator = new TrinketStatsGenerator();
            _spawnPosition = new Vector3(0, 0, 0);
        }

        var trinket = obj.GetComponent<Trinket>();

        trinket.TrinketClass.Value = _trinketStatsGenerator.GenerateClass();

        var buffDict = _trinketStatsGenerator.BuffGenerator(trinket.TrinketClass.Value);

        trinket.TrinketValue.Value = _trinketStatsGenerator.TrinketValueGenerator(trinket.TrinketClass.Value);
        trinket.AccuracyBuff.Value = buffDict[TrinketBuffEnum.Accuracy];
        trinket.CriticalChanceBuff.Value = buffDict[TrinketBuffEnum.CritChance];
        trinket.DamageBuff.Value = buffDict[TrinketBuffEnum.Damage];
        trinket.DodgeBuff.Value = buffDict[TrinketBuffEnum.Dodge];
        trinket.ProtectionBuff.Value = buffDict[TrinketBuffEnum.Protection];
        trinket.SpeedBuff.Value = buffDict[TrinketBuffEnum.Speed];

        var buffFromDict = buffDict.FirstOrDefault(x => x.Value != 0);

        var buff = new Buff()
        {
            BuffType = buffFromDict.Key,
            BuffValue = buffFromDict.Value
        };
        trinket.Buff = buff;

        
        var isEpic = trinket.TrinketClass.Value == TrinketClassEnum.Epic;

        if (!isEpic)
        {
            KeyValuePair<TrinketBuffEnum, int> debuffFromDict;
            do
            {
                var debuffDict = _trinketStatsGenerator.DebuffGenerator(trinket.TrinketClass.Value);

                trinket.AccuracyDebuff.Value = debuffDict[TrinketBuffEnum.Accuracy];
                trinket.CriticalChanceDebuff.Value = debuffDict[TrinketBuffEnum.CritChance];
                trinket.DamageDebuff.Value = debuffDict[TrinketBuffEnum.Damage];
                trinket.DodgeDebuff.Value = debuffDict[TrinketBuffEnum.Dodge];
                trinket.ProtectionDebuff.Value = debuffDict[TrinketBuffEnum.Protection];
                trinket.SpeedDebuff.Value = debuffDict[TrinketBuffEnum.Speed];

                debuffFromDict = debuffDict.FirstOrDefault(x => x.Value != 0);
            }
            while (buffFromDict.Key == debuffFromDict.Key);

            var debuff = new Buff()
            {
                BuffType = debuffFromDict.Key,
                BuffValue = debuffFromDict.Value
            };

            trinket.Debuff = debuff;
        }
    }

    public GameObject SpawnOnUI(GameObject obj, GameObject parent)
    {
        GenerateBaseStats(obj);
        Instantiate(obj, _spawnPosition, Quaternion.identity, parent.transform);
        return obj;
    }
}
