using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private PlayerInput _input;
    public int Damage = 10;
    private Collider[] _colliders = new Collider[3];
    private int colliderCount;
    private int _enemyLayerMask;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();

        LayerMask layerMask = LayerMask.NameToLayer("Enemy");
        _enemyLayerMask = (1 << layerMask);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_input.Attack)
        {
            attack();
        }
    }

    void attack()
    {
        Vector3 attackPosition = transform.position + transform.forward;
        colliderCount = Physics.OverlapSphereNonAlloc(attackPosition, 1f, _colliders, _enemyLayerMask);

        for (int i = 0; i < colliderCount; i++)
        {
            EnemyHealth enemyHealth = _colliders[i].GetComponent<EnemyHealth>();
            Debug.Assert(enemyHealth != null);

            enemyHealth.TakeDamage(Damage);
        }
        Debug.Log($"{gameObject} : 응 때릴거야");
    }
}
