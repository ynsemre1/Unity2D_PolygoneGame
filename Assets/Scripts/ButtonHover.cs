using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    // Gizlemek veya görünür yapmak istediğiniz GameObject
    public GameObject targetObject;

    // GameObject'i görünür yapmak için
    public void ShowObject()
    {
        gameObject.SetActive(true);
    }

    public void HideObject()
    {
        gameObject.SetActive(false);
    }
}
