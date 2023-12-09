using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerEffect : MonoBehaviour
{
    private GameObject DownPlatform;
    [SerializeField]
    private BoxCollider2D bc;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.S)) {
            
            if(DownPlatform != null)
            {
                StartCoroutine(DC());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Down")) 
        {
            DownPlatform=collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Down"))       
            {

                DownPlatform=null;
            
        }
    }
    private IEnumerator DC()
    {
        BoxCollider2D boxCollider2D=DownPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(bc,boxCollider2D);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(bc, boxCollider2D, false);


    }

}
