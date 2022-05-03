using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingPoint : MonoBehaviour
{
    private CheckPointManager checkPointManager;
    public Vector3 checkPointPos;

    private void Awake()
    {
        checkPointPos = gameObject.transform.position;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        //if player pass through this checkpoint, pass to the checkpoint manager
    //        checkPointManager.PlayerThorughCheckpoint(this);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if player pass through this checkpoint, pass to the checkpoint manager
            checkPointManager.PlayerThorughCheckpoint(this);
        }
    }

    public void SetCheckpointManager(CheckPointManager checkPointManager)
    {
        this.checkPointManager = checkPointManager;
    }


}
