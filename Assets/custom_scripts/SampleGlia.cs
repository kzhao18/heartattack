using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HP.Omnicept.Messaging.Messages;
using HP.Omnicept.Unity;

public class SampleGlia : MonoBehaviour
{
    public TMPro.TextMeshProUGUI txt;

    private GliaBehaviour _gliaBehaviour = null;
    private GliaBehaviour gliaBehaviour
    {
        get
        {
            if (_gliaBehaviour == null)
            {
                _gliaBehaviour = FindObjectOfType<GliaBehaviour>();
            }

            return _gliaBehaviour;
        }
    }

    // Update is called once per frame
    public void HeartRateHandler(HeartRate hr)
    {
        if (hr != null)
        {
            Debug.Log(hr);
            txt.text = hr.ToString();
        }
    }

    void Update()
    {
        //Debug.Log(gliaBehaviour.GetLastHeartRate());
    }
}
