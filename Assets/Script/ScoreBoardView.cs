using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardView : MonoBehaviour
{
    [SerializeField] private TMP_Text currText;
    [SerializeField] private TMP_Text bestText;

    private void OnEnable()
    {
        currText.text = GameManager.Data.CurrScore.ToString();
        bestText.text = GameManager.Data.BestScore.ToString();
    }
}