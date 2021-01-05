using FMODUnity;
using UnityEngine;

public class SoundInvoker : MonoBehaviour
{
    [SerializeField] StudioEventEmitter[] emitters;

    void Awake()
    { 
        foreach (var emitter in emitters)
        {
            emitter.Play();
        }
    }
}
