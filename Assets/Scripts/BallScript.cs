using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ballRigidbody; // Topun Rigidbody bileşeni
    public float baslangicKuvvet; // Topun baslangic itme kuvveti
    public HealthManager[] targetScriptReference; //HealthManager scripti için referans

    bool baslangicItildi = false; // Başlangıçta itme işlemi gerçekleşti mi?

    void Update()
    {
        // BallScript içerisinde HealthManager referansına ulaş
        // Bu referans üzerinden EndGame fonksiyonunu çağırabilirsin
        foreach (HealthManager healthManager in targetScriptReference)
        {
            if (healthManager.gameEnded)
            {
                // Oyun bitti
                BaslangicYonu();
            }
        }
    }

    void BaslangicYonu()
    {
        if (!baslangicItildi)
        {
            // Rastgele bir yön belirle (sağa veya sola)
            float direction = Random.Range(0, 2) == 0 ? -1 : 1;

            // Başlangıç kuvvetini hesapla
            Vector2 initialForce = new Vector2(direction * baslangicKuvvet, 0f);

            // Topa başlangıç kuvvetini uygula
            ballRigidbody.AddForce(initialForce, ForceMode2D.Impulse);

            baslangicItildi = true; // Başlangıç itme işlemi tamamlandı
            }
    }
}
