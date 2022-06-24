using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private void Start()
    {
        //StartCoroutine(DelayTime(5f));
        StartCoroutine(LoadingScene("Level0"));       
    }

    IEnumerator DelayTime(float second)
    {
        yield return new WaitForSeconds(second);
    }

    IEnumerator LoadingScene(string sceneName)
    {
        yield return new WaitForSeconds(3f);
        //Load the leavel asynchronous
        AsyncOperation isLoading = SceneManager.LoadSceneAsync(sceneName);

        while (!isLoading.isDone)
        {
            yield return null;
        }
    }


}
