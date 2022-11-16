using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MainSceneButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        EditorSceneManager.LoadScene("PlayScene",UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void OnClickContinue()
    {
        SaveLoadManager.StartWithSave = true;
        EditorSceneManager.LoadScene("PlayScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    
    public void OnClickCredit()
    {

    }

    public void OnClickExit()
    {

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

}
