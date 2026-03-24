using UnityEngine;
using System.ComponentModel;

using UnityEngine.SceneManagement;

public class UISET : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        if(canvas.gameObject.activeSelf == true)
        {
            canvas.gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    // test Test
}
