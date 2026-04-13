using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;

    public GameObject point;
    public float speed = 0.75f;
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
    }
}
