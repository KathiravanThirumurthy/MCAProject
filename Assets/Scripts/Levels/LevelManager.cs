using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Button[] levelBtns;
   /* [SerializeField]
    private GameObject _loader;*/
    [SerializeField]
    private Button _resetBtn;
    [SerializeField]
    private Button _closePopBtn;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
         int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < levelBtns.Length; i++)
         {
              if (i + 2 > levelAt)
             levelBtns[i].interactable = false;
         }
        _resetBtn.onClick.AddListener(deletePref);
        _closePopBtn.onClick.AddListener(panelPopout);
    }


    public void ChangeScene(int sceneIndex)
    {

        // Debug.Log("sceneName to load: " + sceneIndex);
        StartCoroutine(loadAsynchronously(sceneIndex));
        // SceneManager.LoadScene(sceneIndex);
    }
    IEnumerator loadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            /*if(anim!=null)
            {
                _loader.SetActive(false);
            }*/
            yield return null;
        }

    }
    private void deletePref()
    {
        PlayerPrefs.DeleteAll();
    }
    private void panelPopout()
    {
        this.gameObject.SetActive(false);
    }

}
