using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrumNav : MonoBehaviour
{
    public Image[] buttons;
    public GameObject creditsPanel;
    public GameObject sceneChanger;
    public Color highlightedColor;
    public Color normalColor;

    public Animator anim;
    public bool trigger;
    public bool none;
    bool credits;
    public int currentButton;

    public void Update()
    {

        if (credits)
        {
            if (Input.anyKeyDown)
            {
                creditsPanel.SetActive(false);
                credits = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            EnterButton();
        }

        if (trigger)
        {
            SelectButton();
        }

        if (none)
        {
            NoButton();
        }
    }

    public void NoButton()
    {
        trigger = false;
        foreach (Image button in buttons)
        {
            button.color = normalColor;
        }
        none = false;
    }

    public void SelectButton()
    {
        none = false;
        int i = anim.GetInteger("BarrelState");
        currentButton = i;
        buttons[i-1].color = highlightedColor;
        trigger = true;
    }

    public void EnterButton()
    {
        if (currentButton == 0) { return; }
        if (currentButton == 1)
        {
            sceneChanger.GetComponent<SceneChanger>().ChangeScene("Main");
        }
        if (currentButton == 2)
        {
            creditsPanel.SetActive(true);
            credits = true;
        }
        if (currentButton == 3)
        {
            sceneChanger.GetComponent<SceneChanger>().QuitGame();
        }
    }

}
