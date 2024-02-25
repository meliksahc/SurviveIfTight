using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : MonoBehaviourPun
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public Animator camAnim;
    public AudioSource atısSes;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        if (photonView.IsMine)
        {
            HandleWeaponControl();
        }
    }

    void HandleWeaponControl()
    {
        if (photonView.IsMine)
        {
            // Handles the weapon rotation
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                camAnim.SetTrigger("shake");
                atısSes.Play();
                // Photon ağı üzerinden ateş etmeyi senkronize et
                photonView.RPC("FireProjectile", RpcTarget.AllBuffered, shotPoint.position, transform.rotation);

                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    [PunRPC]
    void FireProjectile(Vector3 position, Quaternion rotation)
    {
        // Ateş etme işlemi tüm oyunculara bildirilir
        Instantiate(projectile, position, rotation);
    }
}
