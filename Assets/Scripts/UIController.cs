using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public RectTransform startText;
    public RectTransform easyText;
    public RectTransform normalText;
    public RectTransform hardText;
    public RectTransform background;
    public RectTransform Polygone;

    public Button startButton;
    public bool gameStarted;
    public GameObject gameObjectsToActivateOnStart; // Başlatıldığında aktif olacak oyun nesneleri

    public RectTransform endText;
    public RectTransform tekrarOynaBut;
    public RectTransform backgroundEnd;

    public Button testButton;
    public GameObject gameEndControl;

    void Start()
    {
        startButton.onClick.AddListener(MoveUIElements);
        // Oyun nesnelerini aktifleştir
        startButton.onClick.AddListener(StartGame);
        // Oyun başladı bayrağını işaretle
        gameStarted = true;
    }

    void MoveUIElements()
    {
        float duration = 2f; // Hareket süresi

        // Start yazısı için hareket animasyonu
        startText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce);

        // Diğer yazılar için gecikmeli hareket animasyonları
        float delay = 0.2f;
        easyText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay);
        normalText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 2);
        hardText.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 3);

        // Arka plan için hareket animasyonu
        background.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 5);
        Polygone.DOAnchorPosY(750, duration).SetEase(Ease.OutBounce).SetDelay(delay * 2);
    }
    void StartGame()
    {
        // StartGameCoroutine işlevini başlat
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        yield return new WaitForSeconds(1.2f);

        // Oyun nesnelerini aktifleştir
        gameObjectsToActivateOnStart.SetActive(true);
    }
}


