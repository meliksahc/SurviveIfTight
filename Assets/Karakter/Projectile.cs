using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage = 1;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }

            DestroyProjectile();
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
