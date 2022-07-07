using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform playerTransform;

    private const string PLAYER_TAG = "Player";
    private const int MAX_X = 57;
    private const int MIN_X = -57;
    void Start()
    {
        this.playerTransform = GameObject.FindWithTag(PLAYER_TAG).transform;
    }
    // runs after de Update method
    void LateUpdate()
    {
        this.followPlayer();
    }

    private void followPlayer()
    {
        if (MIN_X >= this.playerTransform.position.x || MAX_X <= this.playerTransform.position.x) 
        {
            return;
        }
        this.transform.position = new Vector3(
            this.playerTransform.position.x, 
            this.playerTransform.position.y, 
            this.transform.position.z
        );
        
    }
}
