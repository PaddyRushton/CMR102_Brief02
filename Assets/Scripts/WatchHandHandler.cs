using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchHandHandler : MonoBehaviour
{
    public Transform WatchFace;
    public Transform HourHand;
    public Transform MinuteHand;
    public Transform SecondHand;
 
    private int hours;
    private int minutes;
    private int seconds;

    // Update is called once per frame
    void Update()
    {
        SetHours();
        SetMinutes();
        SetSeconds(); 
    }


        void SetSeconds()
    {
        //string dateAndTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        //print(dateAndTime);

        string ss = System.DateTime.Now.ToString("ss");
        // print(ss);
        
        int.TryParse(ss, out seconds);
        //print(Seconds);

        float ssDegrees = (seconds*(360/60));
        //print(Degrees);

        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0, ssDegrees, 0);
        SecondHand.transform.localRotation = rot;
    }



    void SetMinutes()
    {
        string mm = System.DateTime.Now.ToString("mm");
        // print(mm);

        int.TryParse(mm, out minutes);
        //print(Seconds);

        float mmDegrees = (minutes * (360 / 60));
        //print(Degrees);

        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0, mmDegrees, 0);
        MinuteHand.transform.localRotation = rot;
    }



    void SetHours()
    {
        string HH = System.DateTime.Now.ToString("HH");
        // print(mm);

        int.TryParse(HH, out hours);
        //print(Seconds);

        float HHDegrees = (hours * (360 / 12));
        //print(Degrees);

        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0, HHDegrees, 0);
        HourHand.transform.localRotation = rot;
    }
}
