using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Moon;
    public GameObject Barrel;

    public static GameManager gm;

    private void Start()
    {
        gm = this;
    }

}
