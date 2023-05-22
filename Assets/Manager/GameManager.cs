using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static DataManager data;

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data { get { return data; } } 

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        InitManager();
    }

    public void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void InitManager()
    {
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        data = gameObject.AddComponent<DataManager>();
    }
}
