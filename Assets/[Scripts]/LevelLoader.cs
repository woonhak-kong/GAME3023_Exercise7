using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadBattleScene()
    {
        LoadLevelByName("BattleScene");
    }


    public void LoadLevelByName(string name)
    {
        FindObjectOfType<DataTransfer>().SetPlayerStatusForBattle();
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
    
}
