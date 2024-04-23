using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public NodeUi nodeui;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
        }
        Instance = this;
    }


    public GameObject buildEffect;


    private Turretblueprint turretToBuild;
    private Node selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void selectTurretToBuild(Turretblueprint turret)
    {
        turretToBuild = turret;
        deselectNode();
    }

    public void selectNode(Node node)
    {
        if (selectedNode == node)
        {
            deselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeui.SetTarget(node);
    }

    public void deselectNode()
    {
        selectedNode = null;
        nodeui.hide();
    }
    public Turretblueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }
}
