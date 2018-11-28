using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Core
{
  public class DungeonState
  {
    public int DungeonStart;
    public int DungeonEnd;
    public Color EnvLightColor;
    public List<Color> LightsColor;
    public ReactiveProperty<float> PlayerX;
  }
}
