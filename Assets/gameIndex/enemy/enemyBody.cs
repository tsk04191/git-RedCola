using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBody : MonoBehaviour
{
    GameObject Manager;
    sysWave wM() { return Manager.GetComponent<sysWave>(); }

    [Header("enemy info")]
    public string strName;

    [Header("base stat")]
    [SerializeField] private int intBaseDurability;
    [SerializeField] private int intBaseResPhysics;
    [SerializeField] private int intBaseResMental;
    [SerializeField] private float fltBaseSpeed;

    [Header("increase stat")]
    [SerializeField] private int intUpDurability;
    [SerializeField] private int intUpResPhysics;
    [SerializeField] private int intUpResMental;
    [SerializeField] private float fltUpSpeed;

    private int intMaxDurability;
    private int intMaxResPhysics;
    private int intMaxResMental;
    private float fltMaxSpeed;
    private int intMaxShield;

    private int intNowDurability;
    private int intNowResPhysics;
    private int intNowResMental;
    private float fltNowSpeed;
    private int intNowShield;

    public void SetMaxStat(int i)
    {
        intMaxDurability = intBaseDurability + (intUpDurability * i);
        intMaxResPhysics = intBaseResPhysics + (intUpResPhysics * i);
        intMaxResMental = intBaseResMental + (intUpResMental * i);
        fltMaxSpeed = fltBaseSpeed + (fltUpSpeed * i);

        intNowDurability = intMaxDurability;
        intNowResPhysics = intMaxResPhysics;
        intNowResMental = intMaxResMental;
        fltNowSpeed = fltMaxSpeed;
    }

    private void Update()
    {
        if (intNowDurability <= 0)
        {
            OnDead();
        }
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }
}
