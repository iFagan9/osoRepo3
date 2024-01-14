using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 30f;
    public bool opened = false;
    [SerializeField] public float specialR =180;
    [SerializeField] public bool canClose;
    private AudioSource sound;


    // Start is called before the first frame update
    void Start()
    {
         
   sound= GetComponent<AudioSource>();

}

    // Method to open the door slowly
    public void OpenDoorR()
    {
        if (opened == false)
        {
            if (sound != null)
                sound.Play();

            StartCoroutine(RotateDoorR(specialR));
            opened = true;
        }
    }
    public void OpenDoorL()
    {
        if (opened == false)
        {
           if(sound!=null)
                sound.Play();
            StartCoroutine(RotateDoorL(specialR));
            opened = true;
        }
    }
   
    public void CloseL()
    {
        if (opened && canClose)
        {
            if (sound != null)
                sound.Play();
            StartCoroutine(RotateDoorL(0));
        }
    }
    public void CloseR()
    {
        if (opened && canClose)
        {
            if (sound != null)
                sound.Play();
            StartCoroutine(RotateDoorR(0));
        }
    }
    IEnumerator RotateDoorR(float targetRotation)
    {
        // Get the current rotation
        float currentRotation = transform.rotation.eulerAngles.y;

        // Rotate gradually until reaching the target rotation

        while (Mathf.Abs(targetRotation - currentRotation) > 0.6f)
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

        // Determine the direction of rotation
        float rotationDirection = -Mathf.Sign(targetRotation - currentRotation);

        // Rotate gradually until reaching the target rotation
        while (Mathf.Abs(targetRotation - currentRotation) > 0.6f)
        {
            // Calculate the rotation step
            float rotationStep = rotationSpeed * Time.deltaTime;

            // Rotate towards the target rotation
            transform.Rotate(Vector3.up, rotationDirection * rotationStep);

            // Update the current rotation
            currentRotation = transform.rotation.eulerAngles.y;

            // Debug logs
          //  Debug.Log("Current Rotation: " + currentRotation + " | Target Rotation: " + targetRotation);

            yield return null;
        }
    }

}