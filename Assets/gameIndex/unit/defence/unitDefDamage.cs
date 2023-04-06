using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class unitDefDamage
{
    [SerializeField] private unitDamageType damageType;
    [SerializeField] private unitAttackType attackType;

    [Space(5f)]
    [SerializeField] private int intBaseDamage;
    [SerializeField] private float fltBaseSpeed;

    [Space(5f)]
    [SerializeField] private int intUpDamage;
    [SerializeField] private float fltUpSpeed;

    public int DoAttack(int i)
    {
        return intBaseDamage + (intUpDamage * i);
    }

    public float DoGetSpd(int i)
    {
        return fltBaseSpeed + (fltUpSpeed * i);
    }
}
