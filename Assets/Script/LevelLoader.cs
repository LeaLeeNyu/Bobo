using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(LoadingScene("Level0"));
       
    }

    IEnumerator LoadingScene(string sceneName)
    {
        AsyncOperation isLoading = SceneManager.LoadSceneAsync(sceneName);

        while (!isLoading.isDone)
        {
            Debug.Log(isLoading.progress);
            yield return null;
        }

    }
}
