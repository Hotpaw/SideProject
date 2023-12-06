using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallUpgrade : Upgrade
{
    public string objname;
    public int upgradeCost;
    private void Start()
    {
        cost = upgradeCost;
        upgradeName = objname;
    }

    public override void UpgradeEffect()
    {
        
    }

    
}
