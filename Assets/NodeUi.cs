using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class NodeUi : MonoBehaviour
{

    public GameObject ui;
    private Node target;

    public TextMeshProUGUI upgradecost;
    public TextMeshProUGUI sellcost;


    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        upgradecost.text = "$" + target.turretBlueprint.upgradeCost.ToString();
        target.turretBlueprint.sellCost = target.turretBlueprint.cost / 2;
        sellcost.text = "$" + target.turretBlueprint.sellCost.ToString();

        ui.SetActive(true);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.Instance.deselectNode();
    }
}
