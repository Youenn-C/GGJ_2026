using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DA_SectMember_", menuName = "Data_Sect_Members", order = 0)]
public class S_SectMemberData : ScriptableObject
{
    [Header("References"), Space(5)]
    public Sprite memberSprite;
    
    [Header("Variables"), Space(5)]
    public string memberName;
    public bool isHealthy = true;
    public bool isInfected = false;
    public bool isDead = false;
}