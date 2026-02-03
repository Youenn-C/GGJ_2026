using UnityEngine;
using UnityEngine.UI;

public class S_ScrificeSlot : MonoBehaviour
{
    public S_SectMember targetMember;
    public Button button;
    
    public void Scrifice()
    {
        targetMember.isDead = true;
        button.interactable = false;
    }
}
