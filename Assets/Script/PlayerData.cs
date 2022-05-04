using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData(CheckingPoint checkPoint)
    {
        position = new float[3];

        position[0] = checkPoint.checkPointPos.x;
        position[1] = checkPoint.checkPointPos.y;
        position[2] = checkPoint.checkPointPos.z;
    }
}
