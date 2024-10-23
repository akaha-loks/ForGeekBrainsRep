using UnityEngine;

public class MovementHandler : MonoBehaviour
{

	public InputHandler inputHandler;
	[SerializeField] private float _ballSpeed;

	private void Update()
	{
		MoveBall();
	}
	
	private void MoveBall()
	{
		if(inputHandler.IsThereTouchOnScreen())
		{
			Vector2 currDeltaPos = inputHandler.GetTouchDeltaPosition();
			currDeltaPos = currDeltaPos * _ballSpeed;
			Vector3 newGravityVector = new Vector3(currDeltaPos.x, Physics.gravity.y, currDeltaPos.y);
			Physics.gravity = newGravityVector;
		}
	}
}
