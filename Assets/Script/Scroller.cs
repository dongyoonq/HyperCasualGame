using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Transform[] childs;
    [SerializeField] private float scrollSpeed;

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].Translate(Vector2.left * scrollSpeed * Time.deltaTime, Space.World);
            if (childs[i].position.x < endPoint.position.x)
            {
                childs[i].position = startPoint.position;
            }
        }
    }
}
