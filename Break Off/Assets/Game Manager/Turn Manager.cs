using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    public bool isTurn;
    Vector2 lastDirection;
    public GameObject piece;
    public GameObject options;

    void Start()
    {
        options = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!isTurn) { return; }
        Vector3 newPosition = new Vector3(piece.transform.position.x + 1.1f * lastDirection.x, piece.transform.position.y + 1.1f * lastDirection.y, 0);
        piece.transform.position = newPosition;
    }

    public void Move(InputAction.CallbackContext c)
    {
        if (c.performed)
        {
            lastDirection = c.ReadValue<Vector2>();
        }
        else if (c.canceled)
        {
            lastDirection = Vector2.zero;
        }
    }

    public void Cancel(InputAction.CallbackContext c)
    {
        if(c.performed)
        {
            options.SetActive(true);
        }
    }

    
}
