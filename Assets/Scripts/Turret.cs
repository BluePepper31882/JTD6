using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class Turret : MonoBehaviour
{ 
    
    public Transform target;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public float fireRate = 1f;
    public GameObject boolet;
    
    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;
    
    

    
    public Transform firepoint;
    private bool canShoot = true;
   
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.01f);
    }

    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range) 
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        
    }

    
    void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        lockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (canShoot)
            {
                shoot();
                StartCoroutine(WaitForNextShot());
            }

            IEnumerator WaitForNextShot()
            {
                canShoot = false;
                yield return new WaitForSeconds(1f / fireRate);
                canShoot = true;
            }
        }

        

        //if (fireCountdown <= 0f)
        //{
        //    shoot();
        //    fireCountdown = 1f / fireRate;
        //}
        //else if (fireCountdown > 1f / fireRate)
        //{
        //    fireCountdown = 0f;
        //}

        //fireCountdown -= Time.deltaTime;

    }
    void lockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        
        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir = firepoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized * .5f;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
        
    } 
    void shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(boolet, firepoint.position, firepoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();

        if (bullet != null)
            bullet.seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
