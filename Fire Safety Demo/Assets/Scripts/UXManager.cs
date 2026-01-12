using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class UXManager : MonoBehaviour
{
    public UIManager uiMgr;
    public HighlightNextMove nextMove;

    [SerializeField]
    ParticleSystem fireSmall, fireMed, fireBig;

    public List<MeshRenderer> boxes;
    public Material box1, box2;
    public bool fireStarted = false;

    [SerializeField]
    GameObject pinMesh;

    bool canGrabEx = false, canRemovePin = false, canGrabNozzle = false;
    public bool canStartSpray = false, targetHit = false;
    bool extinguisherGrabbed = false, pinRemoved = false, NozzleGrabbed = false, sprayingStarted = false, movedToTeleport = false; 

 

 
    public void OnGrabFireExtinguisher()
    {
        if (canGrabEx && !extinguisherGrabbed)
        {
            uiMgr.DisplayUIMsg(11);
            extinguisherGrabbed = true;
            nextMove.ShowNextPoint(1);
        }
    }

    public void onMovedToTeleportLocation()
    {
        if(extinguisherGrabbed && !movedToTeleport)
        {
            uiMgr.DisplayUIMsg(3);
            canRemovePin = true;
            movedToTeleport = true;
            nextMove.HideArrow();
;        }
    }

    public void onRemovedPin()
    {
        if (canRemovePin && !pinRemoved)
        {
            uiMgr.DisplayUIMsg(4);
            pinRemoved = true;
            pinMesh.SetActive(false);
            canGrabNozzle = true;
        }
    }

    public void onGrabbedNozzle()
    {
        if (canGrabNozzle && !NozzleGrabbed)
        {
            NozzleGrabbed = true;
            canStartSpray = true;
            uiMgr.DisplayUIMsg(5);
        }
    }
 

    public void onSprayingActivated()
    {
        if (canStartSpray && !sprayingStarted && targetHit)
        {
            uiMgr.DisplayUIMsg(6);
            sprayingStarted = true;
        }
    }

    public void onFireExtinguished()
    {
        ReplaceBoxMaterials();
        uiMgr.DisplayUIMsg(7);
       
    }

    public void ReplaceBoxMaterials()
    {   
        foreach(MeshRenderer mr in boxes)
        {
            int choice = Random.Range(1, 3);
            if(choice == 1)
            {
                mr.material = box1;
            }
            else
            {
                mr.material = box2;
            }
        }
        
    }
    public void outOfControlAlert()
    {
        uiMgr.DisplayUIMsg(8);
        nextMove.ShowNextPoint(2);
        //Direct user to nearest exit point teleport
        StartCoroutine(outOfControlFinalWarning());
    }

    IEnumerator outOfControlFinalWarning()
    {
        yield return new WaitForSeconds(10);
        uiMgr.DisplayUIMsg(9);
    }
    public void onEvacuationSuccessful()
    {
        //  uiMgr.DisplayUIMsg(10); 
        SceneSwitcher.Instance.successfulEvacuation = true;
        nextMove.HideArrow();
        SceneSwitcher.Instance.LoadThisScene("LobbyScene");
        
    }

    public void CheckUserProgress()
    {
        if (extinguisherGrabbed && pinRemoved && targetHit)
        {
            if (fireLevel < 80)
            {
                fireMed.Stop();
                onFireExtinguished();
            }
            else
            {
                outOfControlAlert();
            }
        }
        else
        {
            outOfControlAlert();
        }
    }

    #region Fire Logic
    private float duration = 60f; // The total time for the transition in seconds
    private float startValue = 0f;
    private float endValue = 100f;

    public float fireLevel;
    public void StartFire()
    {
        fireStarted = true;
        fireSmall.Play();
        uiMgr.DisplayUIMsg(2);
        canGrabEx = true;
        nextMove.ShowNextPoint(0);
        StartCoroutine(IncFireLevel());
        StartCoroutine(CalculateTimeSinceFire());
    }

    IEnumerator CalculateTimeSinceFire()
    {
        yield return new WaitForSeconds(20f);
        fireMed.Play();
        fireSmall.Stop();

        yield return new WaitForSeconds(30f);
        CheckUserProgress();
    }
    IEnumerator IncFireLevel()
    {
        {
            float elapsedTime = 0f;
            fireLevel = startValue;
            // Loop while the elapsed time is less than the duration
            while (elapsedTime < duration)
            {
                if (!targetHit)
                {
                    // Calculate the new value using Linear Interpolation (Lerp)
                    // The third parameter (t) is a value between 0 and 1, representing the percentage complete
                    float newValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);

                    // Update the slider's value in the UI
                    fireLevel = newValue;

                    // Increase the elapsed time by the time passed since the last frame
                    elapsedTime += Time.deltaTime;
                }

                while (targetHit)
                    yield return null;

                // Wait for the next frame before continuing the loop
                yield return null;
            }

            // Ensure the slider value is exactly the end value when the coroutine finishes
            fireLevel = endValue;
        }
    }

    #endregion
}
