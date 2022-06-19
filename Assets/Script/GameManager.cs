using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    void Start()
    {
        if (instance !=null & instance != this){
            Destroy(gameObject);
        }else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if(PlayerController.gameIsEnd & Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("LoadScene");
            PlayerController.gameIsEnd = false;
        }
    }


}
