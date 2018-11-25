using UnityEngine;
using System.Collections;

namespace Core
{
  public class Loader : Singleton<Loader>
  {
    protected Loader() { }

    void Awake()
    {
      initGameState();
    }

    void initGameState() { }
  }
}
