using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float squashheight = 0;
    private bool isSquashed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlatformCharacterMovement pm = other.gameObject.GetComponent<PlatformCharacterMovement>();
        if (pm && !isSquashed)
        {
            if (other.transform.position.y - transform.position.y > squashheight)
            {
                Kill();
                isSquashed = true;
            }
            else
            {
                pm.Reset();
            }
            
        }
    }

    public void Kill()
    {
        Destroy(gameObject, 0.25f);
        var squish = new Vector3(transform.localScale.x, 0.2f, transform.localScale.z);
        transform.localScale = squish;
        var scalemovement = new Vector3(transform.position.x, transform.position.y - 0.34f, transform.position.z);
        transform.position = scalemovement;
    }
}
