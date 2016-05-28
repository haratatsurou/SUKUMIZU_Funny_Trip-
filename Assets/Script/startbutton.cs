using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startbutton : MonoBehaviour {
    void Start() {
        Time.timeScale = 0;
    }
    public void startgame() {
        Time.timeScale = 1;
        GameObject.Find("UI").GetComponent<Canvas>( ).enabled = false;
    }
}
