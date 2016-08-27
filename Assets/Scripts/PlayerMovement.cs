using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    private int currentLane;

    private float inputTimer;

    void Start()
    {
        currentLane = 2;
    }

    void Update()
    {
        switch (currentLane)
        {
            case 1:
                this.transform.localPosition = Vector3.left*Config.laneOffset;
                break;
            case 2:
                this.transform.localPosition = Vector3.zero;
                break;
            case 3:
                this.transform.localPosition = Vector3.right*Config.laneOffset;
                break;
            default:
                this.transform.localPosition = Vector3.up;
                Debug.LogWarning("Invalide Lane: " + currentLane);
                break;
        }

        float axisValue = Input.GetAxis("Horizontal");

        if (axisValue != 0)
        {
            inputTimer += Time.deltaTime;

            if (inputTimer > 0)
            {
                if (Input.GetAxis("Horizontal") > 0.8)
                {
                    currentLane = Mathf.Clamp(++currentLane, 1, 3);
                    inputTimer = -Config.InputRepeatDelay;
                }

                if (Input.GetAxis("Horizontal") < -0.8)
                {
                    currentLane = Mathf.Clamp(--currentLane, 1, 3);
                    inputTimer = -Config.InputRepeatDelay;
                }
            }
        }
        else
        {
            inputTimer = 0;
        }

    }



}