package com.example.openqlestry;
import android.content.Context;
import android.opengl.GLSurfaceView;

public class OpenGLView extends GLSurfaceView {
    private final OpenGLRenderer renderer;

    public OpenGLView(Context context){
        super(context);

        // Create an OpenGL ES 2.0 context
        setEGLContextClientVersion(2);

        renderer = new OpenGLRenderer();

        // Set the Renderer for drawing on the GLSurfaceView
        setRenderer(renderer);
    }
}
