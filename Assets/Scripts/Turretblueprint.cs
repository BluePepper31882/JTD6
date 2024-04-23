using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Turretblueprint
{
    public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public int upgradeCost;
    [HideInInspector]
    public int sellCost;

    



}
