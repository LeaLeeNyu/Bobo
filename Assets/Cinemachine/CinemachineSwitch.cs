using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitch : MonoBehaviour
{
    private Animator camAnimator;

    void Start()
    {
        camAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }


    void SwitchCamera()
    {
        //If there is Dialogue
        if (!DialogueSystem.noDialogue)
        {
            camAnimator.Play("DialogueCamera");
        }
        else
        {
            camAnimator.Play("ThirdPersonCamera");
        }
    }
}
