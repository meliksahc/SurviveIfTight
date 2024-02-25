using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SüreSayim : MonoBehaviour
{
    public Text geriSayimText;
    public float geriSayimSure = 10f;

    [PunRPC]
    void Start()
    {
        // Geri sayımı başlat
        
            StartCoroutine(GeriSayimBaslat());
       
    }

    [PunRPC]
    IEnumerator GeriSayimBaslat()
    {
        float kalanSure = geriSayimSure;

        while (kalanSure > 0)
        {
            // Geri sayım metnini güncelle
            geriSayimText.text = Mathf.CeilToInt(kalanSure).ToString();

            // Bir saniye bekle
            yield return new WaitForSeconds(1f);

            // Kalan süreyi azalt
            kalanSure -= 1f;
        }

        // Geri sayım tamamlandığında metni sıfırla veya gizle
        geriSayimText.text = "START!";
        Destroy(gameObject, 2f);
    }
}
