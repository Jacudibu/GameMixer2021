using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneVibrate : MonoBehaviour
{
    [SerializeField] float maxRotation = 30f;
    [SerializeField] float speed = 30f;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }

    //ideally this would be done with a coroutine. Update 1 second, pause one second etc.
    //elements:
    //Start the coroutine with a 3 second delay to make sure that all Elements have loaded
    //and make it looks like the phone starts to go off, once the UI has "loaded"  
    //on starting Coroutine: "BING"-sound //--> new message received
    //and starting at same time: vibrate-"animation" and "BRWWWT"-humming-sound on repeat in X second intervals
}

