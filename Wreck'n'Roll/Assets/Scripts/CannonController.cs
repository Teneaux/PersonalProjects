using UnityEngine;
//Script by: Santino Williams
//Script functionalities should include:
//On start oscillate the cannon barrel -> Move Cannon along Z-Axis, clamped at 25, and -20
//Determine strength of the shot -> Determine a force variable from a set beginning and end range
//Fire the shot ->  Instantiate the Cannonball object ->  Add Force to the Cannonball object based on the previously output force variable
public class CannonController : MonoBehaviour
{
    [SerializeField]
    private Transform cannonRotation; //The local rotation of the Cannon. the fireOrigin is attached to the Cannon Game Object and will rotate with it.
    [SerializeField]
    private float maxAngle = 30; 
    [SerializeField] //Max and Min Angle clamp the rotation of the cannon to prevent free spinning.
    private float minAngle = -25;
    [SerializeField]
    private float minForce;
    [SerializeField] // Max and Min force are the highest and lowest ranges of force that will be applied to the Cannon shot during the setting power phase.
    private float maxForce;
    [SerializeField]
    private float oscillationSpeed; //The speed at which the cannon barrel rotates
    private float currentAngle; //The angle at which the cannon was locked, before transitioning into the Setting power phase
    [SerializeField]
    private float appliedForce; //The value at which the power was locked, this is the force applied to the cannonball during the Firing phase
    private float incrementForce = 5f;
    [SerializeField]
    private CannonStates activeState; // The current state of the Cannon, viewable in the editor for testing
    public Rigidbody2D cannonBall; //Reference to the Cannonball rigidbody
    [SerializeField]
    private Transform fireOrigin; //Empty Game Object from which the Cannonball instantiates
    [SerializeField]
    private float forceMultiplier; //The value that the applied force is multiplied by
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
        ball.AddForce(fireOrigin.right * (appliedForce * forceMultiplier), ForceMode2D.Impulse);
        Debug.Log("Appled " + appliedForce + "units of Force to Cannonball");
        activeState = CannonStates.Inactive;
    }
}



