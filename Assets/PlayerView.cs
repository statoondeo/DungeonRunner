using UnityEngine;

public class PlayerView : MonoBehaviour
{
	public Animator Animator;
	public CharacterController CharacterController;

	private void Awake()
	{
		if (null == Animator) throw new System.ArgumentNullException("Animator reference is missing!");
		if (null == CharacterController) throw new System.ArgumentNullException("CharacterController reference is missing!");
	}
}
