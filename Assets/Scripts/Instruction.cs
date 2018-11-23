using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour {

    public void NextScene()
    {
        SceneManager.LoadScene("How_To_Play");
    }

}
