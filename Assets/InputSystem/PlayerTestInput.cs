using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestInput : MonoBehaviour
{
    public float jumpForce = 5.0f;
    private Rigidbody playerRB;


    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        playerRB.AddForce(Vector3.up * jumpForce);
    }


}
