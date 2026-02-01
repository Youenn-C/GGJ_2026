using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Add_To_DontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
