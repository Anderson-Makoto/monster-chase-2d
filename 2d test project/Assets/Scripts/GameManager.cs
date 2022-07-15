using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static string selectedCharacter;

    private void Awake(){
        DontDestroyOnLoad(this);
    }
}
