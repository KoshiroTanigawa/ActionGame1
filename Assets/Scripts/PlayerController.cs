using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField][Header("���x")]
    [Tooltip("�L�����N�^�[�̈ړ����x")]
    public float _speed = 20f;

    [SerializeField][Header("�W�����v��")]
    [Tooltip("�L�����N�^�[�̃W�����v��")]
    public float _jumpForce = 10f;

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
}
