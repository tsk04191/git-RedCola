using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBody : MonoBehaviour
{
    private GameObject GM;
    private gameManager gM() { return GM.GetComponent<gameManager>(); }
    private playerMovement _Movement;

    public Camera cam;
    public List<GameObject> objGunList;

    public playerState state;
    
    public float bodySpeed = 2.0f;
    public float ittRange = 2.0f;

    private void Awake()
    {
        GM = GameObject.Find("gameManager");
        _Movement = new playerMovement(this, gameObject.GetComponent<Animator>());
    }
    
    private void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Canvas>().worldCamera = cam;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bodySpeed = 5.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            bodySpeed = 2.0f;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _Movement.DoHandRifle();
        }

        if (Input.GetMouseButtonDown(0))
        {
        }

        CheckInteraction();
        _Movement.DoMove(gameObject, state);
    }

    private void CheckInteraction()
    {
        Vector3 playerPos = transform.position;

        Collider[] nearCol = Physics.OverlapSphere(playerPos, ittRange);

        foreach (Collider c in nearCol)
        {
            GameObject nearObj = c.gameObject;
        }
    }

    private void ClickInteraction()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {

        }
    }

    private void DoInteraction(GameObject g)
    {
        g.GetComponent<npcBody>().Interaction();
    }

    public gameManager GetGM()
    {
        return gM();
    }
}
