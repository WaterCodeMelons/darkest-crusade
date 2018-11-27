using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {
  public int[] dungeonBounds = { 0, 450 };
  public int minDungeonlength = 50;
  public int maxDungeonLength = 300;
  
  private static Random rng = new Random();

  void Awake()
  {

  }
}
