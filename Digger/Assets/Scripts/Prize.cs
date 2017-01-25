using UnityEngine;
using System.Collections;

public class Prize : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag=="Player")
        {
            GameObject.Find("RestartCanvas").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
