using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {
  public int[] dungeonBounds = { 0, 450 };
  public int minDungeonlength = 50;
  public int maxDungeonLength = 300;
  public Material _material;


  
  private static Random rng = new Random();

  void Awake()
  {

  }

  void Start()
  {
    foreach (SpriteRenderer item in GameObject.FindObjectsOfType(typeof(SpriteRenderer)))
    {
      item.material = _material;
    }
  }

  void Update()
  {
  }
}
