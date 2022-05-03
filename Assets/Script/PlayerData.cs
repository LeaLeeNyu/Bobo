using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData(CheckPointManager checkPointManager)
    {
        //position[0] = playerController.transform.position.x;
        //position[1] = playerController.transform.position.y;
        //position[2] = playerController.transform.position.z;
    }
}
