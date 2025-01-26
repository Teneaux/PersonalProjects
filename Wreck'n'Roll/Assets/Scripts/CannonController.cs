using UnityEngine;
//Script by: Santino Williams
//Script functionalities should include:
//On start oscillate the cannon barrel -> Move Cannon along Z-Axis, clamped at 25, and -20
//Determine strength of the shot -> Determine a force variable from a set beginning and end range
//Fire the shot ->  Instantiate the Cannonball object ->  Add Force to the Cannonball object based on the previously output force variable
public class CannonController : MonoBehaviour
{
    public Transform cannonRotation;
    public float maxAngle = 30;
    public float minAngle = -25;
    public float oscillationSpeed;
    public float defaultAngle;
    public CannonStates activeState = CannonStates.Inactive;

    GameManager manager;
    public enum CannonStates
    {
        Inactive,
        SettingAngle,
        SettingPower,
        Firing
    }


    void Start()
    {
        InactiveCannon();
    }

    void Update()
    {
        switch (activeState)
        {
            case CannonStates.Inactive:
                InactiveCannon();
                break;
            case CannonStates.SettingAngle:
                OscillateCannon();
                break;
            case CannonStates.SettingPower:
                CannonForce();
                break;
            case CannonStates.Firing:
                FiringCannon();
                break;
        }
    }

    void InactiveCannon()
    {
        //Code for the inactive period goes here. Wait for timer to expire, and then game to start, move to next state.
        activeState = CannonStates.SettingAngle;
    }
    void OscillateCannon()
    {
        float rotationRange = (maxAngle - minAngle) /2f;
        float midpoint = minAngle + rotationRange;
        defaultAngle = midpoint + Mathf.Sin(Time.time * oscillationSpeed) * rotationRange;
        cannonRotation.localRotation = Quaternion.Euler(0,0,defaultAngle);
    }
    void CannonForce()
    {

    }
    void FiringCannon()
    {

    }
}



