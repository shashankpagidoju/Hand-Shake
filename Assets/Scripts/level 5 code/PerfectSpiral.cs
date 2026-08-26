using UnityEngine;

[ExecuteAlways]
public class PerfectSpiral : MonoBehaviour
{
    public LineRenderer innerWall;
    public LineRenderer outerWall;

    [Header("Spiral Settings")]
    public int totalLoops = 6;
    public float spaceBetweenLoops = 0.4f;

    [Header("Wall Settings")]
    public float gapInMiddle = 0.3f; // The empty space for the player
    public float wallThickness = 0.05f; // How thick the pink lines are
    public int smoothness = 300;

    void Update()
    {
        if (innerWall != null && outerWall != null)
        {
            CreateSpiral();
        }
    }

    void CreateSpiral()
    {
        // Set the thickness for both lines
        innerWall.startWidth = wallThickness;
        innerWall.endWidth = wallThickness;
        innerWall.positionCount = smoothness;

        outerWall.startWidth = wallThickness;
        outerWall.endWidth = wallThickness;
        outerWall.positionCount = smoothness;

        // Math to draw two perfect lines with a gap
        for (int i = 0; i < smoothness; i++)
        {
            float angle = i * Mathf.PI * 2 * totalLoops / (smoothness - 1);
            float centerDistance = spaceBetweenLoops * angle;

            // Draw the Inside Wall
            float inDist = centerDistance - (gapInMiddle / 2f);
            float inX = Mathf.Cos(angle) * inDist;
            float inY = Mathf.Sin(angle) * inDist;
            innerWall.SetPosition(i, new Vector3(inX, inY, 0));

            // Draw the Outside Wall
            float outDist = centerDistance + (gapInMiddle / 2f);
            float outX = Mathf.Cos(angle) * outDist;
            float outY = Mathf.Sin(angle) * outDist;
            outerWall.SetPosition(i, new Vector3(outX, outY, 0));
        }
    }
}