using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public bool hasPower;
    public float powerupstrength = 15.0f;

    public GameObject point;
    public float speed = 0.75f;
    public GameObject powerupIndi;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        point = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardinput = Input.GetAxis("Vertical");
        playerRb.AddForce(point.transform.forward * speed * forwardinput);

        powerupIndi.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPower = true;
            Destroy(other.gameObject);
            powerupIndi.gameObject.SetActive(false);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPower = false;
        powerupIndi.gameObject.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPower)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with:" + collision.gameObject.name + " powerup set to " + hasPower);
            enemyRb.AddForce(awayFromPlayer * powerupstrength, ForceMode.Impulse);
        }
    }
}
