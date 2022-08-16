using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    public float X { get; private set; }
    public float Z { get; private set; }

   
    public bool Attack { get; private set; }
    // Start is called before the first frame update
    Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");
      Attack = Input.GetKeyDown(KeyCode.Space);

    }
}
