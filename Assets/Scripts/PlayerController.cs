using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] float _gravityScale = 1.5f;

    [SerializeField] float _speed = 20f;
    [SerializeField] float _jumpForce = 10f;
=======
    [SerializeField][Header("���x")]
    [Tooltip("�L�����N�^�[�̈ړ����x")]
    public float _speed = 20f;

    [SerializeField][Header("�W�����v��")]
    [Tooltip("�L�����N�^�[�̃W�����v��")]
    public float _jumpForce = 10f;
>>>>>>> 6ce10e6ca0de20e230447535169f8233a64e418a

    [SerializeField]
    [Header("�d�̓X�P�[��")]
    [Tooltip("�d�͂̔{��")]
    public float _gravityScale = 1.5f;

    public float[] _posZ = [0, 3, 6];

    bool _isOnGround;

    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();    //Rigidbody�擾
        Physics.gravity *= _gravityScale;   //�d�͂̑傫���ύX
        _isOnGround = true;
    }

    void Update()
    {
<<<<<<< HEAD
        _rb.AddForce(_speed, 0, 0, ForceMode.Force);//�����ړ�

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
=======
        Walk(); //�����ړ�
        Jump(); //�W�����v

    }

    /// <summary>
    /// �L�����N�^�[�̓����̏���
    /// </summary>
    public void Walk()
    {
        _rb.AddForce(_speed, 0, 0,ForceMode.Force);
    }

    /// <summary>
    /// �W�����v�̏���
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
>>>>>>> 6ce10e6ca0de20e230447535169f8233a64e418a
}
