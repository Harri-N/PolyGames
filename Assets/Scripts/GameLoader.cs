using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    //private bool in = false;

    private void Awake() {
        transition.Play("Base Layer.FadeIn");
    }

    public void ChangeScene(string _sceneName){
        StartCoroutine(LoadLevel(_sceneName));
        //SceneManager.LoadScene(_sceneName);
    }

    IEnumerator LoadLevel(string _sceneName) {
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(_sceneName);
        //transition.Play("Base Layer.FadeIn");
        //transition.ResetTrigger("FadeOut");
        //yield return new WaitForSeconds(transitionTime);
        //transition.ResetTrigger("FadeOut");
    }

}
