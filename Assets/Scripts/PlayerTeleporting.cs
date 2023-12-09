using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporting : MonoBehaviour
{
    private GameObject Ct;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Ct != null)
            {

                transform.position = Ct.GetComponent<Teleporter>().GetTeleport().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleport"))
        {
            Ct = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            if(collision.gameObject==Ct)
            {
                Ct = null;

            }
        }
    }
}
