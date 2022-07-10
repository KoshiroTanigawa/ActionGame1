using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _gravityScale = 1.5f;

    public float _speed = 20f;
    public float _jumpForce = 10f;

    float _maxPos = 6;
    float _minPos = 0;
    float _posZ;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();    //Rigidbody取得
        Physics.gravity *= _gravityScale;   //重力の大きさ変更
        _posZ = transform.position.z;

    }

    void Update()
    {
        Walk(); //等速移動

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        float inputVertical = Input.GetAxis("Vertical") * 3 * Time.deltaTime;

        if (_posZ < _maxPos && _posZ > _minPos)
        {
            _posZ +=  inputVertical;
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
