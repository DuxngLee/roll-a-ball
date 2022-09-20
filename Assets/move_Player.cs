using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class move_Player : MonoBehaviour
{
    Rigidbody rb;
    private int count;
    [SerializeField] float speed, MaxSpeed;
    public TextMeshProUGUI CountText;
    public GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        if (Mathf.Abs(rb.velocity.x) > MaxSpeed)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * speed * -1f, 0, 0);
        }
        if (Mathf.Abs(rb.velocity.z) > MaxSpeed)
        {
            rb.AddForce(0, 0, Input.GetAxis("Vertical") * speed * -1f);
        }
    }

    void SetCountText()
    {
        CountText.text = "Diem :" + count.ToString();
        if (count > 10)
        {
            winText.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
