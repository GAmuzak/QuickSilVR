using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    
    [SerializeField] private GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedHandModel;
    private Animator handAnimator;
    private static readonly int Trigger = Animator.StringToHash("Trigger");
    private static readonly int Grip = Animator.StringToHash("Grip");

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count <= 0) return;
        targetDevice = devices[0];
        spawnedHandModel = Instantiate(handModelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
        Debug.Log(targetDevice);
    }

    private void UpdateHandAnimation()
    {
        handAnimator.SetFloat(Trigger,
            targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) ? triggerValue : 0f);

        handAnimator.SetFloat(Grip,
            targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) ? gripValue : 0f);
    }
    void Update()
    {
        UpdateHandAnimation();
    }
}
