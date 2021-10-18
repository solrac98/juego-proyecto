using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform personaje;
    public Transform activeRoom;
    public static CamaraController instance;
    [Range(-10,10)]
    public float minModX = 3.5f, maxModX = -3.5f, minModY = 2f, maxModY =-2f;
    public float dampSpeed;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activeRoom = personaje;
        transform.position = new Vector3(personaje.position.x, personaje.position.y, -1);

    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(personaje.position.x, minPosX, maxPosX),
            Mathf.Clamp(personaje.position.y, minPosY, maxPosY),
            Mathf.Clamp(personaje.position.z, -10f, -10f));
        Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);
        transform.position = smoothPos;
        
    }
    

    }


