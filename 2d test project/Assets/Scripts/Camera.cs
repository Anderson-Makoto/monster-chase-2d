using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]
    private GameObject[] selectedPlayer;

    private const string PLAYER_TAG = "Player";
    private const int MAX_X = 57;
    private const int MIN_X = -57;
    private const string PLAYER_NAME_1 = "Player 1";
    private const string PLAYER_NAME_2 = "Player 2";
    void Start()
    {
        this.spawnPlayer();
        this.playerTransform = GameObject.FindWithTag(PLAYER_TAG).transform;
    }
    // runs after de Update method
    void LateUpdate()
    {
        this.followPlayer();
    }

    private void spawnPlayer()
    {
        string selectedCharacter = GameManager.selectedCharacter;

        if (selectedCharacter == PLAYER_NAME_1)
        {
            Instantiate(selectedPlayer[0]);
        } else
        {
            Instantiate(selectedPlayer[1]);
        }
    }

    private void followPlayer()
    {
        if (!this.playerTransform) return;
        
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
