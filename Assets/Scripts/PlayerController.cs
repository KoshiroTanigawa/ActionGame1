using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField][Header("速度")]
    [Tooltip("キャラクターの移動速度")]
    public float _speed = 20f;

    [SerializeField][Header("ジャンプ力")]
    [Tooltip("キャラクターのジャンプ力")]
    public float _jumpForce = 10f;

    [SerializeField]
    [Header("重力スケール")]
    [Tooltip("重力の倍率")]
    public float _gravityScale = 1.5f;

    public float[] _posZ = [0, 3, 6];

    bool _isOnGround;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();    //Rigidbody取得
        Physics.gravity *= _gravityScale;   //重力の大きさ変更
        _isOnGround = true;
    }

    void Update()
    {
        Walk(); //等速移動
        Jump(); //ジャンプ

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
        
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rb.AddForce(0, _jumpForce, 0, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            _isOnGround = true;
        }
    }
}
