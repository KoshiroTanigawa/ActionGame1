using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _gravityScale = 1.5f;

    [SerializeField] float _speed = 20f;
    [SerializeField] float _jumpForce = 10f;

    float _maxPos = 6;
    float _minPos = 0;
    float _posZ;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();    //RigidbodyéÊìæ
        Physics.gravity *= _gravityScale;   //èdóÕÇÃëÂÇ´Ç≥ïœçX
        _posZ = transform.position.z;

    }

    void Update()
    {
        _rb.AddForce(_speed, 0, 0, ForceMode.Force);//ìôë¨à⁄ìÆ

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(0, _jumpForce, 0, ForceMode.Impulse);
        }

        float inputVertical = Input.GetAxis("Vertical") * 3;
        if (_posZ < _maxPos && _posZ > _minPos)
        {
            _posZ +=  inputVertical;
        }
    }
}
