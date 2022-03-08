using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public int startlives = 5;
    internal int lifenum = 1;
    public Canvas gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lifenum = startlives;
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifenum == 0)
        {
            GetComponent<PlatformCharacterMovement>().lockMovement = true;
            gameOver.enabled = true;
        }
    }
}
