using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject what;
    public int amount = 3;
    public float minOffset = -1;
    public float maxOffset = 1;

    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float offset = Random.Range(minOffset, maxOffset);
        float x = transform.position.x + offset;
        Vector3 pos = new Vector3(x, transform.position.y, transform.position.z);
        Instantiate(what, pos, Quaternion.identity);
    }
}
