using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class EditorCheats : MonoBehaviour
{
    [MenuItem("Cheats/Reload Current Scene")]
    public static void ReloadCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log(scene.name + " has reloaded");
    }
}
