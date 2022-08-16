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

        onTakeDamage?.Invoke(transform); // 주변 객체한테 알림.

        Debug.Log($"{gameObject} : 그만 떄려. [{damage}] ");
        if(Hp <= 0)
        {
            IsDead = true;
            gameObject.SetActive(false);
            Debug.Log($"{gameObject} : 난 다시 돌아온다");
        }
        //EnemyMovement move;
        //move.MoveTo();
        //StartCoroutine(move.MoveTo());
    
    }

    
}
