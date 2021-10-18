using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomcontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("personaje"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            CamaraController.instance.activeRoom = transform.GetChild(0);
        }  
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("personaje"))
        {
            CamaraController.instance.activeRoom=transform.GetChild(0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("personaje"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
