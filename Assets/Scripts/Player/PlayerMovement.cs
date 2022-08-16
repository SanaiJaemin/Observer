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
    /// 캐릭터를 앞 뒤로 움직인다
    /// </summary>
    /// <param name="direction">양수면 캐릭터의 forward방향을 의미하며, 음수면 캐릭터의 backward 방향을 의미한다.</param>
    private void moveForward(float direction)
    {
        // 1. Rigidbody의 속력을 이용하는 방법
        // 2. 순간이동을 시키는 방법 이거함

        Vector3 deltaPositoin = MoveSpeed * direction * Time.fixedDeltaTime * transform.forward;
        Vector3 newPosition = _rigidbody.position + deltaPositoin;
        _rigidbody.MovePosition(newPosition);

    }

    /// <summary>
    /// 캐릭터를 시계방향으로 회전시킨다
    /// </summary>
    /// <param name="direction">양수면 시계방향을, 음수면 반시계방향을 의미한다.</param>
    private void rotateClockwise(float direction)
    {
        Quaternion deltaRotation = Quaternion.Euler(0f, RotationSpeed * direction * Time.fixedDeltaTime, 0f);

        Quaternion newRotation = _rigidbody.rotation * deltaRotation;
        _rigidbody.MoveRotation(newRotation);
    }
}