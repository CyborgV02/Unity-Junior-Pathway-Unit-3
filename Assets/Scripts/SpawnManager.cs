using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    private PlayerController playerControllerscript;

    private float startDelay = 2;

    private float repeatRate = 2;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    void Start()
    {
        InvokeRepeating("spawnObject", startDelay, repeatRate);

        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnObject()
    {
        if (playerControllerscript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
