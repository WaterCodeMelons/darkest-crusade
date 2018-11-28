using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Core;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Button moveLeftController;
    public Button moveRightController;

    void Start()
    {
        GameState.Instance.DungeonState.PlayerX
            .Subscribe(x => transform.position = new Vector3(x, transform.position.y, transform.position.z));

        moveLeftController.OnPointerDownAsObservable()
            .SelectMany(_ => this.gameObject.UpdateAsObservable())
            .TakeUntil(moveLeftController.OnPointerUpAsObservable())
            .RepeatUntilDestroy(this)
            .Subscribe(_ => Move(-1));

        moveRightController.OnPointerDownAsObservable()
            .SelectMany(_ => this.gameObject.UpdateAsObservable())
            .TakeUntil(moveRightController.OnPointerUpAsObservable())
            .RepeatUntilDestroy(this)
            .Subscribe(_ => Move(1)); 
    }

    void Move(float direction)
    {
        GameState.Instance.DungeonState.PlayerX.Value = Mathf.Clamp(
            GameState.Instance.DungeonState.PlayerX.Value + (direction * movementSpeed * Time.deltaTime),
            GameState.Instance.DungeonState.DungeonScope.start,
            GameState.Instance.DungeonState.DungeonScope.end
        );
    }
}
