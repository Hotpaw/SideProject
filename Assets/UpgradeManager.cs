using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
  
    public static UpgradeManager INSTANCE;
    public List<Upgrade> Upgrades;

    private void Start()
    {
        INSTANCE = this;
    }
    public void ChooseUpgrade(int upgradeID)
    {
        if (Upgrades[upgradeID].cost < GameManager.INSTANCE.currency)
        {
            Upgrades[upgradeID].UpgradeEffect();
        }
        else
        {
            PopUpText.INSTANCE.PopUpMessage("You do not have enough currency for this", Color.red);
        }
    }
}
