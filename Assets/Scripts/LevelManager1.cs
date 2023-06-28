using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager1: MonoBehaviour
{
    [SerializeField]
    private Button[] levelBtns;
    // Start is called before the first frame update
    void Start()
    {
       /* for (int i = 0; i < levelBtns.Length; i++)
        {
            if (i + 2 > levelAt)
                levelBtns[i].interactable = false;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
