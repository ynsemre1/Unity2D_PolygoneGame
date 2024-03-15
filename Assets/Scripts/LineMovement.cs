using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineMovement : MonoBehaviour
{
    public Transform[] soccerLines; // Alt objelerin referanslarını tutacak dizi
    public Transform[] endTransforms; // Hedef konumlar dizisi
    public GameObject[] objectsToColor; // Rengini değiştireceğimiz objelerin listesi


    void Start()
    {
        if (soccerLines.Length != endTransforms.Length)
        {
            Debug.LogError("soccerLines ve endTransforms dizileri aynı uzunlukta değil!");
            return;
        }

        for (int i = 0; i < soccerLines.Length; i++)
        {
            MoveLine(soccerLines[i], endTransforms[i]);
        }

        foreach (GameObject obj in objectsToColor)
        {
            ChangeObjectColor(obj, GetRandomColor());
        }
    }

    void MoveLine(Transform line, Transform endTransform)
    {
        float duration = Random.Range(0.4f, 1f); // Hareket süresi
        // DOTween hareket animasyonunu oluştur
        line.DOMove(endTransform.position, duration)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo); // Yoyo ile gidip gelme
    }

    Color GetRandomColor()
    {
        // Rastgele bir renk oluştur
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        return randomColor;
    }

    void ChangeObjectColor(GameObject obj, Color color)
    {
        // Renderer bileşenini al
        Renderer renderer = obj.GetComponent<Renderer>();

        // Eğer renderer bileşeni varsa
        if (renderer != null)
        {
            // Materyali al ve rengini değiştir
            Material material = renderer.material;
            material.color = color;
        }
        else
        {
            Debug.LogWarning(obj.name + " objesinde Renderer bileşeni bulunamadı!");
        }
    }
}
