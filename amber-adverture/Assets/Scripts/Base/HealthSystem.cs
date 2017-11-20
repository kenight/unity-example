using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int hp = 10;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        hp -= damage;

        anim.SetTrigger("Hurt");

        if (hp <= 0)
        {
            anim.SetTrigger("Dead");
        }
    }

}
