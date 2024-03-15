using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public void DG (){
    // UI panelinin yukarı doğru kayması ve kaybolması için animasyonu başlat
    gameObject.transform.DOMoveY(Screen.height, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
        {

    });
    }
}
