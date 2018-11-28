using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Core
{
  public class GameState : Singleton<GameState>
  {
    public ReactiveProperty<int> gold;
    public ReactiveCollection<GameObject> campHeroes;
    public ReactiveCollection<GameObject> churchHeroes;
    public ReactiveCollection<GameObject> tavernHeroes = new ReactiveCollection<GameObject>();
    public ReactiveCollection<GameObject> teamHeroes;
  }

}
