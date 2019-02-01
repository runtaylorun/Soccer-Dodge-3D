using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
    private ScrollRect scrollRect;
    private Transform[] parent;
    public GameObject skinUi;
    void Start()
    {
        scrollRect = gameObject.GetComponent<ScrollRect>();
        parent = scrollRect.transform.GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (skinUi.activeSelf)
        {
            isItemInFocus();
        }
    }

    private void isItemInFocus()
    {
        foreach(Transform child in parent)
        {
            if(child.name == "Player")
            {

            }
        }
    }
}
