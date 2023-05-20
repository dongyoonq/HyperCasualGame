using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    public event UnityAction<int> OnBestScoreChanged;
    public event UnityAction<int> OnCurrScoreChanged;

    private int bestScore;
    private int currScore;

    public int BestScore
    {
        get { return bestScore; }
        set
        {
            if (bestScore != value)
                OnBestScoreChanged?.Invoke(value);
            bestScore = value;
        }
    }

    public int CurrScore
    {
        get { return currScore; }
        set
        {
            OnCurrScoreChanged?.Invoke(value);
            currScore = value;

            if (currScore > BestScore)
                BestScore = currScore;
        }
    }
}
