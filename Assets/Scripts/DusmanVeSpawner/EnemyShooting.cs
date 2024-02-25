using UnityEngine;
using Photon.Pun;

public class EnemyShooting : MonoBehaviourPun
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    public AudioSource atýsSes;

    public string takipEdilecekTag = "Karakter";
    public float hareketHizi = 0.1f;

    float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Karakter");
    }

    [PunRPC]
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        GameObject takipEdilecekObj = GameObject.FindGameObjectWithTag(takipEdilecekTag);

        if (distance < 100)
        {
            timer += Time.deltaTime;

            if (timer > 9f)
            {
                timer = 0;
                Shoot();
            }
        }

        if (takipEdilecekObj != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, takipEdilecekObj.transform.position, hareketHizi * Time.deltaTime);
        }

    }

    [PunRPC]
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
