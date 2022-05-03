using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private List<CheckingPoint> checkpointList;
    public Vector3 checkPointPos = new Vector3(-70,0.2f,-39);

    private void Awake()
    {
        //Find all children's transform
        Transform checkpointsTransform = transform.Find("CheckPoint");

        //The list to store the checkpoint objects
        checkpointList = new List<CheckingPoint>();

        foreach (Transform checkpointTransform in checkpointsTransform)
        {
            //Get the checkpoint
            CheckingPoint checkPoint = checkpointsTransform.GetComponent<CheckingPoint>();
            //Sign the checkpoint manager to check point
            checkPoint.SetCheckpointManager(this);
            checkpointList.Add(checkPoint);

        }
    }

    //To know the player collide with one of the checkpoints
    public void PlayerThorughCheckpoint(CheckingPoint checkingPoint)
    {
        Debug.Log(checkingPoint.gameObject.name);
        checkPointPos = checkingPoint.checkPointPos;
        SaveSystem.SavePlayer(this);
    }
}
