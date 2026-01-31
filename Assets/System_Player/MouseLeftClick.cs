using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseLeftClick : MonoBehaviour
{
    public GameObject player;
    public BoxCollider boxCollider;
    public Position Position;

    void OnMouseDown()
    {
        Vector3 moveDir = new Vector3(0, 0, 150);
        if (Input.GetMouseButton(1)) moveDir.z = +190f;
        Debug.Log("Youpi");
    }
}
