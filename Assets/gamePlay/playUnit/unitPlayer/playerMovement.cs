using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement
{
    private playerBody pB;
    private Animator pA;

    private float fallSpeed = 980f;
    private Vector3 moveDirection;
    private Vector3 movelastDirection;
    private Vector3 camPosition = new Vector3(-5f, 7.5f, -5f);

    public playerMovement(playerBody pB, Animator pA)
    {
        this.pB = pB;
        this.pA = pA;
    }

    public void DoMove(GameObject g, playerState s)
    {
        switch (s)
        {
            case playerState.inRoom:
                float x = Input.GetAxisRaw("Horizontal");
                float z = Input.GetAxisRaw("Vertical");

                if (g.GetComponent<CharacterController>().isGrounded)
                {
                    moveDirection = new Vector3(x, 0, z);

                    if (movelastDirection != moveDirection)
                    {
                        movelastDirection = moveDirection;
                    }
                }
                moveDirection.y -= fallSpeed * pB.GetGM().gameTime;

                DoFollowCam(g);
                pA.SetBool("isWalk", ((x*x) + (z*z)) != 0);
                pA.SetFloat("plySpeed", pB.bodySpeed);

                g.GetComponent<CharacterController>().Move(moveDirection * pB.bodySpeed * pB.GetGM().gameTime);
                
                if (movelastDirection != Vector3.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(movelastDirection, Vector3.up);
                    g.transform.rotation = Quaternion.RotateTowards(g.transform.rotation, toRotation, 200 * pB.GetGM().gameTime);
                }
                break;
            case playerState.inPlayBattle:
                break;
            case playerState.inPlayEvent:
                break;
        }
    }

    private void DoFollowCam(GameObject g)
    {
        pB.cam.transform.position = Vector3.Lerp(pB.cam.transform.position, g.transform.position + camPosition, pB.bodySpeed * pB.GetGM().gameTime);
    }

    public void DoHandEmpty()
    {
        pA.SetTrigger("handEmpty");
    }

    public void DoHandRifle()
    {
        pA.SetTrigger("handRifle");
    }
}
