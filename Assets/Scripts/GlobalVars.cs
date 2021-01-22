using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    private static int score = 0;
    public static int ScorePoints
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
}
