using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject basAvantGauche;
    public GameObject basAvantDroite;
    public GameObject basArriereGauche;
    public GameObject basArriereDroite;

    public float vitesseRotation = 60f;

    //Contôle
    [Header("Contrôle")]
    public KeyCode toucheGauche = KeyCode.A;
    public KeyCode toucheDroite = KeyCode.D;
    public KeyCode toucheAvant = KeyCode.W;
    public KeyCode toucheArriere = KeyCode.S;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toucheDroite))
        {
            player.transform.RotateAround(basArriereDroite.transform.position, Vector3.forward, 90 );
        }
        if (Input.GetKeyDown(toucheGauche))
        {
            player.transform.RotateAround(basAvantGauche.transform.position,Vector3.back, 90 );
        }
        if (Input.GetKeyDown(toucheAvant))
        {
            player.transform.RotateAround(basArriereDroite.transform.position, Vector3.up, 90);
        }
        if (Input.GetKeyDown(toucheArriere))
        {
            player.transform.RotateAround(basAvantGauche.transform.position, Vector3.down, 90);
        }
    }
}
