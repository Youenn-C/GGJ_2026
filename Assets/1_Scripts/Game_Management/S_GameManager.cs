using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public List<S_SectMember> allAliveMember = new List<S_SectMember>();
    public List<S_SectMember> healthyMember = new List<S_SectMember>();
    public List<S_SectMember> infectedMember = new List<S_SectMember>();
    public List<S_SectMember> deadMember = new List<S_SectMember>();
    [Space(5)]
    public List<string> gossip =  new List<string>();
    [Space(5)]
    public GameObject sacrificeSelection;
    [Space(5)]
    public Vector3 defaultCameraLocation;
    public Quaternion defaultCameraRotation;
    [Space(5)]
    public int currentDay = 1;
    public int nbrMaxDay = 4;
    public int currentDaySequence = 1;
    public int maxDaySequences = 3;
    public int nbrInteractionMax = 3;
    public int currentNbrInteraction;
    [Space(5)]
    public bool dayPhase = true;
    public bool inInteraction = true;
    public bool canInteract = true;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    void Start()
    {
        Init_Demon();
        _demonScript = actualDemon.GetComponent<S_Demon>();
        actionPointGauge.fillAmount = 1f;
        Change_Current_Sequence();
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

    public void Change_SectMember_State_For_Infected(S_SectMember currentSectMember)
    {
        foreach (var currentMember in healthyMember)
        {
            if (currentMember == currentSectMember)
            {
                healthyMember.Remove(currentMember);
                infectedMember.Add(currentMember);
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


    public void Change_Current_Sequence()
    {
        canInteract = false;
        currentDaySequence++;
        
        if (currentDaySequence == 1)
        {
            Launch_Sequence_One();
        }
        else if (currentDaySequence == 2)
        {
            Launch_Sequence_Two();
        }
        else
        {
            Launch_Sequence_Three();
        }
        
        canInteract = true;
    }

    public void Launch_Sequence_One()
    {
        foreach (var member in allAliveMember)
        {
            S_GameManager.Instance.actionPointGauge.fillAmount = 1;
            member.Update_Life_State();
        }
    }
    
    public void Launch_Sequence_Two()
    {
        sacrificeSelection.SetActive(true);
    }
    
    public void Launch_Sequence_Three()
    {
        sacrificeSelection.SetActive(false);
        Demon_Launch_Attack();
        currentDaySequence = 1;
        StartCoroutine(Time_Before_Sequence_One());
    }

    IEnumerator Time_Before_Sequence_One()
    {
        yield return new WaitForSeconds(3f);
        Change_Current_Sequence();
    }
}
