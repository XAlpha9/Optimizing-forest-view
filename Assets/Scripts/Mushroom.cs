using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float upForce = 1f;
    public float sideForce = .1f;
    private float LifeTime;
    void Start()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce/2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        Vector3 force = new Vector3 (xForce, yForce, zForce);

        GetComponent<Rigidbody>().velocity = force;
    }

    private void OnEnable()
    {
        LifeTime = 3;
    }
    private void OnDisable()
    {
        LifeTime = 3;
    }
    private void LateUpdate()
    {
        if (LifeTime >= 0)
        {
            LifeTime -= Time.deltaTime;
        }
        else if (LifeTime <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
