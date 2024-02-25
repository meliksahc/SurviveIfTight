using UnityEngine;
using Photon.Pun;

public class ChControll : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public GameObject cameraa;

    public SpriteRenderer spriteRenderBody;
    public SpriteRenderer spriteRenderHead;
    public SpriteRenderer spriteRenderWeapon;
    public SpriteRenderer spriteRenderLeg;
    public SpriteRenderer spriteRenderLegRight;

    PhotonView view;

    Animator animKarakter;
    private void Start()
    {
        animKarakter = GetComponent<Animator>();
        view = GetComponent<PhotonView>(); 
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (view.IsMine)
        {
            cameraa.SetActive(true);
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            ChangeFaceDirection();
        }
        
    }
    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
    private void ChangeFaceDirection()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            animKarakter.SetTrigger("run");
            
            spriteRenderBody.flipX = true;
            spriteRenderHead.flipX = true;
            spriteRenderWeapon.flipX = true;
            spriteRenderLeg.flipX = true;
            spriteRenderLegRight.flipX = true;
            // transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.y);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderBody.flipX = false;
            spriteRenderHead.flipX = false;
            spriteRenderWeapon.flipX = false;
            spriteRenderLeg.flipX = false;
            spriteRenderLegRight.flipX = false;
            //transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.y);
        }
    }
}