using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneCameraScript : MonoBehaviour
{
    Transform cameraPosition;
    [SerializeField] float positionlimit = 10.0f;
    [SerializeField] float cameraSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = this.transform;
        if(cameraPosition.position.x < positionlimit)
        {
            this.transform.position += transform.right * cameraSpeed;
        }else
        {
            cameraPosition.position = new Vector3(0, 0, -10);
        }
    }
}
