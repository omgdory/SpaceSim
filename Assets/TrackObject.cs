using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    [SerializeField] private Transform toTrack;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(toTrack);
    }
}
