using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private void Awake()
    {
        //Find all the checkpoint in the children
        Transform checkpointsTransform = transform.Find("CheckPoint");

        foreach(Transform checkpointTransform in checkpointsTransform)
        {
            
        }


    }
}
