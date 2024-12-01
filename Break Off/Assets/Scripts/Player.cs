using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Awake()
    {
        this.gameObject.transform.SetParent(GameObject.Find("Main Game").transform.GetChild(1));
    }
}
