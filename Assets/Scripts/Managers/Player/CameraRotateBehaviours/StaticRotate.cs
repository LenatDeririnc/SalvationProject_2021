namespace Managers.Player.CameraRotateBehaviours
{
    public class StaticRotate : CameraRotateBehaviour
    {
        public override bool UseFixedUpdate() => true;

        public override void Rotate()
        {
            // do nothing
        }
    }
}