#pragma strict

private var HitPoint: RaycastHit;
private var MoveTo = 1;
private var One = 1;
public var MoveToSpeed = 0.01;
public var MaxSpeed = 7;

function Start () {
        MoveTo = MoveToSpeed;
}

function FixedUpdate () {
        if(Mathf.Abs(rigidbody.velocity.x) < MaxSpeed)
                rigidbody.AddForce (MoveTo, 0, 0);
        var PosTMP = Vector3(this.transform.position.x + One, this.transform.position.y, this.transform.position.z);
        Debug.DrawLine(this.transform.position, PosTMP);
        if (!Physics.Raycast(PosTMP, Vector3.down, HitPoint, 1)) {
                if(MoveTo > 0){
                        MoveTo = -MoveToSpeed;
                        One = -1;
                }
                else{
                        MoveTo = MoveToSpeed;
                        One = 1;
                }
        }
}
