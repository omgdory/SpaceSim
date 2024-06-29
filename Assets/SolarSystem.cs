using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{

    // https://www.youtube.com/watch?v=kUXskc76ud8
    readonly float G = 100f; // force of gravity
    GameObject[] celestials; // celestial objects

    void Start()
    {
        // initialize celestial objects
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        // get them into orbit
        InitialVelocity();
    }

    void Update()
    {
    }

    // handle physics
    private void FixedUpdate() {
        Gravity();
    }

    // handles gravity
    void Gravity() {
        foreach(GameObject a in celestials) {
            foreach(GameObject b in celestials) {
                if(!a.Equals(b)) {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized *
                    (G * (m1*m2)/(r*r)));
                }
            }
        }
    }

    // Handles orbits
    void InitialVelocity() {
        foreach (GameObject a in celestials) {
            foreach (GameObject b in celestials) {
                if(!a.Equals(b)) {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G*m2) / r);
                }
            }
        }
    }
}
