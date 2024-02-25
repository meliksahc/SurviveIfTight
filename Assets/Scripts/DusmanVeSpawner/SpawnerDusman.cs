using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class SpawnerDusman : MonoBehaviour
{
    public GameObject[] objeler; 
    public Transform spawnPozisyonu;
    
    float timer;
    float waveTimer;

    float DusmanSpawnS�resi = 20;

    private void Update()
    {   
        dusmanCag�r(); 
    }

    [PunRPC]
    void dusmanCag�r()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;
        if (timer > DusmanSpawnS�resi)
        {
            GameObject secilenObj = objeler[Random.Range(0, objeler.Length)];
            Instantiate(secilenObj, spawnPozisyonu.position, Quaternion.identity);

            timer = 0;
        }

        if (waveTimer > 30 && DusmanSpawnS�resi >= 10)
        {
            DusmanSpawnS�resi -= 1;
            waveTimer = 0;
        }
    }


}
