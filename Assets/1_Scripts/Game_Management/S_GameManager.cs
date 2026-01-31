using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;
    
    [Header("References"), Space(5)]
    public S_Demon _demonScript;
    
    [Header("Variables"), Space(5)]
    public int currentDay = 1;
    public int nbrMaxDay = 4;
    [Space(5)]
    public bool dayPhase = true;
    [Space(5)]
    public List<S_SectMember> healthyMember = new List<S_SectMember>();
    public List<S_SectMember> possessedMember = new List<S_SectMember>();
    public List<S_SectMember> deadMember = new List<S_SectMember>();
    public S_SectMember actualDemon;
    
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
    }
    
    public void Init_Demon()
    {
        actualDemon = healthyMember[Random.Range(0, healthyMember.Count)];
        actualDemon.isTheDemon = true;
        actualDemon.Change_Into_Demon();
    }
    
    
    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().name == "Lvl_Eglise")
        {
            SceneManager.LoadScene("Lvl_Rituel");
        }
        else if (SceneManager.GetActiveScene().name == "Lvl_Rituel")
        {
            SceneManager.LoadScene("Lvl_Eglise");  
        }
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
}
