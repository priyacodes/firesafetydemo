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

            case 2: MessageText.text = "Alert!!! \n\nFire detected in the warehouse. \nLocate and grab the fire extinguisher immediately.";
                break;


            case 11:
                MessageText.text = "Fire Extinguisher grabbed. \n\n Now, move to the marked location.";
                break;

            case 3:
                MessageText.text = "Good. \n\n Remember the P.A.S.S. technique. \nFirst step: Pull the pin to unlock the handle.";
                break;

            case 4:
                MessageText.text = "Pin removed! \n\n Now, aim for the nozzle at the base of the fire, not the flames.";
                break;

            case 5:
                MessageText.text = "Target acquired! \n\n Squeeze the handle to release the agent.";
                break;

            case 6:
                MessageText.text = "Discharging. \n\n Now, sweep the nozzle side to side to cover the fuel source.";
                break;

            case 7:
                MessageText.text = "Fire extinguished! \n\n Great work following the P.A.S.S.protocol.\nThe area is secure.";
                break;

            case 8:
                MessageText.text = "Critical Danger! \n\n The fire is out of control.\n Drop the extinguisher and evacuate immediately.\n Look around to find the exit!";
                break;

            case 9:
                MessageText.text = "Don't fight it! \n\n Get to the Emergency Door. \n Move!";
                break;

            case 10:
                MessageText.text = "Evacuation was successful. You made the right choice to abandon the fire.";
                break;
        }
    }
}
