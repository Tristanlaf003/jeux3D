using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject basAvant;
    public GameObject basArriere;
    public GameObject basDroite;
    public GameObject basGauche;
    public GameObject hautAvant;
    public GameObject hautArriere;
    public GameObject hautDroite;
    public GameObject hautGauche;    
    public GameObject avantGauche;
    public GameObject avantDroite;
    public GameObject arriereGauche;
    public GameObject arriereDroite;

    private int[] positionPlayer = new int[6] { 1,2,5,6,4,3}; //Haut, Bas, Gauche, Droite, Avant, Arrière
    private GameObject[] arrete = new GameObject[4]; //Avant, Arrière, Gauche, Droite

    //Contôle
    [Header("Contrôle")]
    public KeyCode toucheGauche = KeyCode.A;
    public KeyCode toucheDroite = KeyCode.D;
    public KeyCode toucheAvant = KeyCode.W;
    public KeyCode toucheArriere = KeyCode.S;
    public KeyCode toucheReinitialiser = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    //Vérifrication coutinue pour vérifier si l'utilisateur à touché une touche
    void Update()
    {
        if (Input.GetKeyDown(toucheAvant))
        {
            player.transform.RotateAround(arrete[0].transform.position, Vector3.left, 90);
            updatePositionPlayer("Avant");
        }
        if (Input.GetKeyDown(toucheArriere))
        {
            player.transform.RotateAround(arrete[1].transform.position, Vector3.right, 90);
            updatePositionPlayer("Arriere");
        }
        if (Input.GetKeyDown(toucheGauche))
        {
            player.transform.RotateAround(arrete[2].transform.position, Vector3.back, 90);
            updatePositionPlayer("Gauche");
        }
        if (Input.GetKeyDown(toucheDroite))
        {
            player.transform.RotateAround(arrete[3].transform.position, Vector3.forward, 90);
            updatePositionPlayer("Droite");
        }
        if (Input.GetKeyDown(toucheReinitialiser))
        {
            player.transform.position = new Vector3(0, 1, 0);
            player.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            positionPlayer[0] = 1;
            positionPlayer[1] = 2;
            positionPlayer[2] = 5;
            positionPlayer[3] = 6;
            positionPlayer[4] = 4;
            positionPlayer[5] = 3;
        }
        updateArrete();
        //Debug.Log(arrete[0] + " " + arrete[1] + " " + arrete[2] + " " + arrete[3]);
        //Debug.Log(positionPlayer[0] + " " + positionPlayer[1] + " " + positionPlayer[2] + " " + positionPlayer[3] + " " + positionPlayer[4] + " " + positionPlayer[5]);
    }
    //Haut, Bas, Gauche, Droite, Avant, Arrière
    //private int[] positionPlayer = new int[6] {  6,    5,    1,       2,     4,     3}; 
    //  0     1     2        3      4      5
    //Function qui permet de modifier le tableau de position avec de nouvelle positon
    //selon la touche touché par l'utilisateur
    void updatePositionPlayer(string touche)
    {
        int[] positionPlayerTempo = new int[6];
        Array.Copy(positionPlayer, positionPlayerTempo, 6);

        if (touche == "Avant")
        {
            positionPlayer[0] = positionPlayerTempo[4];
            positionPlayer[1] = positionPlayerTempo[5];
            positionPlayer[4] = positionPlayerTempo[1];
            positionPlayer[5] = positionPlayerTempo[0];

        }else if(touche == "Arriere")
        {
            positionPlayer[0] = positionPlayerTempo[5];
            positionPlayer[1] = positionPlayerTempo[4];
            positionPlayer[4] = positionPlayerTempo[0];
            positionPlayer[5] = positionPlayerTempo[1];
        }
        else if(touche == "Gauche")
        {
            positionPlayer[0] = positionPlayerTempo[3];
            positionPlayer[1] = positionPlayerTempo[2];
            positionPlayer[2] = positionPlayerTempo[0];
            positionPlayer[3] = positionPlayerTempo[1];
        }
        else if(touche == "Droite")
        {
            positionPlayer[0] = positionPlayerTempo[2];
            positionPlayer[1] = positionPlayerTempo[3];
            positionPlayer[2] = positionPlayerTempo[1];
            positionPlayer[3] = positionPlayerTempo[0];
        }
    }

    //Function qui va permettre de mettre les bons arrêtes selon la face qui touche le sol.
    //Avant, Arrière, Gauche, Droite
    // 0       1        2      3
    //basAvant; basArriere; basDroite; basGauche; hautAvant; hautArriere; hautDroite; hautGauche; avantGauche; avantDroite; arriereGauche; arriereDroite;
    //int[] positionPlayer = new int[6] { 1,2,5,6,4,3}; //Haut, Bas, Gauche, Droite, Avant, Arrière
    void updateArrete()
    {
        if (positionPlayer[1] == 1)
        {
            if (positionPlayer[2] == 5)
            {
                arrete[0] = hautArriere;
                arrete[1] = hautAvant;
                arrete[2] = hautGauche;
                arrete[3] = hautDroite;
            }
            else if (positionPlayer[2] == 4)
            {
                arrete[0] = hautDroite;
                arrete[1] = hautGauche;
                arrete[2] = hautArriere;
                arrete[3] = hautAvant;
            }
            else if (positionPlayer[2] == 6)
            {
                arrete[0] = hautAvant;
                arrete[1] = hautArriere;
                arrete[2] = hautDroite;
                arrete[3] = hautGauche;
            }
            else if (positionPlayer[2] == 3)
            {
                arrete[0] = hautGauche;
                arrete[1] = hautDroite;
                arrete[2] = hautAvant;
                arrete[3] = hautArriere;
            }
        } else if (positionPlayer[1] == 2)
        {
            if(positionPlayer[2] == 5)
            {
                arrete[0] = basAvant;
                arrete[1] = basArriere;
                arrete[2] = basGauche;
                arrete[3] = basDroite;
            }else if(positionPlayer[2] == 3)
            {
                arrete[0] = basDroite;
                arrete[1] = basGauche;
                arrete[2] = basAvant;
                arrete[3] = basArriere;
            }else if(positionPlayer[2] == 6)
            {
                arrete[0] = basArriere;
                arrete[1] = basAvant;
                arrete[2] = basDroite;
                arrete[3] = basGauche;
            }else if(positionPlayer[2] == 4)
            {
                arrete[0] = basGauche;
                arrete[1] = basDroite;
                arrete[2] = basArriere;
                arrete[3] = basAvant;
            }

        }
        else if (positionPlayer[1] == 3)
        {
            if (positionPlayer[2] == 5)
            {
                arrete[0] = hautAvant;
                arrete[1] = basAvant;
                arrete[2] = arriereGauche;
                arrete[3] = arriereDroite;
            }
            else if (positionPlayer[2] == 1)
            {
                arrete[0] = arriereDroite;
                arrete[1] = arriereGauche;
                arrete[2] = hautAvant;
                arrete[3] = basAvant;
            }
            else if (positionPlayer[2] == 6)
            {
                arrete[0] = basAvant;
                arrete[1] = hautAvant;
                arrete[2] = arriereDroite;
                arrete[3] = arriereGauche;
            }
            else if (positionPlayer[2] == 2)
            {
                arrete[0] = arriereGauche;
                arrete[1] = arriereDroite;
                arrete[2] = basAvant;
                arrete[3] = hautAvant;
            }
        }
        else if (positionPlayer[1] == 4)
        {
            if (positionPlayer[2] == 5)
            {
                arrete[0] = basArriere;
                arrete[1] = hautArriere;
                arrete[2] = avantGauche;
                arrete[3] = avantDroite;
            }
            else if (positionPlayer[2] == 2)
            {
                arrete[0] = avantDroite;
                arrete[1] = avantGauche;
                arrete[2] = basArriere;
                arrete[3] = hautArriere;
            }
            else if (positionPlayer[2] == 6)
            {
                arrete[0] = hautArriere;
                arrete[1] = basArriere;
                arrete[2] = avantDroite;
                arrete[3] = avantGauche;
            }
            else if (positionPlayer[2] == 1)
            {
                arrete[0] = avantGauche;
                arrete[1] = avantDroite;
                arrete[2] = hautArriere;
                arrete[3] = basArriere;
            }
        }
        else if (positionPlayer[1] == 5)
        {
            if (positionPlayer[2] == 1)
            {
                arrete[0] = arriereGauche;
                arrete[1] = avantGauche;
                arrete[2] = hautGauche;
                arrete[3] = basGauche;
            }
            else if (positionPlayer[2] == 3)
            {
                arrete[0] = basGauche;
                arrete[1] = hautGauche;
                arrete[2] = arriereGauche;
                arrete[3] = avantGauche;
            }
            else if (positionPlayer[2] == 2)
            {
                arrete[0] = avantGauche;
                arrete[1] = arriereGauche;
                arrete[2] = basGauche;
                arrete[3] = hautGauche;
            }
            else if (positionPlayer[2] == 4)
            {
                arrete[0] = hautGauche;
                arrete[1] = basGauche;
                arrete[2] = avantGauche;
                arrete[3] = arriereGauche;
            }
        }
        else if (positionPlayer[1] == 6)
        {
            if (positionPlayer[2] == 3)
            {
                arrete[0] = hautDroite;
                arrete[1] = basDroite;
                arrete[2] = arriereDroite;
                arrete[3] = avantDroite;
            }
            else if (positionPlayer[2] == 1)
            {
                arrete[0] = avantDroite;
                arrete[1] = arriereDroite;
                arrete[2] = hautDroite;
                arrete[3] = basDroite;
            }
            else if (positionPlayer[2] == 4)
            {
                arrete[0] = basDroite;
                arrete[1] = hautDroite;
                arrete[2] = avantDroite;
                arrete[3] = arriereDroite;
            }
            else if (positionPlayer[2] == 2)
            {
                arrete[0] = arriereDroite;
                arrete[1] = avantDroite;
                arrete[2] = basDroite;
                arrete[3] = hautDroite;
            }
        }
    }
}
