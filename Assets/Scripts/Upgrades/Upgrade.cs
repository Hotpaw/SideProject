using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    protected string? upgradeName = null;
    public int? cost = null;

    public abstract void UpgradeEffect();
    
}
