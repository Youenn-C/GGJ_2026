using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

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
    [SerializeField] private bool _isHealthy;
    [SerializeField] private bool _isPossessed;
    [SerializeField] private bool _isDead;

    void Start()
    {
        // Chargement des données depuis le ScriptableObject (DataAsset)  
        _memberSprite = _sectMemberData.memberSprite;
        _image.sprite = _memberSprite;
        _interviewsDialoguesLines = _sectMemberData.interviewsDialoguesLines;
        _gossipsDialoguesLines = _sectMemberData.gossipsDialoguesLines;
        _memberName = _sectMemberData.memberName;
        _isHealthy = _sectMemberData.isHealthy;
        _isPossessed = _sectMemberData.isPossessed;
        _isDead = _sectMemberData.isDead;
        
        // Auto-enregistrement dans le GameManager
        print("Owner : " + gameObject.name);
        print("Game Manager : " + S_GameManager.Instance.gameObject);
        S_GameManager.Instance.healthyMember.Add(this);
    }
}