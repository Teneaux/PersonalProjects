using UnityEngine;
//Script by: Santino Williams
//Script functionalities should include:
//On start oscillate the cannon barrel -> Move Cannon along Z-Axis, clamped at 25, and -20
//Determine strength of the shot -> Determine a force variable from a set beginning and end range
//Fire the shot ->  Instantiate the Cannonball object ->  Add Force to the Cannonball object based on the previously output force variable
public class CannonController : MonoBehaviour
{
    [SerializeField]
    private Transform cannonRotation;
    [SerializeField]
    private float maxAngle = 30;
    [SerializeField]
    private float minAngle = -25;
    [SerializeField]
    private float minForce;
    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float oscillationSpeed;
    [SerializeField]
    private float currentAngle;
    [SerializeField]
    private float appliedForce;
    private float incrementForce = 5f;
    [SerializeField]
    private CannonStates activeState = CannonStates.Inactive;
    public Rigidbody2D cannonBall;
    [SerializeField]
    private Transform fireOrigin;
    public Rigidbody2D cannonBarrel;
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
        cannonBarrel = GetComponent<Rigidbody2D>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeState = CannonStates.SettingAngle;
        }
    }
    void OscillateCannon()
    {
        float rotationRange = (maxAngle - minAngle) / 2f;
        float midpoint = minAngle + rotationRange;
        currentAngle = midpoint + Mathf.Sin(Time.time * oscillationSpeed) * rotationRange;
        cannonRotation.localRotation = Quaternion.Euler(0, 0, currentAngle);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeState = CannonStates.SettingPower;
        }
    }
    void CannonForce()
    {
        //Start at the minimum force value
        //Increment the force value until it reaches maximum force
        //Accept input to stop 

        if (activeState == CannonStates.SettingPower)
        {
            appliedForce += incrementForce * Time.deltaTime;
            if (appliedForce > maxForce)
            {
                appliedForce = minForce;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cannonBarrel.freezeRotation = true;
            activeState = CannonStates.Firing;
        }
    }
    void FiringCannon()
    {
        Rigidbody2D ball = Instantiate(cannonBall, fireOrigin);
        ball.AddForce(fireOrigin.right * (appliedForce * 2), ForceMode2D.Impulse);
        Debug.Log("Appled " + appliedForce + "units of Force to Cannonball");
        activeState = CannonStates.Inactive;
    }
}



