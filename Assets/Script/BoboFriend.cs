using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoboFriend : MonoBehaviour
{
    public GameObject Bobo;
    public Canvas friendCanvas;

    // Start is called before the first frame update
    void Start()
    {
        friendCanvas = GetComponentInChildren<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraLook.friendIsHit)
        {
            friendCanvas.gameObject.SetActive(true);
        }
        else
        {
            friendCanvas.gameObject.SetActive(false);
        }

        Vector3 direction = (Bobo.gameObject.transform.position - gameObject.transform.position).normalized;
        float turnAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, turnAngle,0f);
        //Debug.Log(transform.rotation);
    }
}
