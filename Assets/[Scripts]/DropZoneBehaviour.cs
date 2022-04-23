using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneBehaviour : MonoBehaviour
{
    GameUIController gameUIController;

    // Start is called before the first frame update
    void Start()
    {
        gameUIController = GameObject.Find("GameCanvas").GetComponent<GameUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            gameUIController.garbageCollected++;
        }
    }
}
