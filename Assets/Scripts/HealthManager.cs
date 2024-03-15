using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public List<GameObject> hearts; // Kalp objelerinin listesi
    public int maxHealth = 3; // Başlangıçta sahip olduğu maksimum can miktarı
    private int currentHealth; // Mevcut can miktarı

    public GameObject ball;

    public bool gameEnded = false; // Oyunun sonlandırıldığı bilgisi

    public TextMeshProUGUI readyText; // Hazır metin nesnesi

    void Start()
    {
        currentHealth = maxHealth; // Başlangıçta canı maksimuma ayarla
    }
     
    void OnTriggerEnter2D(Collider2D other)
    {
        // Tetiklenen collider'ın etiketini kontrol et
        if (other.CompareTag("Player"))
        {
            // Kalp objelerinden birini yok et
            if (hearts.Count > 0)
            {
                Destroy(hearts[hearts.Count - 1]); // En üstteki kalbi yok et
                hearts.RemoveAt(hearts.Count - 1); // Listeden kalbi kaldır
                currentHealth--; // Can miktarını azalt
                ResetBallPosition(); // Topu başlangıç konumuna getir
                gameEnded = true;
            }
            else
            {
                Time.timeScale = 0;
            }
            Debug.Log("Remaining health: " + currentHealth);

            if (gameEnded)
            {
                EndGame();
            }
        }
    }

    void ResetBallPosition()
    {
        ball.transform.position = Vector3.zero; // Başlangıç konumu (0, 0, 0) olarak ayarlanır
        ball.transform.rotation = Quaternion.identity; // Başlangıç dönüşü (0, 0, 0, 1) olarak ayarlanır
    }

    public void EndGame()
    {
    Debug.Log("END GAME DEN GELIYORUM");
    StartCoroutine(FreezeGameForSeconds(3f));
    }

IEnumerator FreezeGameForSeconds(float duration)
{
    Time.timeScale = 0f; // Oyun zamanını durdur
    readyText.text = "3";
    yield return new WaitForSecondsRealtime(1f);

    readyText.text = "2";
    yield return new WaitForSecondsRealtime(1f);

    readyText.text = "1";
    yield return new WaitForSecondsRealtime(1f);

    readyText.text = "Ready!";
    yield return new WaitForSecondsRealtime(1f);
    readyText.text = "";
    Time.timeScale = 1f; // Oyun zamanını normale geri döndür
}
}
