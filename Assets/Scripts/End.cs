using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public AudioSource win;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            win.Play();
            Invoke("EndLevel", 2f);
        }
    }

    private void EndLevel()
    {
        SceneManager.LoadScene("EndMenu");
    }
}
