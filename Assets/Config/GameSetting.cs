using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        InitValue();
        InitManager();
    }

    private static void InitValue()
    {
        Physics2D.gravity = new Vector2(0, -25f);
    }

    private static void InitManager()
    {
        if (GameManager.Instance == null)
        {
            GameObject gameObject = new GameObject() { name = "GameManager" };
            gameObject.AddComponent<GameManager>();
        }
    }
}
