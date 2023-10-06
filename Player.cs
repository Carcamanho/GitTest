using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 500.0f;
	public const float JumpVelocity = -400.0f;

	private bool japress;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	AnimationPlayer _ap = new AnimationPlayer();
	AnimatedSprite2D _as = new AnimatedSprite2D();

	public override void _Ready(){
		_ap = GetNode<AnimationPlayer>("AnimationPlayer");
		_as = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;
			if(velocity.Y < 0)
				if(_ap.AssignedAnimation != "Jump"){
					_ap.Play("Jump");
				}
			
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Console.WriteLine(direction);
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if(velocity.Y == 0){
				if (direction.X == -1)
					_as.FlipH = true;
				else
					_as.FlipH = false; 
				_ap.Play("Run");
			}	
		}
		else
		{
			// No direction Input
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			if(velocity.Y == 0){
				_ap.Play("Idle");
			}
		}
		if(velocity.Y > 0){
			if(_ap.AssignedAnimation != "Fall"){
				_ap.Play("Fall");
			}
		}
	
		Velocity = velocity;
		MoveAndSlide();
	}
}
