using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;
    
    [Header("References"), Space(5)]
    public S_Demon _demonScript;
    public GameObject sectMemberDialogue;
    public TMP_Text sectMemberNameText;
    public TMP_Text sectMemberDialogueText;
    public Image actionPointGauge;
    
    [Header("Variables"), Space(5)]
    public S_SectMember actualDemon;
    public List<S_SectMember> healthyMember = new List<S_SectMember>();
    public List<S_SectMember> possessedMember = new List<S_SectMember>();
    public List<S_SectMember> deadMember = new List<S_SectMember>();
    public List<string> gossip =  new List<string>();
    [Space(5)]
    public Vector3 defaultCameraLocation;
    public Quaternion defaultCameraRotation;
    [Space(5)]
    public int currentDay = 1;
    public int nbrMaxDay = 4;
    public int nbrInteractionMax = 3;
    public int currentNbrInteraction;
    [Space(5)]
    public bool dayPhase = true;
    public bool inInteraction;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        Init_Demon();
        _demonScript = actualDemon.GetComponent<S_Demon>();

        actionPointGauge.fillAmount = 1f;
    }
    
    public void Init_Demon()
    {
        actualDemon = healthyMember[Random.Range(0, healthyMember.Count)];
        actualDemon.isTheDemon = true;
        actualDemon.Change_Into_Demon();
    }
    
    private void Change_Phase()
    {
        if (currentDay < nbrMaxDay) currentDay ++; // Raccourci pour augmenter un "int" ou un "float" de 1
    }

    public void Switch_Day_Cycle()
    {
        if (dayPhase)
        {
            dayPhase = !dayPhase; // Prends son inverse
            Change_Phase();
        }
        else
        {
            dayPhase = !dayPhase; // Prends son inverse
        }
    }

    public void Change_SectMember_State_For_Infected(S_SectMember currentSectMember)
    {
        foreach (var currentMember in healthyMember)
        {
            if (currentMember == currentSectMember)
            {
                healthyMember.Remove(currentMember);
                possessedMember.Add(currentMember);
            }
        }
    }
    
    public void Change_SectMember_State_For_Dead(S_SectMember currentSectMember)
    {
        foreach (var currentMember in healthyMember)
        {
            if (currentMember == currentSectMember)
            {
                healthyMember.Remove(currentMember);    
                deadMember.Add(currentMember);
            }
        }
    }
    
    public void Change_SectMember_State_For_Demon(S_SectMember currentSectMember)
    {
        foreach (var currentMember in healthyMember)
        {
            if (currentMember == currentSectMember)
            {
                healthyMember.Remove(currentMember);    
                actualDemon = currentMember;
            }
        }
    }

    public void Demon_Launch_Attack()
    {
        _demonScript.Draw_Action();
    }

    public void Open_And_Update_Dialogue_Datas(string name, string dialogue)
    {
        sectMemberDialogue.SetActive(true);
        sectMemberNameText.text = name;
        sectMemberDialogueText.text = dialogue;
    }
    
    public void Close_Dialogue_Datas()
    {
        sectMemberDialogue.SetActive(false);
    }
}
