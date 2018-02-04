using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int damage = 1;
    public DamageTarget damageTarget = DamageTarget.Enemey;

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (damageTarget)
        {
            case DamageTarget.Enemey:
                if (other.CompareTag("Enemey"))
                    other.GetComponent<Enemey>().TakeDamage(damage);
                break;
            case DamageTarget.Player:
                if (other.CompareTag("Player"))
                    other.GetComponent<Attack>().TakeDamage(damage);
                break;
        }
    }

    public enum DamageTarget
    {
        Player,
        Enemey
    }
}
