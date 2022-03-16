using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProcress : SingeltonGenerik<SceneProcress>
{
    public void RePlayBtnAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }
    public void NexLevelBtnAction()
    {
        if (SceneManager.GetActiveScene().buildIndex+1< SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameObject.SetActive(false);
        }
        else
        {
            RePlayBtnAction();
        }
    }
    public void StartBtnAction()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
