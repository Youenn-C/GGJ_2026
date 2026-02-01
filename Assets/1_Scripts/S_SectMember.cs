using UnityEngine;

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
    public bool inInteraction;
    
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
        GameObject currentCamera = Camera.main.gameObject;
        
        if (!S_GameManager.Instance.inInteraction && S_GameManager.Instance.currentNbrInteraction < S_GameManager.Instance.nbrInteractionMax)
        {
            S_GameManager.Instance.inInteraction = true;
            S_GameManager.Instance.currentNbrInteraction++;
            S_GameManager.Instance.actionPointGauge.fillAmount -= 1/3f;
            currentCamera.transform.LookAt(gameObject.transform);
            currentCamera.transform.position = Vector3.Lerp(currentCamera.transform.position, gameObject.transform.position, 0.8f);
            S_GameManager.Instance.Open_And_Update_Dialogue_Datas(_memberName, S_GameManager.Instance.gossip[Random.Range(0, S_GameManager.Instance.gossip.Count)]);
        }

        else
        {
            currentCamera.transform.position = new Vector3(S_GameManager.Instance.defaultCameraLocation.x, S_GameManager.Instance.defaultCameraLocation.y, S_GameManager.Instance.defaultCameraLocation.z);
            currentCamera.transform.rotation = new Quaternion(S_GameManager.Instance.defaultCameraRotation.x, S_GameManager.Instance.defaultCameraRotation.y, S_GameManager.Instance.defaultCameraRotation.z, S_GameManager.Instance.defaultCameraRotation.w);
            S_GameManager.Instance.Close_Dialogue_Datas();
            S_GameManager.Instance.inInteraction = false;
        }
        
        if (S_GameManager.Instance.currentNbrInteraction == S_GameManager.Instance.nbrInteractionMax)
        {
            S_GameManager.Instance.currentDaySequence++;
            S_GameManager.Instance.Change_Current_Sequence();
        }
    }

    public void Update_Life_State()
    {
        if (isDead) Destroy(this);
    }
}