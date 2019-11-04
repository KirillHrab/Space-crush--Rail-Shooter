using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class SpaceshipController : MonoBehaviour
{
    //скорость передвежения корабля
    [Header("Speed")]
    [Tooltip("In ms^-1")][SerializeField] float Speed = 23f;
    

    //рамки перемещения корабля по (х) оси
    [Header("Range")]
    [Tooltip("In m")] [SerializeField] float xRange = 23.9f;
    [Tooltip("In m")] [SerializeField] float yRange = 10.52f;

    //Поворот корабля в разных случаях
    [Header("Control-Position")]
    [SerializeField] float positionPitchfactor = -1.25f;
    [SerializeField] float controlPitchfactor = -20f;
    [SerializeField] float positionYawfactor = 2.3f;
    [SerializeField] float controlRollfactor = -23.9f;

    
    float xThrow, yThrow;
    bool isControlEnabled = true;
   
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            shipTransform();
            shipRotation();
        }
       
    }
    
    void OnPlayerDeath()
    {
        isControlEnabled = false;
        print("Player freezed");
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

        float xOffset = xThrow * Speed * Time.deltaTime; //смещение корабля по иксу 
        float yOffset = yThrow * Speed * Time.deltaTime;//смещение корабля по игрику

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYpos = transform.localPosition.y + yOffset;

        //задерживаем корабль в рамках камеры
        float ClampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        float ClampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        //перемещаем корабль по (х) оси
        transform.localPosition = new Vector3(ClampedXpos, ClampedYpos, transform.localPosition.z);
    }
}
