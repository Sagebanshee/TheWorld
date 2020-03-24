using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPerformance : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
}
