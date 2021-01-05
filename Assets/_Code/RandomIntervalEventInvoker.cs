using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class RandomIntervalEventInvoker : MonoBehaviour
{
    [SerializeField, EventRef] string eventRef;

    [SerializeField] float interval;
    [SerializeField] int rangeMax;

    private IEnumerator coroutine;

    private void Start()
    {
        coroutine = Randomize(interval);
        StartCoroutine(coroutine);
    }

    private IEnumerator Randomize(float t)
    {
        while (true)
        {
            yield return new WaitForSeconds(t);

            int i = Random.Range(1, rangeMax);

            if (i == 1)
            {
                RuntimeManager.PlayOneShotAttached(eventRef, gameObject);
            }
        }
    }
}
