#version 330 core

uniform mat4 model;
uniform mat4 projection;

layout(location = 0) in vec3 aPos;

void main()
{
    gl_Position = projection * model * vec4(aPos, 1.0f);
}