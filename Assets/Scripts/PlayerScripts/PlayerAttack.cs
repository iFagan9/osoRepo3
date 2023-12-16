using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject playerCamera;
    private Vector3 firePoint;
    private Vector3 lookDir;

    public float shotDamage;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();
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
