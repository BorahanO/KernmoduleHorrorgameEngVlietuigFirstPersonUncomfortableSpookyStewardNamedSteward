using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{

    public Camera camera;
    MeshRenderer renderer;
    Plane[] cameraFrustum;
    Collider collider;
    public bool insight = true;


    AnnaMariaKoekoek AMK;

    // Start is called before the first frame update
    void Start()
    {
        AMK = GetComponent<AnnaMariaKoekoek>();
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // als gameobject is camera zicht is dan gaat er een boolean aan of uit
        // dit werkt blijkbaar alleen met meshrenderer of kleur ofzo 
        // maar alleen een boolean heeft hij blijkbaar problemen. 

        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            insight = true;
        }
        else
        {
           insight = false;
        }
    }
}
