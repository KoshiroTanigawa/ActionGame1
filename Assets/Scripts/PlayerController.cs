using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _gravityScale = 1.5f;

    public float _speed = 20f;
    public float _jumpForce = 10f;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Walk(); //等速移動

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    /// <summary>
    /// キャラクターの動きの処理
    /// </summary>
    public void Walk()
    {
        _rb.AddForce(_speed, 0, 0,ForceMode.Force);
    }

    /// <summary>
    /// ジャンプの処理
    /// </summary>
    public void Jump()
    {
        _rb.AddForce(0, _jumpForce, 0, ForceMode.Impulse);
    }
}
