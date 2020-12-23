using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName ="Level Set")]
public class LevelSet : ScriptableObject
{
    [SerializeField] string[] scenes;
    
    public void LoadNextScene(string currentSceneName)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i].Equals(currentSceneName))
            {
                if (i + 1 == scenes.Length)
                    SceneManager.LoadScene("Main Menu");
                else
                    SceneManager.LoadScene(scenes[i+1]);

                return;
            }
        }
        
    }

    public bool Contains(string sceneName)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i].Equals(sceneName))
            {
                return true;
            }
        }

        return false;
    }

    public static LevelSet getSet(string sceneName)
    {
        LevelSet[] sets = Resources.FindObjectsOfTypeAll<LevelSet>();
        for (int i = 0; i < sets.Length; i++)
        {
            if (sets[i].Contains(sceneName))
                return sets[i];
        }

        return null;
    }
}
