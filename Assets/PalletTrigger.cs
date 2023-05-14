using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PalletTrigger : MonoBehaviour
{
    public List<GameObject> targets;
    public List<bool> isBusyList = new List<bool>();

    void Start()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            isBusyList.Add(false);
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        var isMobileController = other.gameObject.GetComponent<MobileController>();
        if (isMobileController != null)
        {
            EventsController.ManufactorCycle.Invoke(); // generate new cube...(
            if (isMobileController.SettedObject != null)
            {
                GameObject cube = isMobileController.SettedObject;
                isMobileController.SettedObject = null;
                isMobileController.StateRobot = StatesRobot.FinishToPathUnloading;

                for (int i = 0; i < targets.Count; i++)
                {
                    if (!(isBusyList[i]))
                    {
                        //cube.transform.SetParent(targets[i].transform);
                        cube.transform.position = targets[i].transform.position;
                        cube.transform.rotation = targets[i].transform.rotation;
                        isBusyList[i] = true;
                        break;
                    }
                }
            }
        }
    }
}
