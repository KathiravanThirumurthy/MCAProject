using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Sprite lockedImage;
    [SerializeField]
    private Sprite unlockedImage;
    [SerializeField]
    private Button[] levelBtns;
   /* [SerializeField]
    private GameObject _loader;*/
    [SerializeField]
    private Button _resetBtn;
    /* [SerializeField]
     private Button _closePopBtn;*/
    [SerializeField]
    private Color _newColor;
    private Animator anim;
    public float desiredWidth = 3f; // Desired width of the sprite
    public float desiredHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for (int i = 0; i < levelBtns.Length; i++)
        {

            if (i + 1 > levelAt)
            {
                levelBtns[i].interactable = false;
                levelBtns[i].image.sprite = lockedImage;
                RectTransform rectTransform = levelBtns[i].GetComponent<RectTransform>();
                Text buttonText = levelBtns[i].GetComponentInChildren<Text>();
                buttonText.text = "";
                Vector2 sizeDelta = rectTransform.sizeDelta;
                sizeDelta.x = 100;
                sizeDelta.y = 100;
                rectTransform.sizeDelta = sizeDelta;

            }else
            {
                levelBtns[i].interactable = true;
                levelBtns[i].image.sprite = unlockedImage;
                RectTransform rectTransform = levelBtns[i].GetComponent<RectTransform>();
                Text buttonText = levelBtns[i].GetComponentInChildren<Text>();
               
                
                buttonText.text = (i + 1).ToString();
               // buttonText.color = _newColor;
                Vector2 sizeDelta = rectTransform.sizeDelta;
                sizeDelta.x = 100;
                sizeDelta.y = 100;
                rectTransform.sizeDelta = sizeDelta;
            }

            // _resetBtn.onClick.AddListener(deletePref);
        }
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
        public void deletePref()
        {
            // Debug.Log("Delete pref");
            PlayerPrefs.DeleteAll();

        }


    }
   
