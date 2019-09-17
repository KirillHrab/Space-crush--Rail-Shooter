using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class SpaceShip : MonoBehaviour
{
    //скорость передвежения корабля
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 40.29f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 22.1f;

    //рамки перемещения корабля по (х) оси
    [Tooltip("In m")] [SerializeField] float xRange = 23.9f;
    [Tooltip("In m")] [SerializeField] float yRange = 10.52f;

    //Поворот корабля в разных случаях
    [SerializeField] float positionPitchfactor = -1.25f;
    [SerializeField] float controlPitchfactor = -20f;
    [SerializeField] float positionYawfactor = -1.36f;
    [SerializeField] float controlRollfactor = -23.9f;


    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shipTransform();
        shipRotation();

    }

    private void shipRotation()
    {
        float pitchToPosition = transform.localPosition.y * positionPitchfactor;
        float pitchToControlThrow = yThrow * controlPitchfactor;
        float pitch = pitchToPosition + pitchToControlThrow;
        
        float yaw = transform.localPosition.x * positionYawfactor;
       
        float roll = xThrow * controlRollfactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void shipTransform()
    {
         xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
         yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        //задерживаем корабль в рамках камеры
        float ClampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float ClampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        //перемещаем корабль по (х) оси
        transform.localPosition = new Vector3(ClampedXpos, ClampedYpos, transform.localPosition.z);
    }
}
