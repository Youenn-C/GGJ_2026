using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class S_SectMember : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private S_SectMemberData _sectMemberData;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private Sprite _memberSprite;
    [Space(5)]
    [SerializeField] private string _memberName;
    [Space(5)]
    public bool isTheDemon;
    public bool isHealthy;
    public bool isInfected;
    public bool isDead;


    void Start()
    {
        // Chargement des données depuis le ScriptableObject (DataAsset)  
        _memberSprite = _sectMemberData.memberSprite;
        _spriteRenderer.sprite = _memberSprite;
        _memberName = _sectMemberData.memberName;
        isHealthy = _sectMemberData.isHealthy;
        isInfected = _sectMemberData.isInfected;
        isDead = _sectMemberData.isDead;

        // Auto-enregistrement dans le GameManager
        S_GameManager.Instance.healthyMember.Add(this);
    }

    public void Change_Into_Demon()
    {
        gameObject.AddComponent<S_Demon>();
        S_GameManager.Instance.Change_SectMember_State_For_Demon(this);
    }

    public void BecomeInfected()
    {
        S_GameManager.Instance.Change_SectMember_State_For_Infected(this);
    }
    
    public void BecomeDeadMan()
    {
        S_GameManager.Instance.Change_SectMember_State_For_Dead(this);
    }

    public void OnMouseDown()
    {
        Debug.Log("Element clicked : " + this.gameObject.name);
    }
}