using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class S_SectMember : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private S_SectMemberData _sectMemberData;
    [SerializeField] private Image _image;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private Sprite _memberSprite;
    [Space(5)]
    [SerializeField] private List<string> _interviewsDialoguesLines;
    [SerializeField] private List<string> _gossipsDialoguesLines;
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
        _image.sprite = _memberSprite;
        _interviewsDialoguesLines = _sectMemberData.interviewsDialoguesLines;
        _gossipsDialoguesLines = _sectMemberData.gossipsDialoguesLines;
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
        print("Element clicked : " + this.gameObject.name);
    }
}