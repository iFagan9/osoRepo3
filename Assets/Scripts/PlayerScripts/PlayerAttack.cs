using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject playerCamera;
    private Vector3 firePoint;
    private Vector3 lookDir;

    public float shotDamage;
    private AudioSource[] gunSources;
   

    private int gunSound = 0;


    // Start is called before the first frame update
    void Start()
    {
        gunSources = GetComponents<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        lookDir = playerCamera.transform.forward;
        firePoint = playerCamera.transform.position;
    }

    public void ProcessShot()
    {
        //Debug.Log("Shot");
        RaycastHit hitInfo;
        if (gunSound == 0)
        {
            gunSources[0].Play();
            gunSound = 1;
        }

        if (gunSound == 1)
        {
            gunSources[1].Play();
            gunSound = 0;
        }
      
        if (Physics.Raycast(firePoint, lookDir, out hitInfo))
        {
            //Debug.Log("Hit Something: " + hitInfo.collider.name);
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.GetComponentInParent<EnemyAI>().TakeDamage(shotDamage);
                //Debug.Log("Hit Enemy: " + hitInfo.collider.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(firePoint, lookDir);
    }
}
