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
    public UnityEvent OnScored;
    public UnityEvent OnJumped;

    private Rigidbody2D playerRb;
    private Vector2 StartPos;

    public float jumpPower;

    private void Awake()
    {
        StartPos = transform.position;
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void SetPlayerPos()
    {
        transform.position = StartPos;
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
        OnJumped?.Invoke();
    }

    private void Rotate()
    {
        transform.right = playerRb.velocity + Vector2.right * 1.9f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDied?.Invoke();
        StartCoroutine(activeDisable());
    }

    IEnumerator activeDisable()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Data.CurrScore++;
        OnScored?.Invoke();
    }
}