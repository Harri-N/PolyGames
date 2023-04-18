using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get;}

    public Animator transition;
    public float transitionTime = 1f;
    

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string _sceneName){
        //StartCoroutine(LoadLevel(_sceneName));
        SceneManager.LoadScene(_sceneName);
    }

    IEnumerator LoadLevel(string _sceneName) {
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(_sceneName);
        transition.ResetTrigger("FadeOut");
        //yield return new WaitForSeconds(transitionTime);
        //transition.ResetTrigger("FadeOut");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
