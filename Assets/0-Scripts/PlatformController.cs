using UnityEngine;

// PLATFORM CONTROLLER CLASS
public class PlatformController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public Transform endMarker;
    public bool move;
    public float speed = 1.0F;
    public enum MoveTo { END, START }
    public MoveTo moveTo;
    public bool between;

    // PRIVATE INSTANCE VARIABLES
    private Vector3 _startMarker;
    private Transform _tr;

    private float _timer;
    //private float _startTime;
    private float _journeyLength;

    private float _distCovered;
    private float _fracOfJourney;

    void Start() {
        this._timer = 0;

        this._startMarker = this.transform.position;
        this._journeyLength = Vector3.Distance(this._startMarker, endMarker.position);
        this._tr = GetComponent<Transform>();
    }

    void Update() {
        if (move) {
            this._timer += Time.deltaTime;
            this._distCovered = (this._timer) * speed;
            this._fracOfJourney = this._distCovered / this._journeyLength;

            if (moveTo == MoveTo.END) {
                MoveToEndMarker(this._fracOfJourney);
            } else {
                MoveToStartMarker(this._fracOfJourney);
            }

            if (between && this._fracOfJourney >= 1) {
                this._timer = 0;

                if (moveTo == MoveTo.END) {
                    moveTo = MoveTo.START;
                } else if (moveTo == MoveTo.START) {
                    moveTo = MoveTo.END;
                }

            } else if (this._fracOfJourney >= 1) {
                move = false;
            }
        }

        /*else
        {
            this._startTime = Time.time;
        }*/
    }

    void MoveToEndMarker(float fracOfJourney) {
        this._tr.position = Vector3.Lerp(this._startMarker, endMarker.position, fracOfJourney);
    }

    void MoveToStartMarker(float fracOfJourney) {
        this._tr.position = Vector3.Lerp(endMarker.position, this._startMarker, fracOfJourney);
    }

    void OnCollisionEnter() {
        Debug.Log("I'm Staying!!!!");
    }

    void Startmoving() {
        move = true;

        if (this._fracOfJourney >= 1) {
            this._timer = 0;

            if (moveTo == MoveTo.END) {
                moveTo = MoveTo.START;
            } else if (moveTo == MoveTo.START) {
                moveTo = MoveTo.END;
            }
        }

    }

    void Stopmoving() {
        move = false;
    }

    void StartMoveToEnd() {
        moveTo = MoveTo.END;
        this._timer = 0;
        move = true;
    }

    void StartMoveToStart() {
        if (Vector3.Distance(this.transform.position, this._startMarker) > 0) {
            moveTo = MoveTo.START;
            this._timer = 0;
            move = true;
        }
    }

    /*void Rest()
	{
		if(moveTo == MoveTo.END)
		{
			move = true;
			moveTo = MoveTo.START;
		}
		else if(moveTo== MoveTo.START && this._fracOfJourney < 1)
		{
			move = true;
			Debug.Log("1" + this._timer);
			this._timer = (1 - this._fracOfJourney) * this._journeyLength * speed;
			Debug.Log("2" + this._timer);
		}	
	}

	/*
	 * Swaps where the platorm is going 
	void Swap()
	{
		//fix jumping platform
		move = true;

		if(this._fracOfJourney >= 1)
		{
			if(moveTo == MoveTo.END)
			{
				moveTo = MoveTo.START;
			}
			else if(moveTo== MoveTo.START)
			{
				moveTo = MoveTo.END;
			}		
		}
	}*/
}
