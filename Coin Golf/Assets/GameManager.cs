using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int currentStrokes;
    public int maxStrokes;
    public int parStrokes;
    int stars;

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
        Instance().stars = 3;
        Instance().SaveData();
        gui.UpdateStars(3);
        gui.ShowWinPanel();
    }

    void SaveData()
    {
        string levelName = SceneManager.GetActiveScene().name;

        int bestScore = PlayerPrefs.GetInt(levelName + "-bestScore", 0);
        PlayerPrefs.SetInt(levelName + "-bestScore", Mathf.Min(bestScore, currentStrokes));

        int bestStars = PlayerPrefs.GetInt(levelName + "-bestStars", 0);
        PlayerPrefs.SetInt(levelName + "-bestStars", Mathf.Max(bestStars, stars));
    }

    void initGUI()
    {
        gui.SetLevelName(SceneManager.GetActiveScene().name);
        gui.SetPar(parStrokes);
        gui.SetMaxStrokes(maxStrokes);
        gui.SetCurrentStrokes(0);

        // Load high score data
        string levelName = SceneManager.GetActiveScene().name;
        gui.SetBestScore(PlayerPrefs.GetInt(levelName + "-bestScore", 0));
        gui.UpdateStars(PlayerPrefs.GetInt(levelName + "-bestStars", 0));
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
        string activeScene = SceneManager.GetActiveScene().name;
        LevelSet.getSet(activeScene).LoadNextScene(activeScene);
    }
}
