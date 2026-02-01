using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UIElements;
using MouseButton = Unity.VisualScripting.MouseButton;

public class MouseLeftClick : MonoBehaviour
{
    public GameObject GOCamera;
    //Zoom when left click
    void OnMouseDown()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);
        
        if (Input.GetKey(KeyCode.Mouse0)) moveDir.z = +190f;
        Debug.Log("Youpi moved");
        
        float moveSpeed = 15f;
        GOCamera.transform.position+= moveDir * moveSpeed * Time.deltaTime;
    }
}
