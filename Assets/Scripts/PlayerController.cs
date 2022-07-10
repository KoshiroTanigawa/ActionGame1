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
        _rb = GetComponent<Rigidbody>();    //Rigidbody�擾
        Physics.gravity *= _gravityScale;   //�d�͂̑傫���ύX
        _posZ = transform.position.z;

    }

    void Update()
    {
        Walk(); //�����ړ�

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
        _rb.AddForce(0, _jumpForce, 0, ForceMode.Impulse);
    }
}
