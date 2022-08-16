using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class PlayerCtrl : MonoBehaviour, ITargetable
{


    public float x { get; private set; }
    public float z { get; private set; }
    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;
    private bool Attack = false;
    public float TotalTime = 0f;
    private SphereCollider _sphereCollider;
    public GameObject Weapon;


    private Vector3 movevec;

    Animator _animator;
    Rigidbody _rigidbody;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Start()
    {
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Move();
        Attack = Input.GetKeyDown(KeyCode.Space);

        if (Attack)
        {
            Attack1();
        }
       



    }

    public void Damaged()
    {
        Debug.Log("공격을 받았다");
    }

    public void Move()
    {
        movevec = new Vector3(x, 0f, z);
        transform.position += movevec * moveSpeed * Time.deltaTime;
        _animator.SetBool("isWalk", movevec != Vector3.zero);
        transform.LookAt(transform.position + movevec);
    }

    public void Attack1()
    {
        _animator.SetTrigger("isAttack");
        
    }



}
