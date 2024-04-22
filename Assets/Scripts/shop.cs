using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Turretblueprint standardTurret;
    public Turretblueprint missileLauncher;
    public Turretblueprint laserLauncher;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.selectTurretToBuild(standardTurret);
    }

    public void selectMissleTurret()
    {
        Debug.Log("Missle Turret Purchased");
        buildManager.selectTurretToBuild(missileLauncher);
    }
    public void selectLaserBeamer()
    {
        Debug.Log("Laser Turret Purchased");
        buildManager.selectTurretToBuild(laserLauncher);
    }
}
