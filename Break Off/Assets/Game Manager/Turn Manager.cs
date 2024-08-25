using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;  

public class TurnManager : NetworkBehaviour  
{
    public NetworkVariable<bool> isTurn = new NetworkVariable<bool>(false);  
    private Vector2 lastDirection;
    public GameObject piece;
    public GameObject options;
    private bool isCancel;

    void Start()
    {
        if (IsOwner)  
        {
            options = GameObject.FindGameObjectWithTag("Player");
            options.SetActive(false);  
        }
    }

    void Update()  
    {
        if (!isTurn.Value || !IsOwner) return;  // Only proceed if it's this client's turn and they own the object

        if (lastDirection != Vector2.zero)
        {
            Vector3 newPosition = new Vector3(piece.transform.position.x + 1.1f * lastDirection.x, piece.transform.position.y + 1.1f * lastDirection.y, 0);
            piece.transform.position = newPosition;
            lastDirection = Vector2.zero;  
        }

        if (isCancel)
        {
            options.SetActive(true);  
            isCancel = false;
        }
    }

    public void Move(InputAction.CallbackContext c)
    {
        if (!isTurn.Value || !IsOwner) return;  

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
        if (!isTurn.Value || !IsOwner) return;  

        if (c.performed)
        {
            isCancel = true;
        }
    }

    [ServerRpc]  
    public void StartTurnServerRpc()
    {
        isTurn.Value = true;  
    }

    [ServerRpc]  
    public void EndTurnServerRpc()
    {
        isTurn.Value = false;  
        // Logic to pass the turn to the next player should be implemented here
    }
}
