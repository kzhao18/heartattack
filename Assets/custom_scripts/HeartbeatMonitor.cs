using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HP.Omnicept.Messaging.Messages;
using HP.Omnicept.Unity;

public class HeartbeatMonitor : MonoBehaviour
{
    private float calibratedSum = 0;
    public float calibratedHeartRate = 0;
    public bool calibrated = false;
    private int count = 0;
    public float heartRateDifference = 0;

    // Start is called before the first frame update
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
            if (hr.Rate != 0)
            {
                if (count < 6)
                {
                    count += 1;
                    calibratedSum += hr.Rate;
                    calibratedHeartRate = calibratedSum / count;
                }
                else
                {
                    calibrated = true;
                    heartRateDifference = hr.Rate - calibratedHeartRate;
                    Debug.Log(hr.Rate);
                    Debug.Log(calibratedHeartRate);
                    Debug.Log(heartRateDifference);
                }
            }
            Debug.Log("OOGA BOOGA");
        }
    }
}
