using FMODUnity;
using UnityEngine;
using FMOD.Studio;
using UnityStandardAssets.Characters.FirstPerson;

public class InteriorChecker : MonoBehaviour
{
    [SerializeField] FirstPersonController controller;
    [SerializeField] float interval = 0.3f;

    private float counter = 0;

    private EventInstance interior;
    private EventInstance exterior;

    private void Awake()
    {
        interior = RuntimeManager.CreateInstance("snapshot:/Interior");
        exterior = RuntimeManager.CreateInstance("snapshot:/Exterior");

        ToggleVolume(Transition.Outside);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            counter++;

            if (counter == 1)
            {
                ToggleFootsteps(Transition.Inside);
                ToggleVolume(Transition.Inside);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {


        if (other.tag == "Player")
        {
            counter--;

            if (counter == 0)
            {
                ToggleFootsteps(Transition.Outside);
                ToggleVolume(Transition.Outside);
            }
        }
    }

    private void ToggleVolume(Transition key)
    {
        switch (key)
        {
            case 0:
                exterior.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                interior.start();

                Debug.Log("Entered the lab");

                break;

            case (Transition)1:
                interior.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                exterior.start();

                Debug.Log("Left the lab");

                break;
        }
    }

    private void ToggleFootsteps(Transition key)   
    {
        switch (key)
        {
            case 0:
                controller.isOnMetal = true;
                break;

            case (Transition)1:
                controller.isOnMetal = false;
                break;
        }
    }
    enum Transition 
    {
        Inside,
        Outside
    }
}
