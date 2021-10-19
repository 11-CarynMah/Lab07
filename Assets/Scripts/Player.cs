using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    Rigidbody PlayerRB;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        PlayerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -4.5)
        {
            SceneManager.LoadScene("GameOver");
        }

        else if (transform.position.y > 3.5)
        {
            transform.position = new Vector3(transform.position.x, 3.5f, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

            thisAnimation.Play();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}
