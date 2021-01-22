using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI score;

    private void LateUpdate()
    {
        score.text = GlobalVars.ScorePoints.ToString();
    }
}
