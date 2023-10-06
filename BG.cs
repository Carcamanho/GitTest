using Godot;
using Godot.Collections;
using System;

public partial class BG : ParallaxBackground
{
	Viewport _vp;
	Array<Godot.Node> _bgch;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		_vp = GetViewport();
		Vector2 _scs = _vp.GetViewport().GetWindow().Size;
		Console.WriteLine(_scs);
		_bgch = this.GetChildren();
		PrintNodeArray(_bgch);
	}

	//Prints Array
	void  PrintNodeArray(Array<Godot.Node> _prarray){
		foreach(Node i in _prarray){
			Console.WriteLine(_prarray);
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
