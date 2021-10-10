using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GunHandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    
    // Start is called before the first frame update
    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDeviceCharacteristics rightController =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(rightController, devices);

        foreach (var device in devices)
        {
            print(device.name + device.characteristics);
        }

        if (devices.Count > 0)
            targetDevice = devices[0];
    }

    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonPressed);
        if (buttonPressed)
            print("Test");
    }
}
