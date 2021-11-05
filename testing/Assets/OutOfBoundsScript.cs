using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBoundsScript : MonoBehaviour
{
    public GameObject playerTarget;
    public Quaternion originalrotation;
    float rotationResetSpeed = 1.0f;
    private void OnTriggerEnter(Collider other)
    {
        playerTarget.transform.position = new Vector3(1562.02f, 1.202606f, 1627.04f);
        playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        playerTarget.transform.rotation = originalrotation; //These 4 lines are freezing and moving the player object back to the startline
    }
}
