using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Core;

public class DungeonManager : MonoBehaviour {
  public int[] dungeonBounds = { 0, 450 };
  public int minDungeonlength = 50;
  public int maxDungeonLength = 300;
  public Transform StartRock;
  public Transform EndRock;
  public Light EnvLight;
  public List<Light> SceneLights;

  void Awake()
  {
    if (GameState.Instance.DungeonState == null) {
      int start = dungeonBounds[0],
          end   = dungeonBounds[1];

      do {
        start = Random.Range(dungeonBounds[0], dungeonBounds[1]);
        end = Random.Range(dungeonBounds[0], dungeonBounds[1]);
      } while(end - start < minDungeonlength || end - start > maxDungeonLength);

      List<Color> colors = new List<Color>();

      foreach (Light l in SceneLights)
      {
          Color color = new Color(Random.value, Random.value, Random.value);
          colors.Add(color);
      }

      GameState.Instance.DungeonState = new DungeonState()
      {
        DungeonStart = start,
        DungeonEnd = end,
        EnvLightColor = new Color(Random.value, Random.value, Random.value),
        LightsColor = colors,
        PlayerX = new ReactiveProperty<float>(start),
      };
    }
    StartRock.position = new Vector3(GameState.Instance.DungeonState.DungeonStart - 13, StartRock.position.y, StartRock.position.z);
    EndRock.position = new Vector3(GameState.Instance.DungeonState.DungeonEnd + 8, EndRock.position.y, EndRock.position.z);
    EnvLight.color = GameState.Instance.DungeonState.EnvLightColor;
    for(int i = 0; i < SceneLights.Count; i++)
    {
      SceneLights[i].color = GameState.Instance.DungeonState.LightsColor[i];
      SceneLights[i].intensity = Random.Range(1f, 5f);
    }
  }
}
