using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public bool _isHealthy;
    public bool _isInfected;
    public bool _isDead;

    void Start()
    {
        // Chargement des données depuis le ScriptableObject (DataAsset)  
        _memberSprite = _sectMemberData.memberSprite;
        _image.sprite = _memberSprite;
        _interviewsDialoguesLines = _sectMemberData.interviewsDialoguesLines;
        _gossipsDialoguesLines = _sectMemberData.gossipsDialoguesLines;
        _memberName = _sectMemberData.memberName;
        _isHealthy = _sectMemberData.isHealthy;
        _isInfected = _sectMemberData.isInfected;
        _isDead = _sectMemberData.isDead;
        
        // Auto-enregistrement dans le GameManager
        print("Owner : " + gameObject.name);
        print("Game Manager : " + S_GameManager.Instance.gameObject);
        S_GameManager.Instance.healthyMember.Add(this);
    }

    public void BecomeInfected()
    {
        S_GameManager.Instance.Change_SectMember_State_For_Infected(this);
    }
    
    public void BecomeDeadMan()
    {
        S_GameManager.Instance.Change_SectMember_State_For_Dead(this);
    }
}