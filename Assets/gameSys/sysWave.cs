using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sysWave : MonoBehaviour
{
    GameObject GM;
    gameManager gM() { return GM.GetComponent<gameManager>(); }

    [SerializeField] private int intMaxSpawn;
    [SerializeField] private int intLeftSpawn;
}
