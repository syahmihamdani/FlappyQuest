using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export] float jumpPower = 350f; // Kekuatan flapping dari birdnya
	//[Export] float resetTimer = 1f; 

	private AnimatedSprite2D sprite;

	private Vector2 jumpImpulse = new Vector2();	//impuls dari flapping, agar bird bisa flap dengan baik

	public override void _Ready()
	{
		jumpImpulse.Y = -jumpPower; // set axis y pada impuls dengan negatif agar bird lompat ke atas
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		sprite.Play("run");	//memastikan animasi berjalan
	}

	public override void _PhysicsProcess(double delta)
	{
		// memastikan bird berada di x yang sama
		Position = new Vector2(50, Position.Y);

		// mempertahankan velocity x, juga velocity y nya
		LinearVelocity = new Vector2(0, LinearVelocity.Y);
	}

	public override void _Input(InputEvent @event)
	{

		//jika space ditekan, maka method jump akan dipanggil
		if (@event is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key.Space)
		{
			Jump();
		}
	}

	private void Jump()
	{
		LinearVelocity = new Vector2(0, 0); // reset velocity dari bird
		ApplyImpulse(jumpImpulse);          // menambahkan impuls agar bird bisa flapping
	}
}
