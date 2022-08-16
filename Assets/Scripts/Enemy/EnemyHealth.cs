using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Hp = 100;

    public event Action<Transform> onTakeDamage;

    public bool IsDead { get; private set; }

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        onTakeDamage?.Invoke(transform); // �ֺ� ��ü���� �˸�.

        Debug.Log($"{gameObject} : �׸� ����. [{damage}] ");
        if(Hp <= 0)
        {
            IsDead = true;
            gameObject.SetActive(false);
            Debug.Log($"{gameObject} : �� �ٽ� ���ƿ´�");
        }
        //EnemyMovement move;
        //move.MoveTo();
        //StartCoroutine(move.MoveTo());
    
    }

    
}
