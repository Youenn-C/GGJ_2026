using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DA_SectMember_", menuName = "Data_Sect_Members", order = 0)]
public class S_SectMemberData : ScriptableObject
{
    [Header("References"), Space(5)]
    public Sprite memberSprite;
    public List<string> interviewsDialoguesLines;
    public List<string> gossipsDialoguesLines;
    
    [Header("References"), Space(5)]
    public string memberName;
    public bool isHealthy = true;
    public bool isPossessed = false;
    public bool isDead = false;
}