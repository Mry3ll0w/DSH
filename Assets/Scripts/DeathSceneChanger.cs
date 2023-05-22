using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathSceneChanger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay("MainMenu", 10.0f));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
