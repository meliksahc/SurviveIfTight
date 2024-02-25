using UnityEngine;
using Photon.Pun;

public class dusman : MonoBehaviour
{
    public string takipEdilecekTag = "Karakter";
    public float hareketHizi = 1.4f;

    //PhotonView view;

    private void Start()
    {
        //view = GetComponent<PhotonView>();
    }
    void Update()
    {

        karakteriTakip();

    }
    [PunRPC]
    void karakteriTakip()
    {
        GameObject takipEdilecekObj = GameObject.FindGameObjectWithTag(takipEdilecekTag);
        transform.position = Vector3.MoveTowards(transform.position, takipEdilecekObj.transform.position, hareketHizi * Time.deltaTime);
    }
}
