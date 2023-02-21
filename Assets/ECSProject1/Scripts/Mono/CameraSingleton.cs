using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleton : MonoBehaviour
{
    public static Camera Instance;
    public Camera Camera;
    private void Awake()
    {
        Instance = Camera;
    }

    private void OnValidate()
    {
        
    }
}
