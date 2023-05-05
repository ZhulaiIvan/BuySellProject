using UnityEngine;
using UnityEngine.InputSystem;

namespace Content.Settings
{
	public class Input : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 Move;
		public Vector2 Look;
		public bool Interact;

		[Header("Movement Settings")]
		public bool AnalogMovement;

		[Header("Mouse Cursor Settings")]
		public bool CursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(CursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}
#endif
		public void MoveInput(Vector2 newMoveDirection)
		{
			Move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			Look = newLookDirection;
		}
	}
	
}