using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private Button _button;
    private Scrollbar _scrollbar;
    private AsyncOperation _async;
	 
	void Start () {
        _button = GameObject.Find("Canvas/Button").GetComponent<Button>();
        _scrollbar= GameObject.Find("Canvas/Scrollbar").GetComponent<Scrollbar>();
        _button.onClick.AddListener(delegate () { ShowP("Scene02"); });
	}

    public void ShowP(string sceneName)
    {
        StartCoroutine("loadScene", sceneName);
    }

    IEnumerator loadScene(string sceneName)
    {
        _async = SceneManager.LoadSceneAsync(sceneName);
        _async.allowSceneActivation = false;
        yield return _async;
    }

    

    private int _nowProgress = 0;


    // Update is called once per frame
    void Update () {
        if (_async == null)
        { return; }
        int toPogress;
        if (_async.progress < 0.9f)
        {
            toPogress = (int)_async.progress * 100;
        }
        else {
            toPogress = 100;
            
        }

        if (_nowProgress < toPogress)
        {
            _nowProgress++;
        }
        Debug.Log( "现在的进度是" + _nowProgress + "%");
        _scrollbar.value = _nowProgress*0.01f;
        if (_nowProgress == 100)
        {
            _async.allowSceneActivation = true;
        }
       
	}
}
