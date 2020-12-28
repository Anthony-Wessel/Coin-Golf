using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] TextMeshProUGUI parText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    [SerializeField] Transform starHolder;

    int par;
    int maxStrokes;
    int currentStrokes;
    int activeStars = 0;

    public void SetLevelName(string name)
    {
        levelName.text = name;
    }
    
    public void SetMaxStrokes(int maxStrokes)
    {
        this.maxStrokes = maxStrokes;
        scoreText.text = "Strokes: " + currentStrokes + " / " + maxStrokes;
    }

    public void SetPar(int par)
    {
        this.par = par;
        parText.text = "Par: " + par;
    }

    public void SetCurrentStrokes(int currentStrokes)
    {
        this.currentStrokes = currentStrokes;
        scoreText.text = "Strokes: " + currentStrokes + " / " + maxStrokes;
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        winPanel.SetActive(true);
    }

    public void UpdateStars(int numStars)
    {
        numStars = Mathf.Min(numStars, 3);
        if (numStars > activeStars)
            StartCoroutine(growStars(numStars));
    }

    IEnumerator growStars(int numStars)
    {
        for (int i = activeStars; i < numStars; i++)
        {
            starHolder.GetChild(i).GetComponent<Animator>().SetTrigger("grow");
            yield return new WaitForSeconds(0.1f);
        }
        activeStars = numStars;
    }

    public void SetBestScore(int strokes)
    {
        bestScoreText.text = "Best Score: " + strokes;
    }
}
