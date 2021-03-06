﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public ParticleSystem deathVFX;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.audioManager.FadeSound();
            Transform pos = other.gameObject.transform;
            GameManager.gm.Death();
            Destroy(other.gameObject);
            if (deathVFX != null)
            {
                var blood = Instantiate(deathVFX, pos);
                blood.transform.SetParent(null);
            }

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        AudioManager.audioManager.FadeSound();
    //        Transform pos = other.gameObject.transform;
    //        other.GetComponent<FauxGravityBody>().attractor = GameManager.gm.Moon.GetComponent<FauxGravityAttractor>();
    //        GameManager.gm.Barrel.GetComponent<BarrelControl>().Death();
    //        other.GetComponent<PlayerController>().enabled = false;
    //        Destroy(other.gameObject);
    //        if(deathVFX != null)
    //        {
    //            var blood = Instantiate(deathVFX, pos);
    //            blood.transform.SetParent(null);
    //        }

    //    }
    //}

}
