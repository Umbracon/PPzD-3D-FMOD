using FMODUnity;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField, EventRef] string openingRef;
    [SerializeField, EventRef] string closingRef;
    [SerializeField] UnityEvent onDoorOpen = new UnityEvent();
    [SerializeField] UnityEvent onDoorClose = new UnityEvent();


    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            animator.SetBool("character_nearby", true);
            onDoorOpen.Invoke();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            animator.SetBool("character_nearby", false);
            onDoorClose.Invoke();
        }
    }

    public void PlayDoorSound() 
    {
        if (animator.GetBool("character_nearby")) {
            RuntimeManager.PlayOneShot(openingRef, transform.position);
        } else
        {
            RuntimeManager.PlayOneShot(closingRef, transform.position);
        }
    }
}
