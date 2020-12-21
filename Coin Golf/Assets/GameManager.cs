using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int currentStrokes;
    public int maxStrokes;
    public int parStrokes;

    static GameManager instance;
    public static GameManager Instance()
    {
        if (instance == null)
            instance = FindObjectOfType<GameManager>();
        
        return instance; 
    }

    public static void AddStroke()
    {
        Instance().currentStrokes++;
    }

    public static void Lose()
    {
        print("You lost!");
    }

    public static void Win()
    {
        print("You win!");
    }
}
