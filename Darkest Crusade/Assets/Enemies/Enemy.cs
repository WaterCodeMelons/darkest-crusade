using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

namespace Assets.Enemies
{
    public class Enemy: MonoBehaviour
    {
        public ReactiveProperty<string> Name = new ReactiveProperty<string>();
        public ReactiveProperty<EnemyTypeEnum> Type = new ReactiveProperty<EnemyTypeEnum>();
        public ReactiveProperty<int> Level = new ReactiveProperty<int>();
        public ReactiveProperty<float> HealthPoints = new ReactiveProperty<float>();
        public ReactiveProperty<float> ManaPoints = new ReactiveProperty<float>();
        public ReactiveProperty<float> Damage = new ReactiveProperty<float>();
        public ReactiveProperty<float> Dodge = new ReactiveProperty<float>();
        public ReactiveProperty<float> Speed = new ReactiveProperty<float>();
    }
}
