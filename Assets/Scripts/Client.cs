using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public TMP_Text Mytext;
    public TMP_Text vehicleName;
    public Toggle EngineToggle;
    public Toggle CargoToggle; //love
    public TMP_InputField wheelInput; //item
    public AudioClip clip;
    public IVehicle v;
    public TMP_InputField luckynumInput;


    public int item;
    public bool fame;
    public bool love;
    public int luckynum;

    public void VehicleButton()
    {
        int.TryParse(wheelInput.text, out item);
        int.TryParse(luckynumInput.text, out luckynum);


        item = Mathf.Max(item, 1);
        luckynum = Mathf.Max(luckynum, 1);

        fame = EngineToggle.isOn;
        love = CargoToggle.isOn;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = item;
        requirements.HasEngine = fame;
        requirements.luckyNum = luckynum;


        v = GetVehicle(requirements);
        Debug.Log(v);

        //vehicleName.text = v.GetType().Name;
    }


    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
    public void SubmitButton()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
        v.Speak(Mytext);
    }
}