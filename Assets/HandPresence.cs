using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice headset;
    private InputDevice leftHand;
    private InputDevice rightHand;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        foreach (InputDevice device in devices)
        {
            Debug.Log(device.name + " " + device.characteristics);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
