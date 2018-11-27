using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Core
{
  public class GameState : Singleton<GameState>
  {
    public List<GameObject> heroes;
  }

}
