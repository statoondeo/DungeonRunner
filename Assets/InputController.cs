using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector2 mInitialPosition;
    private Vector2 mEndPosition;

    [SerializeField] private GameEvent OnInputSwiped;
    [SerializeField] private InputModel InputModel;

    private void Awake()
    {
        if (null == OnInputSwiped) throw new System.ArgumentNullException("OnInputSwiped is missing!");
        if (null == InputModel) throw new System.ArgumentNullException("InputModel is missing!");
    }

    private void Update()
    {
        Vector2 swipe = Vector2.zero;

        // est-ce que l'écran est touché
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                // Démarrage d'un swipe
                case TouchPhase.Began:
                    mInitialPosition = touch.position;
                    mEndPosition = touch.position;
                    break;

                // Déplacement du swipe
                case TouchPhase.Moved:
                    mEndPosition = touch.position;
                    break;

                // Fin du swipe
                case TouchPhase.Ended:
                    mEndPosition = touch.position;
                    float horizontalDrag = mEndPosition.x - mInitialPosition.x;
                    float verticalDrag = mEndPosition.y - mInitialPosition.y;

                    // Est-ce un swipe ou un tap
                    if ((Mathf.Abs(horizontalDrag) >= InputModel.MinDragDistance)
                        || (Mathf.Abs(verticalDrag) >= InputModel.MinDragDistance))

                    {
                        // Dans quel sens
                        if (Mathf.Abs(horizontalDrag) > Mathf.Abs(verticalDrag))
                        {
                            // Horizontal
                            swipe = mEndPosition.x > mInitialPosition.x ? Vector2.right : Vector2.left;
                        }
                        else
                        {
                            // Vertical
                            swipe = mEndPosition.y > mInitialPosition.y ? Vector2.up : Vector2.down;
                        }
                    }
                    break;
            }
        }
        else
		{
			// Gestion du clavier, on simule un swipe en fonction des touches
			float horizontalMove = Input.GetAxisRaw("Horizontal");
			float verticalMove = Input.GetAxisRaw("Vertical");
			if (horizontalMove != 0)
			{
				swipe = horizontalMove > 0 ? Vector2.right : Vector2.left;
			}
			else if (verticalMove != 0)
			{
				swipe = verticalMove > 0 ? Vector2.up : Vector2.down;
			}
		}

        if (swipe != Vector2.zero)
		{
            // Si il y a eu un mouvement de la poart du joueur,
            // on notifie tous les observers
            InputModel.Swipe = swipe;
            OnInputSwiped.Raise();
        }
    }
}
