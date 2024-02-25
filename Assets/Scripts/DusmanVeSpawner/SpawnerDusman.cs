using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class SpawnerDusman : MonoBehaviour
{
    public GameObject[] objeler; 
    public Transform spawnPozisyonu;
    
    float timer;
    float waveTimer;

    float DusmanSpawnSüresi = 20;

    private void Update()
    {   
        dusmanCagýr(); 
    }

    [PunRPC]
    void dusmanCagýr()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;
        if (timer > DusmanSpawnSüresi)
        {
            GameObject secilenObj = objeler[Random.Range(0, objeler.Length)];
            Instantiate(secilenObj, spawnPozisyonu.position, Quaternion.identity);

            timer = 0;
        }

        if (waveTimer > 30 && DusmanSpawnSüresi >= 10)
        {
            DusmanSpawnSüresi -= 1;
            waveTimer = 0;
        }
    }


}
