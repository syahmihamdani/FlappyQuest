using Godot;
using System;

public partial class Ground : Area2D
{

	Signal hit;
	public void _on_body_entered(Node body){
		EmitSignal(nameof(hit));
	}
	
}
