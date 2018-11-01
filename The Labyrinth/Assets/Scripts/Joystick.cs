using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
/* This script is for the joystick in the game.The inner circle is restricted within the bigger circle,it 
 takes the positions set by the player.The code for this script was taken from Youtube video*/
public class Joystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	private Image bgImage;
	private Image joystickImg;
	private Vector3 inputVector;
	
	private void Start ()
	{
		bgImage = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();	
	}

	//depending on the joystick position how fat is the player object is going to move
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImage.rectTransform, ped.position,
		                                                             ped.pressEventCamera, out pos)) 
		{
			pos.x = ( pos.x / bgImage.rectTransform.sizeDelta.x);
			pos.y = ( pos.y / bgImage.rectTransform.sizeDelta.y);
			
			inputVector = new Vector3(pos.x*2,0,pos.y*2);
		inputVector=(inputVector.magnitude>1.0f)?inputVector.normalized:inputVector;
			Debug.Log(inputVector);
			
			//Move the inner circle
			joystickImg.rectTransform.anchoredPosition = new Vector3(
				inputVector.x*(bgImage.rectTransform.sizeDelta.x/3),
				inputVector.z*(bgImage.rectTransform.sizeDelta.y/3));
		}
	}
	
	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}
	
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	// Here the x and z position(up,down left or right) of the joystick is stored if it is not 0
	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}
	
	public float Vertical()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}
}
