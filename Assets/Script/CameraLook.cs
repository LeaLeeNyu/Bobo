using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // The offset of grabed object
    [SerializeField] private float zOffset = 3f;
    [SerializeField] private float xOffset = 0f;
    [SerializeField] private float yOffset = 0f;

    [SerializeField] private float range = 100f;

    GameObject heldObj;
    Vector3 objOriginalPos;
    Camera cameraM;

    //Dialogue Trigger
    public Dialogue friendDialogue;
    public static bool friendIsHit = false;


    // Start is called before the first frame update
    void Start()
    {
        cameraM = GetComponent<Camera>();

        Vector3 startRot = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitter = new RaycastHit();

        Debug.DrawRay(transform.position, cameraM.transform.forward*20f, Color.blue);
    
        //out means return a value
        //SphereCast will chech the area with certain radius
        //Physics.Raycast(cameraM.transform.position, cameraM.transform.forward,out hit, range)
        if (Physics.Raycast(cameraM.transform.position, cameraM.transform.forward, out hitter,range))
        {
            //Debug.Log("hit something!");
            //Debug.Log(hitter.collider.gameObject.name);

            //if I held some obj
            if (heldObj != null)
            {
                //if the ray hit the holded obj
                if (heldObj.name == hitter.collider.gameObject.name)
                {
                    Debug.Log("cursor on held object");
                }
            }


            if ( hitter.collider.gameObject.tag == "Map" && heldObj == null)
            {
                Debug.Log("can pick");
                objOriginalPos = hitter.collider.gameObject.transform.position;

                if (Input.GetMouseButtonDown(0))
                {
                    PickUpObject(hitter.collider.gameObject, objOriginalPos);
                }              
            }else if(hitter.collider.gameObject.tag == "Friend")
            {
                friendIsHit = true;

                if (Input.GetMouseButtonDown(0) && DialogueSystem.noDialogue)
                {
                    TriggerDialogue(friendDialogue);
                }
            }
            //reset all the parameter
            else
            {
                friendIsHit = false;
            }
        }

        if (Input.GetMouseButton(1) && heldObj != null)
        {
            //Debug.Log("drop");
            DropObject();
        }
    }
    void PickUpObject(GameObject obj,Vector3 objOriginalPos)
    {
        heldObj = obj;
        objOriginalPos = obj.transform.position;
        //Debug.Log(objOriginalPos);

        //for rotate the object when it was chosen
        //obj.transform.SetParent(gameObject.transform);

        Vector3 newPos = new Vector3(objOriginalPos.x + xOffset, objOriginalPos.y + yOffset, objOriginalPos.z + zOffset);

        obj.transform.position = newPos;
    }

    void DropObject()
    {
        heldObj.transform.SetParent(null);
        heldObj.transform.position = objOriginalPos;

        objOriginalPos = Vector3.zero;
        heldObj = null;
    }

    //Dialogue Trigger
    public void TriggerDialogue(Dialogue dialogue)
    {
        //start the first line of the dialogue
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }

}
