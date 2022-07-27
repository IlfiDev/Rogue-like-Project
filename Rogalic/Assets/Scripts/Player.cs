using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = new PlayerMovement(gameObject);
    }

    void FixedUpdate()
    {
        playerMovement.ShitMoveVersion();
    }
}
