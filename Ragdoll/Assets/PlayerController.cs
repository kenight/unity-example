using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Collider col; // main collider
    Collider[] cols; // all collider include ragdoll and character main

    void Start()
    {
        col = GetComponent<Collider>();
        cols = GetComponentsInChildren<Collider>(true);

        SetRagdoll(false);
    }

    // 交换状态
    void SetRagdoll(bool isRagdoll)
    {
        foreach (var c in cols)
        {
            c.enabled = isRagdoll;
        }
        col.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
            SetRagdoll(true);
    }
}
