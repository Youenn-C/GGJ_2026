using UnityEngine;

public class S_Demon : MonoBehaviour
{
    void Start()
    {
        S_GameManager.Instance._demonScript = this;
    }
    
    public void Draw_Action()
    {
        int randomInt = Random.Range(0, 3);

        if (randomInt == 1)
        {
            Infect_Random_Member();
        }
        else if (randomInt == 2)
        {
            Kill_Random_Member();
        }
    }
    
    public void Infect_Random_Member()
    {
        if (S_GameManager.Instance.healthyMember.Count > 0)
        {
            S_SectMember tempMember = S_GameManager.Instance.healthyMember[Random.Range(0, S_GameManager.Instance.healthyMember.Count)];
            tempMember.isHealthy = false;
            tempMember.isInfected = true;
            tempMember.isDead = false;
            tempMember.BecomeInfected();
        }
    }
    
    public void Kill_Random_Member()
    {
        if (S_GameManager.Instance.healthyMember.Count > 0)
        {
            S_SectMember tempMember = S_GameManager.Instance.healthyMember[Random.Range(0, S_GameManager.Instance.healthyMember.Count)];
            tempMember.isHealthy = false;
            tempMember.isInfected = false;
            tempMember.isDead = true;
            tempMember.BecomeDeadMan();
        }
    }
}
