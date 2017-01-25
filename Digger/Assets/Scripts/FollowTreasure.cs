using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FollowTreasure : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Treasure = GameObject.Find("Prize").transform.position;
        Vector3 Player = GameObject.Find("Player").transform.position;

        float angle = Mathf.Atan2(Treasure.y - Player.y, Treasure.x - Player.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
