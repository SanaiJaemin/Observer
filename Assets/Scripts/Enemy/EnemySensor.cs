using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    EnemyMovement _enemyMovement;
    private int _layer;
    private void Awake()
    {
        _enemyMovement = GetComponentInParent<EnemyMovement>();
        _layer = LayerMask.NameToLayer("Enemy"); // 6
    }
    private void OnTriggerEnter(Collider other)
    {
        // 지금 부딪힌 애가 Enemy라면
        if(other.gameObject.layer == _layer)
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            Debug.Assert(enemyHealth != null);

            enemyHealth.onTakeDamage -= _enemyMovement.MoveTo;
            enemyHealth.onTakeDamage += _enemyMovement.MoveTo;

            Debug.Log($"{other.name} 에 {transform.parent.name}의 MoveTo가 추가됨");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            Debug.Assert(enemyHealth != null);
            enemyHealth.onTakeDamage -= _enemyMovement.MoveTo;
            Debug.Log($"{other.name} 에 {transform.parent.name}의 MoveTo가 삭제됨");
        }
    }

}
