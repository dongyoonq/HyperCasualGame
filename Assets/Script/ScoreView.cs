using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private TMP_Text tmp_text;

    private void Awake()
    {
        tmp_text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        GameManager.Data.OnCurrScoreChanged += ChangeScore;
    }

    private void OnDisable()
    {
        GameManager.Data.OnCurrScoreChanged -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        tmp_text.text = score.ToString();
    }
}
