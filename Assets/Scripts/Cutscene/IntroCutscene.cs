using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{
    public void OnEnable()
    {

        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);

    }
}
