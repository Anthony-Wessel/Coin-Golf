using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject LevelSelectPanel;

    public void LoadMainMenu()
    {
        LevelSelectPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void LoadLevelSelect()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }
}
