using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LogoCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cargarEscenaIntro());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator cargarEscenaIntro()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }


}
