using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int Par;
    public int par { get { return Par; } }
    public int bestScore;
}