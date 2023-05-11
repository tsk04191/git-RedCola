using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class npcMovement
{
    private npcBody nB;
    private Animator nA;

    private float fallSpeed = 980f;
    private Vector3 moveDirection;

    public npcMovement(npcBody nB, Animator nA)
    {
        this.nB = nB;
        this.nA = nA;
    }

    public void DoMove(GameObject g)
    {
        moveDirection.y -= fallSpeed * nB.GetGM().gameTime;

        g.GetComponent<CharacterController>().Move(moveDirection * nB.GetGM().gameTime);
    }
}
