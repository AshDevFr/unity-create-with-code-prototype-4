using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float powerupStrength = 15.0f;
    public int powerupTime = 7;
    public GameObject powerupIndicator;
    

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float speedScale = verticalInput * speed;

        playerRb.AddForce(focalPoint.transform.forward * speedScale);
        powerupIndicator.transform.position = transform.position - new Vector3(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup") && !hasPowerup)
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerupTime);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (hasPowerup && other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log($"Collided with #{other.gameObject.name}");
        }
    }
}