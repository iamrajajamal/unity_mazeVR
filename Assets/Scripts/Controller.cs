using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField]
    private GameObject ground;
    private bool isWalking = false;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {

        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isWalking)
        {
            transform.position = transform.position + Camera.main.transform.forward * 0.5f * Time.deltaTime;
        }

        if (transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.name.Contains("Ground"))
            {
                isWalking = false;
            }
            else
                isWalking = true;
        }
	}
}
