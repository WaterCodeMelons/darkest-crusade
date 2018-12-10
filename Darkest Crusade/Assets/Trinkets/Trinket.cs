using Assets;
using UniRx;
using UnityEngine;

public class Trinket : MonoBehaviour {

    public ReactiveProperty<TrinketClassEnum> TrinketClass = new ReactiveProperty<TrinketClassEnum>();
    public ReactiveProperty<int> TrinketValue = new ReactiveProperty<int>();

    public Buff Buff;
    public Buff Debuff;

    //Trinket buffs stats

    public ReactiveProperty<float> AccuracyBuff       = new ReactiveProperty<float>();
    public ReactiveProperty<float> CriticalChanceBuff = new ReactiveProperty<float>();
    public ReactiveProperty<float> DamageBuff         = new ReactiveProperty<float>();
    public ReactiveProperty<float> DodgeBuff          = new ReactiveProperty<float>();
    public ReactiveProperty<float> ProtectionBuff     = new ReactiveProperty<float>();
    public ReactiveProperty<float> SpeedBuff          = new ReactiveProperty<float>();

    //Trinket debuffs stats

    public ReactiveProperty<float> AccuracyDebuff       = new ReactiveProperty<float>();
    public ReactiveProperty<float> CriticalChanceDebuff = new ReactiveProperty<float>();
    public ReactiveProperty<float> DamageDebuff         = new ReactiveProperty<float>();
    public ReactiveProperty<float> DodgeDebuff          = new ReactiveProperty<float>();
    public ReactiveProperty<float> ProtectionDebuff     = new ReactiveProperty<float>();
    public ReactiveProperty<float> SpeedDebuff          = new ReactiveProperty<float>();
}
