using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x + 90,
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
