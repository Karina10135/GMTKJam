using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class UINav : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    public Animator anim;
    public bool main;
    bool hover;
    int state;

    private void Start()
    {
        state = 0;
    }

    void Update()
    {
        if (main)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Count(false);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Count(true);
            }
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        HoverTrigger();
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
    }

    public void HoverTrigger()
    {
        anim.SetInteger("BarrelState", buttonID);
    }

    public void Count(bool dir)
    {
        if (!dir)
        {
            if(state == 1)
            {
                state = 3;
            }
            else
            {
                state--;
            }
        }
        else
        {
            if (state == 3)
            {
                state = 1;
            }
            else
            {
                state++;
            }
        }
        anim.SetInteger("BarrelState", state);
    }

}
