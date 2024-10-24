using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float timeDelay = 2f;
    public void LoadScene()
    {
        SceneManager.LoadScene("GamePlay");

    }

    public void LoadMenuGame()
    {
        SceneManager.LoadScene("MenuGame");

    }

    public void LoadOverGame()
    {
        // SceneManager.LoadScene("EndGame");
        StartCoroutine(WaitAndLoad("EndGame", timeDelay));
    }

    public void QuitGame()
    {
        Debug.Log("quit game....");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
