using UnityEngine;

public class S_Demon : MonoBehaviour
{

    public void Draw_Action()
    {
        int randomInt = Random.Range(0, 3);

        if (randomInt == 0)
        {
            print("Nothing Append");
        }
        else if (randomInt == 1)
        {
            Infect_Random_Member();
        }
        else
        {
            Kill_Random_Member();
        }
    }
    
    private void Infect_Random_Member()
    {
        S_SectMember tempMember = S_GameManager.Instance.healthyMember[Random.Range(0, S_GameManager.Instance.healthyMember.Count)];
        S_GameManager.Instance.Change_SectMember_State_For_Possessed(tempMember);
    }
    
    private void Kill_Random_Member()
    {
        S_SectMember tempMember = S_GameManager.Instance.healthyMember[Random.Range(0, S_GameManager.Instance.healthyMember.Count)];
        S_GameManager.Instance.Change_SectMember_State_For_Dead(tempMember);
    }
}
