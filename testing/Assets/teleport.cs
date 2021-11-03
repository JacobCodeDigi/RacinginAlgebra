using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public GameObject playerTarget;
    float rotationResetSpeed = 1.0f;
    Quaternion originalrotation;

    private void Start()
    {
        originalrotation = transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Before reset: " + playerTarget.GetComponent<Rigidbody>().velocity.ToString());
            playerTarget.transform.position = new Vector3(1562.02f, 1.202606f, 1627.04f);
            playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Freeze");
            playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Debug.Log("Unfreeze");
            transform.rotation = Quaternion.Slerp(transform.rotation, originalrotation, Time.time * rotationResetSpeed);
        }

    }
}
