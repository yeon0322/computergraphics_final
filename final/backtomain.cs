using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backtomain : MonoBehaviour
{
    [SerializeField] Button btnBack;
    // Start is called before the first frame update
    void Start()
    {
        btnBack.onClick.AddListener(()=>{
            SceneManager.LoadScene("title");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
