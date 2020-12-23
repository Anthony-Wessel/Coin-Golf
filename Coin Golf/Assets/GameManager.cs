using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int currentStrokes;
    public int maxStrokes;
    public int parStrokes;

    static GUIManager gui;

    static GameManager instance;
    public static GameManager Instance()
    {
        if (instance == null)
            instance = FindObjectOfType<GameManager>();
        
        return instance; 
    }

    private void Awake()
    {
        gui = FindObjectOfType<GUIManager>();
        initGUI();
    }

    public static void AddStroke()
    {
        Instance().currentStrokes++;
        Instance().updateScore();
    }

    public static void Lose()
    {
        print("You lost!");
    }

    public static void Win()
    {
        gui.ShowWinPanel();
    }

    void initGUI()
    {
        gui.SetLevelName(SceneManager.GetActiveScene().name);
        gui.SetPar(parStrokes);
        gui.SetMaxStrokes(maxStrokes);
        gui.SetCurrentStrokes(0);
    }

    void updateScore()
    {
        gui.SetCurrentStrokes(currentStrokes);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        LevelSet.getSet(SceneManager.GetActiveScene().name).LoadNextScene(SceneManager.GetActiveScene().name);
    }
}
