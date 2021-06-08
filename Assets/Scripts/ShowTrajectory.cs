using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrajectory : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public int _lineSegmentCount =20;
    private List<Vector3> _linePoints = new List<Vector3>();
    public void UpdateTrajectory(Vector3 forceVector, float mass, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector/mass)*Time.fixedDeltaTime;
        float FlightDuration = 5+2*velocity.y/9.81f;
        float stepTime=FlightDuration/_lineSegmentCount;
        float stepTimePassed;
        for(int i=0;i<_lineSegmentCount;i++)
        {
            stepTimePassed=i*stepTime;
            Vector3 MovementVector=new Vector3(velocity.x*stepTimePassed, velocity.y*stepTimePassed-0.5f*9.81f*stepTimePassed*stepTimePassed,velocity.z*stepTimePassed);
            _linePoints.Add(MovementVector+startingPoint);
        }
        _lineRenderer.positionCount=_linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());
        _linePoints.Clear();
    }
    public void HideLine()
    {
        _linePoints.Clear();
        _lineRenderer.positionCount=0;
    }

}
