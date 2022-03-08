using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCharacterMovement : MonoBehaviour
{
    public Transform startpoint;
    public float rightspeed = 1;
    public float leftspeed = 1;
    public float jumpforce = 1;
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    public float killzone = 0;
    public bool lockMovement = false;
    public Sprite walksprite;
    public Sprite jumpsprite;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = walksprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (lockMovement != true)
        {
            if (Input.GetKey("d"))
            {
                rigidbody.velocity = new Vector2(rightspeed, rigidbody.velocity.y);
                sprite.flipX = false;
            }

            else if (Input.GetKey("a"))
            {
                rigidbody.velocity = new Vector2(-leftspeed, rigidbody.velocity.y);
                sprite.flipX = true;
            }
            else
            {
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }

            if (Input.GetKey("space") && rigidbody.velocity.y == 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
                sprite.sprite = jumpsprite;
            }
            if (rigidbody.velocity.y == 0)
            {
                sprite.sprite = walksprite;
            }
        }

        if (transform.position.y < killzone)
        {
            Reset();
        }
    }

    public void Reset()
    {
        transform.position = startpoint.position;
        rigidbody.velocity = Vector2.zero;
        GetComponent<CharacterInfo>().lifenum--;
    }
}
