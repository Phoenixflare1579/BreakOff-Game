using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;

public class ColorSwap : MonoBehaviour
{
    public Sprite[] Color;
    Sprite SelectedColor;
    bool B = true;
    Scene current;
    // Update is called once per frame
    private void Start()
    {
        SelectedColor = Color[0];
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (B)
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dropdown"))
            {
                g.GetComponent<Image>().sprite = SelectedColor;
            }
            foreach (Button b in GameObject.FindObjectsOfType<Button>())
            {
                b.gameObject.GetComponent<Image>().sprite = SelectedColor;
            }
            B = false;
        }
        if (current != SceneManager.GetActiveScene()) 
        { 
            B = true;
            current = SceneManager.GetActiveScene();
            if(GameObject.FindGameObjectsWithTag("Color").Length > 1)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Color")[0]);
            }
        }
    }

    public void ColorChange(int c)
    {
        SelectedColor = Color[c];
        B = true;
    }
    
}
