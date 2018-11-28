using Assets;
using UniRx;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public ReactiveProperty<HeroClassEnum> HeroClass = new ReactiveProperty<HeroClassEnum>();
    public ReactiveProperty<HeroStatusEnum> HeroStatus = new ReactiveProperty<HeroStatusEnum>();
    public ReactiveProperty<float> HeroValue = new ReactiveProperty<float>();
    public ReactiveProperty<float> HealthPoint = new ReactiveProperty<float>();
    public ReactiveProperty<float> ManaPoint = new ReactiveProperty<float>();
    public ReactiveProperty<int> Level = new ReactiveProperty<int>();
    public ReactiveProperty<float> AccuracyModifier = new ReactiveProperty<float>();
    public ReactiveProperty<float> CriticalChance = new ReactiveProperty<float>();
    public ReactiveProperty<float> Damage = new ReactiveProperty<float>();
    public ReactiveProperty<float> Dodge = new ReactiveProperty<float>();
    public ReactiveProperty<float> Protection = new ReactiveProperty<float>();
    public ReactiveProperty<float> Speed = new ReactiveProperty<float>();
}