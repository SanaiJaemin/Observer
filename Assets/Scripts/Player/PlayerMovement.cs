using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;

    private float MoveSpeed = 10f;
    private float RotationSpeed = 120f;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveForward(_playerInput.Z);
        rotateClockwise(_playerInput.X);
    }
    /// <summary>
    /// ĳ���͸� �� �ڷ� �����δ�
    /// </summary>
    /// <param name="direction">����� ĳ������ forward������ �ǹ��ϸ�, ������ ĳ������ backward ������ �ǹ��Ѵ�.</param>
    private void moveForward(float direction)
    {
        // 1. Rigidbody�� �ӷ��� �̿��ϴ� ���
        // 2. �����̵��� ��Ű�� ��� �̰���

        Vector3 deltaPositoin = MoveSpeed * direction * Time.fixedDeltaTime * transform.forward;
        Vector3 newPosition = _rigidbody.position + deltaPositoin;
        _rigidbody.MovePosition(newPosition);

    }

    /// <summary>
    /// ĳ���͸� �ð�������� ȸ����Ų��
    /// </summary>
    /// <param name="direction">����� �ð������, ������ �ݽð������ �ǹ��Ѵ�.</param>
    private void rotateClockwise(float direction)
    {
        Quaternion deltaRotation = Quaternion.Euler(0f, RotationSpeed * direction * Time.fixedDeltaTime, 0f);

        Quaternion newRotation = _rigidbody.rotation * deltaRotation;
        _rigidbody.MoveRotation(newRotation);
    }
}