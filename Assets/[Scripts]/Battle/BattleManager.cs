using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public enum Turn
{
    PLAYER,
    ENEMY
}
public class BattleManager : MonoBehaviour
{
    

    public BattleSceneManager battleSceneManager;

    public Character Player;
    public Character Enemy;

    public Turn CurrentTurn;

    // Start is called before the first frame update
    private void Awake()
    {
        // set Player
        Player.status = FindObjectOfType<DataTransfer>().playerStatus;
    }
    void Start()
    {
        
        foreach (var skill in Player.status.SkillList)
        {
            GameObject btn = Instantiate(battleSceneManager.SkillButtonPrefab, battleSceneManager.PlayerSkillPannel.transform);
            btn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = skill.skillName;
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                battleSceneManager.PlayerDesc.text = skill.Effect;
                StartCoroutine(SetTurnSetting());
            });

        }

        foreach (var skill in Enemy.status.SkillList)
        {
            GameObject btn = Instantiate(battleSceneManager.SkillButtonPrefab, battleSceneManager.EnemySkillPannel.transform);
            btn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = skill.skillName;
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                battleSceneManager.EnemyDesc.text = skill.Effect;
                StartCoroutine(SetTurnSetting());
            });
        }

        CurrentTurn = Turn.PLAYER;
        battleSceneManager.SetTurn(CurrentTurn);
    }
    public IEnumerator SetTurnSetting()
    {
        battleSceneManager.SetClickPannelDisable(CurrentTurn);
        ChangedTurn();
        yield return new WaitForSeconds(2.0f);
        battleSceneManager.PlayerDesc.text = "";
        battleSceneManager.EnemyDesc.text = "";
        
        battleSceneManager.SetTurn(CurrentTurn);
    }

    public void ChangedTurn()
    {
        CurrentTurn = CurrentTurn == Turn.PLAYER ? Turn.ENEMY : Turn.PLAYER;
    }
}
