using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcBody : MonoBehaviour
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }
    private npcMovement _Movement;

    private Image imgTag;
    private Camera cam;

    public bool boolInteraction;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");
        _Movement = new npcMovement(this, gameObject.GetComponent<Animator>());
    }

    private void Start()
    {
        imgTag = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        cam = gameObject.transform.GetChild(0).GetComponent<Canvas>().worldCamera;
    }

    private void Update()
    {
        tagFacing();
        _Movement.DoMove(gameObject);
    }

    private void tagFacing()
    {
        Vector3 facingDir = cam.transform.forward;
        Vector3 targetImg = imgTag.transform.up;
        Quaternion targetRotation = Quaternion.LookRotation(facingDir, targetImg);

        imgTag.transform.rotation = targetRotation;
    }

    public void Interaction()
    {

    }

    public gameManager GetGM()
    {
        return gM();
    }
}
