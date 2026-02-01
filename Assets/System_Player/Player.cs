using System;
using NUnit.Framework.Internal;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Actions = 3;
    
    public int Hint = 1;

    private void Start()
    {
        Debug.Log(Actions);
        Debug.Log(Hint);
    }
}
