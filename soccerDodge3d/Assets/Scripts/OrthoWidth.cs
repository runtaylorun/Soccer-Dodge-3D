using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoWidth : MonoBehaviour
{
    private void Awake()
    {
        Camera.main.orthographicSize = (20.0f / Screen.width * Screen.height / 2.0f);

    }
    private void Update()
    {
        Camera.main.orthographicSize = (20.0f / Screen.width * Screen.height / 2.0f);

    }
}
