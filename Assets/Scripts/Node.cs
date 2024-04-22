using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color afterColor;
    public Color notEnoughColor;

    public Vector3 positionOffset;

    [Header("Optional")]
    public Renderer rend;
    public GameObject turret;

    BuildManager buildManager; 
    private void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Space Occupied");
            return;
        }

        buildManager.buildTurretOn(this);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney )
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughColor;

        }
        
    }

    private void OnMouseExit()
    {
        rend.material.color = afterColor;
    }
}
