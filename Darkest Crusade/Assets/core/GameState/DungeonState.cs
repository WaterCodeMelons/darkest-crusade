using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Core
{
  public class DungeonScope
  {
    public int start;
    public int end;
  }
  
  public class DungeonLight
  {
    public Color color;
    public float intensity;
  }

  public class DungeonState
  {
    public DungeonScope DungeonScope;
    public DungeonLight EnvLight;
    public List<DungeonLight> Lights;
    public ReactiveProperty<float> PlayerX;
  }
}
