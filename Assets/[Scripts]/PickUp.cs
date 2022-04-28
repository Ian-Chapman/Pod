using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigidbody.freezeRotation = true;
        }

        if (other.gameObject.tag == "DropZone")
        {
            StartCoroutine(DelayDestroyRigidbody());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rigidbody.freezeRotation = false;
        }
    }


    IEnumerator DelayDestroyRigidbody()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(rigidbody);

    }
}
