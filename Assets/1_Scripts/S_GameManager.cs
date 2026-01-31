using System;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;
    
    [Header("References"), Space(5)]
    [SerializeField] private S_Demon _demonScript;

    [Header("Variables"), Space(5)]
    public int currentPhase = 1;
    public int nbrMaxPhase;
    [Space(5)]
    public bool dayPhase;
    [Space(5)]
    public List<S_SectMember> healthyMember = new List<S_SectMember>();
    public List<S_SectMember> possessedMember = new List<S_SectMember>();
    public List<S_SectMember> deadMember = new List<S_SectMember>();
    
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

    public void Change_Phase()
    {
        currentPhase ++; // Raccourci pour augmenter un "int" ou un "float" de 1
        
    }

    private void Switch_Day_Cycle()
    {
        if (dayPhase)
        {
            dayPhase = !dayPhase; // Prends son inverse
        }
        else
        {
            dayPhase = !dayPhase; // Prends son inverse
            Change_Phase();
        }
    }

    public void Change_SectMember_State_For_Possessed(S_SectMember currentSectMember)
    {
        foreach (var currentMember in healthyMember)
        {
            if (currentMember == currentSectMember)
            {
                healthyMember.Remove(currentMember);
                possessedMember.Add(currentSectMember);
            }
        }
    }
    
    public void Change_SectMember_State_For_Dead(S_SectMember currentSectMember)
    {
        foreach (var currentMember in possessedMember)
        {
            if (currentMember == currentSectMember)
            {
                possessedMember.Remove(currentMember);
                deadMember.Add(currentSectMember);
            }
        }
    }
}
