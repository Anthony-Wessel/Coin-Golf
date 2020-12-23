using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] TextMeshProUGUI parText;
    [SerializeField] TextMeshProUGUI scoreText;

    int par;
    int maxStrokes;
    int currentStrokes;

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
}
