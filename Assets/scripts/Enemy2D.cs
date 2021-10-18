using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direccion;
    public float speedWalk;
    public float speedRun;
    public GameObject target;
    public bool atacando;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }

    public void Comportamientos()
    {
        ani.SetBool("run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
       
        switch (rutina)
        {
            case 0:
                ani.SetBool("walk", false);
                break;
            case 1:
                direccion = Random.Range(0, 2);
                rutina++;
                break;

            case 2:

                switch (direccion)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                        break;

                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speedWalk * Time.deltaTime);
                        break;
                }
                ani.SetBool("walk", true);
        }


    }
}
    


