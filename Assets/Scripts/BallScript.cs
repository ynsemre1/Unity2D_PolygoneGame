using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpışan objenin etiketini kontrol et
        if (collision.gameObject.CompareTag("Finish"))
        {
            // Oyunu bitirme işlemini gerçekleştir
            EndGame();
        }
    }

    void EndGame()
    {
        // Oyunu yeniden başlat
        Destroy(gameObject);
    }
}
