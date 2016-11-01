using UnityEngine;

// A script that when attached to the camera, makes the resulting
// colors inverted. See its effect in play mode.
public class TurnRed : MonoBehaviour
{
		private Material mat;
		public Shader shader;

		// Will be called from camera after regular rendering is done.
		public void OnPostRender ()
		{
				if (!mat)
				{
						mat = new Material (shader);
				}

				GL.PushMatrix ();
				GL.LoadOrtho ();

				// activate the first shader pass (in this case we know it is the only pass)
				mat.SetPass (0);
				// draw a quad over whole screen
				GL.Begin (GL.QUADS);
				GL.Vertex3 (0, 0, 0);
				GL.Vertex3 (1, 0, 0);
				GL.Vertex3 (1, 1, 0);
				GL.Vertex3 (0, 1, 0);
				GL.End ();

				GL.PopMatrix ();
		}
}
