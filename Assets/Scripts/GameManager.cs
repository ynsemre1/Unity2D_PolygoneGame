using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Çarpışmanın olduğu objenin etiketini kontrol et
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            // Oyunu bitirme işlemini gerçekleştir
            EndGame();
        }
    }

    void EndGame()
    {
        // Oyunu yeniden başlat
        Debug.Log("sa");
    }
}
