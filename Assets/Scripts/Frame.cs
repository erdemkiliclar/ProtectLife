using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        Application.targetFrameRate = 60;
    }
}
