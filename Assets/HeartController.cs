using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public List<GameObject> hearts; // Kalp objelerinin listesi
    public int maxHealth = 3; // Başlangıçta sahip olduğu maksimum can miktarı
    private int currentHealth; // Mevcut can miktarı

    public GameObject ball;

    public bool gameEnded = false; // Oyunun sonlandırıldığı bilgisi

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
                StartCoroutine(FreezeGameForSeconds(2f)); // Oyunu 2 saniye boyunca dondur
                gameEnded = true;
            }
            else
            {
                Time.timeScale = 0;
            }
            Debug.Log("Remaining health: " + currentHealth);

            if (!gameEnded)
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
        gameEnded = false;
        Debug.Log(gameEnded);
    }

    IEnumerator FreezeGameForSeconds(float duration)
    {
        Time.timeScale = 0f; // Oyun zamanını durdur
        yield return new WaitForSecondsRealtime(duration); // Belirli bir süre beklet
        Time.timeScale = 1f; // Oyun zamanını normale geri döndür
    }
}

