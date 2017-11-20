using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int damage = 1;
    public string compareTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(compareTag))
        {
            other.GetComponent<HealthSystem>().TakeDamage(damage);
        }

    }
}
