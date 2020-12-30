using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentStrokes { get; private set; }

    GUIManager gui;

    static GameManager instance;

    bool ended = false;

    public LevelData levelData;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private void Awake()
    {
        gui = FindObjectOfType<GUIManager>();
        initGUI();
    }

    public void AddStroke()
    {
        currentStrokes++;
        updateScore();
    }

    public bool OutOfStrokes()
    {
        return currentStrokes >= levelData.par * 2;
    }

    public void Lose()
    {
        if (ended) return;

        gui.ShowLosePanel();
        ended = true;
    }

    public void Win()
    {
        if (ended) return;

        SaveData();

        gui.SetBestScore(Mathf.Min(currentStrokes, levelData.bestScore));
        gui.UpdateStars(calculateStars(currentStrokes, levelData.par));
        gui.ShowWinPanel();

        ended = true;
    }

    void SaveData()
    {
        levelData.bestScore = Mathf.Min(levelData.bestScore, currentStrokes);
    }

    void initGUI()
    {
        gui.SetLevelName(SceneManager.GetActiveScene().name);
        gui.SetPar(levelData.par);
        gui.SetMaxStrokes(levelData.par*2);
        gui.SetCurrentStrokes(0);

        // Load high score data
        gui.SetBestScore(levelData.bestScore);
        gui.UpdateStars(calculateStars(levelData.bestScore, levelData.par));
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

    int calculateStars(int score, int par)
    {
        int stars;
        if (score <= par)
            stars = 3;
        else if (score <= par * 1.5f)
            stars = 2;
        else if (score <= par * 2)
            stars = 1;
        else
            stars = 0;

        return stars;
    }

    public void WipeBestScore()
    {
        levelData.bestScore = 100;
    }
}
