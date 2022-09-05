using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    Transform _pos;
    Rigidbody _rb;

    [SerializeField] float _gravityScale = 1.5f;
    [SerializeField] float _speed = 20f;
    [SerializeField] float _jumpForce = 10f;

    int _indexZ = 0;
    float[] _posZ = { 0, 3, 6 };
    bool _isOnGround;

    float _maxHP;   //最大HP
    float _playerHP;    //現在のプレイヤーのHP
    public float PlayerHP{ get => _playerHP; set => _playerHP = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pos = GetComponent<Transform>();
        _pos.position = new Vector3(0, 0, _posZ[_indexZ]);
        Physics.gravity *= _gravityScale;
        _isOnGround = true;
        _maxHP = _playerHP;
    }

    void Update()
    {
        Walk(); //等速移動
        Jump(); //ジャンプ

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            if(_indexZ > 0 && _indexZ < 2)
            {
                _pos.position = new Vector3(0, 0, _posZ[_indexZ++]);
            }
        };
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
