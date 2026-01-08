using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public UXManager uxMgr;
    public TextMeshProUGUI MessageText;
    IEnumerator TriggerUI(int ID)
    {
        yield return new WaitForSeconds(2f);
        DisplayUIMsg(ID);
    }

    public void DisplayUIMsg(int ID)
    {
        switch(ID)
        {
            case 1: MessageText.text = "Welcome to the Fire Safety Zone.Look around to familiarize yourself with the environment.";
                break;

            case 2: MessageText.text = "Alert. Fire detected in the waste bin. Locate and grab the fire extinguisher immediately.";
                break;


            case 11:
                MessageText.text = "Move to the marked location.";
                break;

            case 3:
                MessageText.text = "Good. Remember the P.A.S.S. technique.First step: Pull the pin to unlock the handle.";
                break;

            case 4:
                MessageText.text = "Pin removed. Now, aim for the nozzle at the base of the fire, not the flames.";
                break;

            case 5:
                MessageText.text = "Target acquired. Squeeze the handle to release the agent.";
                break;

            case 6:
                MessageText.text = "Discharging. Now, sweep the nozzle side to side to cover the fuel source";
                break;

            case 7:
                MessageText.text = "Fire extinguished. Great work following the P.A.S.S.protocol. The area is secure.";
                break;

            case 8:
                MessageText.text = "Critical Danger! The fire is out of control! Drop the extinguisher and evacuate immediately! Find the Exit!";
                break;

            case 9:
                MessageText.text = "Don't fight it! Get to the Emergency Door! Move!";
                break;

            case 10:
                MessageText.text = "Evacuation was successful. You made the right choice to abandon the fire.";
                break;
        }
    }
}
