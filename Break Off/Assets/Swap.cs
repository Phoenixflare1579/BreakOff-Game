using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject[] target;
    public GameObject replacement;
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Red");
        for (int i = 0; i < target.Length; i++)
        {
            Instantiate(replacement, target[i].transform.parent);
        }
        for (int i = 0; i < target.Length; i++)
        {
            Destroy(target[i]);
        }
    }
}
