using System;
using UnityEditor;
using UnityEngine;

public class ReplaceMaterials : EditorWindow
{
  UnityEngine.Material material;

  // Add menu item named "My Window" to the Window menu
  [MenuItem("Window/Replace Materials")]
  public static void ShowWindow()
  {
    //Show existing window instance. If one doesn't exist, make one.
    EditorWindow.GetWindow(typeof(ReplaceMaterials));
  }

  void OnGUI()
  {
    GUILayout.Label("Replace materials of all sprites", EditorStyles.boldLabel);
    material = (Material)EditorGUILayout.ObjectField("Material", material, typeof(Material), true);

    if (GUILayout.Button("Replace"))
    {
      foreach (SpriteRenderer item in GameObject.FindObjectsOfType<SpriteRenderer>())
      {
        item.material = material;
      }
    }
  }
}
