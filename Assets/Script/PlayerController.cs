using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public UnityEvent OnDied;
    private Rigidbody2D playerRb;

    public float jumpPower;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void OnJump(InputValue inputvalue)
    {
        Jump();
    }

    private void Jump()
    {
        playerRb.velocity = Vector2.up * jumpPower;
    }

    private void Rotate()
    {
        transform.right = playerRb.velocity + Vector2.right * 1.9f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDied?.Invoke();
    }
}