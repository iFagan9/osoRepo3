using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 30f;
    public bool opened = false;
    [SerializeField] public bool canClose;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method to open the door slowly
    public void OpenDoorR()
    {
        if (opened == false)
        {


            StartCoroutine(RotateDoorR(250));
            opened = true;
        }
    }
    public void OpenDoorL()
    {
        if (opened == false)
        {
            StartCoroutine(RotateDoorL(360));
            opened = true;
        }
    }
    IEnumerator RotateDoorR(float targetRotation)
    {
        // Get the current rotation
        float currentRotation = transform.rotation.eulerAngles.y;

        // Rotate gradually until reaching the target rotation
        
        while (Mathf.Abs(targetRotation - currentRotation) > 0.01f)
        {
            // Calculate the rotation step
            float rotationStep = rotationSpeed * Time.deltaTime;

            // Rotate towards the target rotation
            transform.Rotate(Vector3.up, Mathf.Sign(targetRotation - currentRotation) * rotationStep);

            // Update the current rotation
            currentRotation = transform.rotation.eulerAngles.y;

            yield return null;
        }
     
    }

    IEnumerator RotateDoorL(float targetRotation)
    {
        // Get the current rotation
        float currentRotation = transform.rotation.eulerAngles.y;

       
            while (Mathf.Abs(targetRotation - currentRotation) > 0.01f)
            {
                // Calculate the rotation step
                float rotationStep = rotationSpeed * Time.deltaTime;

                // Rotate towards the target rotation
                transform.Rotate(Vector3.up, -Mathf.Sign(targetRotation - currentRotation) * rotationStep);

                // Update the current rotation
                currentRotation = transform.rotation.eulerAngles.y;

                yield return null;
            }
    }
}
