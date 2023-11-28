using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RingCounter : MonoBehaviour
{
    public static RingCounter instance;
    public TMP_Text ringText;
    public int currentRings = 00;

    void Awake(){
      instance = this;
    }

    void Start() {
    
    ringText.text = " x " + currentRings.ToString();

    }


    public void AddRing(int v)
    {
       currentRings += v;
       ringText.text = " x " + currentRings.ToString();

    }
}
