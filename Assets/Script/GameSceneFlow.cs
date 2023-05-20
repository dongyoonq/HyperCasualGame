using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneFlow : MonoBehaviour
{
    [SerializeField] private State currState;

    public UnityEvent OnReadyed;
    public UnityEvent OnPlayed;
    public UnityEvent OnGameOvered;

    private void Start()
    {
        Ready();
    }

    public enum State
    {
        Ready,
        Play,
        GameOver,
    }

    public void Ready()
    {
        currState = State.Ready;
        OnReadyed?.Invoke();
        GameManager.Data.CurrScore = 0;
    }

    public void Play()
    {
        currState = State.Play;
        OnPlayed?.Invoke();
    }

    public void GameOver()
    {
        currState = State.GameOver;
        OnGameOvered?.Invoke();
    }
}
