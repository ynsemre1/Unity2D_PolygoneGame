using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject objectToShow;

    void Start()
    {
        // Butonun `onClick` olayına "ShowObject" fonksiyonunu ekleyin
        GetComponent<Button>().onClick.AddListener(ShowObject);
    }

    // Butona tıklandığında çağrılacak fonksiyon
    public void ShowObject()
    {
        // objectToShow adlı nesneyi etkinleştir
        objectToShow.SetActive(true);
    }
}

