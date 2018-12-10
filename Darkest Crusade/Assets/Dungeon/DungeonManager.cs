using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Core;

public class DungeonManager : MonoBehaviour {
  public int[] dungeonBounds = { 0, 450 };
  public int minDungeonlength = 50;
  public int maxDungeonLength = 300;
  public int startRockOffset = -13;
  public int endRockOffset = 8;
  public Transform StartRock;
  public Transform EndRock;
  public Light EnvLight;
  public List<Light> SceneLights;

  void Awake()
  {
    if (GameState.Instance.DungeonState == null) {
      DungeonScope scope = generateDungeonScope();
      GameState.Instance.DungeonState = new DungeonState()
      {
        DungeonScope = scope,
        EnvLight = generateEnvLight(),
        Lights = generateLights(),
        PlayerX = new ReactiveProperty<float>(scope.start + 1),
      };
    }

    Initialize();
  }

  DungeonScope generateDungeonScope()
  {
    int start = dungeonBounds[0],
        end   = dungeonBounds[1];

    do {
      start = Random.Range(dungeonBounds[0], dungeonBounds[1]);
      end = Random.Range(dungeonBounds[0], dungeonBounds[1]);
    } while(end - start < minDungeonlength || end - start > maxDungeonLength);

    return new DungeonScope(){ start = start, end = end };
  }

  DungeonLight generateEnvLight()
  {
    return new DungeonLight()
    {
      color = new Color(Random.value, Random.value, Random.value),
      intensity = Random.value,
    };
  }

  List<DungeonLight> generateLights()
  {
    List<DungeonLight> lights = new List<DungeonLight>();

    foreach (Light l in SceneLights)
    {
        lights.Add(new DungeonLight()
        {
          color = new Color(Random.value, Random.value, Random.value),
          intensity = Random.value,
        });
    }

    return lights;
  }

  void Initialize()
  {
    StartRock.position = new Vector3(
      GameState.Instance.DungeonState.DungeonScope.start + startRockOffset,
      StartRock.position.y,
      StartRock.position.z
    );

    EndRock.position = new Vector3(
      GameState.Instance.DungeonState.DungeonScope.end + endRockOffset,
      EndRock.position.y,
      EndRock.position.z
    );

    EnvLight.color = GameState.Instance.DungeonState.EnvLight.color;
    EnvLight.intensity = GameState.Instance.DungeonState.EnvLight.intensity;

    for(int i = 0; i < SceneLights.Count; i++)
    {
      SceneLights[i].color = GameState.Instance.DungeonState.Lights[i].color;
      SceneLights[i].intensity = GameState.Instance.DungeonState.Lights[i].intensity;
    }
  }
}
