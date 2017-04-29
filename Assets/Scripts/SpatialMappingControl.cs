using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA;

public class SpatialMappingControl : MonoBehaviour
{
    public static SpatialMappingControl Instance { private set; get; }

    // The layer to use for spatial mapping collisions.
    private int physicsLayer = 31;

    [HideInInspector]
    public static int PhysicsRaycastMask;

    private void Awake()
    {
        Instance = this;
    }

    public void ShortenUpdateTime()
    {
        spatialMappingCollider.secondsBetweenUpdates = spatialMappingRenderer.secondsBetweenUpdates = 0.5f;
    }

    public void SetDefaultUpdateTime()
    {
        spatialMappingCollider.secondsBetweenUpdates = spatialMappingRenderer.secondsBetweenUpdates = 2.5f;
    }

    private SpatialMappingRenderer spatialMappingRenderer;

    private SpatialMappingCollider spatialMappingCollider;

    private void Start()
    {
        spatialMappingCollider = this.gameObject.GetComponent<SpatialMappingCollider>();
        spatialMappingRenderer = this.gameObject.GetComponent<SpatialMappingRenderer>();
        spatialMappingRenderer.surfaceParent = this.gameObject;
        spatialMappingCollider.surfaceParent = this.gameObject;
        spatialMappingCollider.layer = physicsLayer;
        PhysicsRaycastMask = 1 << physicsLayer;
        DrawVisualMeshes = drawVisualMeshes;
        MappingEnabled = mappingEnabled;
    }

    [Tooltip("If true, the Spatial Mapping data will be rendered.")]
    public bool drawVisualMeshes = false;

    public bool DrawVisualMeshes
    {
        get
        {
            return drawVisualMeshes;
        }
        set
        {
            drawVisualMeshes = value;

            if (drawVisualMeshes)
            {
                spatialMappingRenderer.renderState = SpatialMappingRenderer.RenderState.Visualization;
            }
            else
            {
                //TODO:CHANGE THIS TO OCCLUSION
                spatialMappingRenderer.renderState = SpatialMappingRenderer.RenderState.Occlusion;
            }
        }
    }

    private bool mappingEnabled = true;

    public bool MappingEnabled
    {
        get
        {
            return mappingEnabled;
        }
        set
        {
            mappingEnabled = value;
            spatialMappingCollider.freezeUpdates = !mappingEnabled;
            spatialMappingRenderer.freezeUpdates = !mappingEnabled;
            gameObject.SetActive(mappingEnabled);
        }
    }
}
