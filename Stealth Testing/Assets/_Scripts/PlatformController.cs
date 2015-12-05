using UnityEngine;
using System.Collections;

// PLATFORM CONTROLLER CLASS
public class PlatformController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
    public Transform endMarker;
    public bool move;    
    public float speed = 1.0F;
	public enum MoveTo {END, START}
	public MoveTo moveTo;
	public bool between;

    // PRIVATE INSTANCE VARIABLES
    private Vector3 _startMarker;
	private Transform _tr;
    private float _startTime;
    private float _journeyLength;
	
	void Start()
	{
        this._startTime = Time.time;
        this._startMarker = this.transform.position;
        this._journeyLength = Vector3.Distance(this._startMarker, endMarker.position);
		this._tr = GetComponent<Transform>();
    }
	
    void Update()
    {
        if (move)
        {
            float distCovered = (Time.time - this._startTime) * speed;
            float fracOfJourney = distCovered / this._journeyLength;

			if(moveTo.ToString() == "END")
			{
				MoveToEndMarker(fracOfJourney);
			}
			else
			{
				MoveToStartMarker(fracOfJourney);
			}

			if(between && fracOfJourney >= 1)
			{
				this._startTime = Time.time;

				if(moveTo.ToString() == "END")
				{
					moveTo = MoveTo.START;
				}
				else if(moveTo.ToString() == "START")
				{
					moveTo = MoveTo.END;
				}	

			}
			else if(fracOfJourney >= 1)
			{
				move = false;
			}
        }
        else
        {
            this._startTime = Time.time;
        }
    }

	void MoveToEndMarker(float fracOfJourney)
    {
		this._tr.position = Vector3.Lerp(this._startMarker, endMarker.position, fracOfJourney);
    }

	void MoveToStartMarker(float fracOfJourney)
	{
		this._tr.position = Vector3.Lerp(endMarker.position, this._startMarker, fracOfJourney);
    }
}
