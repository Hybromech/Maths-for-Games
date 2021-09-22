///Created by Andrew Jonas 22/09/2021
using AMath;//Include custom math library
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics_Test_Game
{
    //Base object in the scene which is part of a hierarchy
    class SceneObject
    {
        protected SceneObject parent = null;//the objects parent
        protected List<SceneObject> children = new List<SceneObject>();// a list of this objects children

        protected Matrix3 localTransform = new Matrix3();//the objects transform relative to its parent
        protected Matrix3 globalTransform = new Matrix3();//the objects global transform relative to the world
        protected float rotation;
        protected float rotation_speed;
        public String name;
        

        public Matrix3 LocalTransform
        {
            get { return localTransform; }
        }
        public Matrix3 GlobalTransform
        {
            get { return globalTransform; }
        }

        public SceneObject Parent
        {
            get { return parent; }
        }

        public SceneObject(){}
        
        public SceneObject(float m_rotation_speed)
        {
            rotation = 0;
            rotation_speed = m_rotation_speed;
        }
        //Update the objects transform
        void UpdateTransform()
        {
            if (parent != null)//if there is a parent
                globalTransform = parent.globalTransform * localTransform;//Calculate global transform using matrix multiplication
            else
                globalTransform = localTransform;
            foreach (SceneObject child in children)
                child.UpdateTransform();
        }

        //Functions to manipulate local transform

        public void SetLocalTransform(Matrix3 m)
        {
            localTransform = m;  
        }
        public void SetPosition(Vector3 pos)
        {
            localTransform.SetTranslation(pos);
            UpdateTransform();
        }
        public void Translate(Vector3 vec)
        {
            localTransform.Translate(vec);
            UpdateTransform();
        }
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        public void Rotate(float radians)
        {
            rotation += radians * rotation_speed;
            localTransform.SetRotateZ(rotation);
            UpdateTransform();
        }
        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }
        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }
                
        public virtual void OnUpdate(float deltaTime)
        { 
            
        }
        public virtual void OnDraw()
        {
            //Console.WriteLine(name + " pos is " + GlobalTransform.m3 + " " + GlobalTransform.m6);
        }

        public void Update(float deltatime)
        {
            //run OnUpdate behaviour
            OnUpdate(deltatime);

            //update children
            foreach (SceneObject child in children)
            {
                child.Update(deltatime);
            }       
        }
        public void Draw()
        {
            //run OnDraw behaviour
            OnDraw();

            //draw children
            foreach (SceneObject child in children)
            {
                child.Draw();
            }
        }


        //Methods to manipulate the hierarchy
        public int GetChildCount()
        {
            return children.Count;
        }

        public SceneObject GetChild(int index)
        {
            return children[index];
        }

        public void AddChild(SceneObject child)
        {
            //make sure it doesn't have a parent already
            Debug.Assert(child.parent == null);
            //asign this as new parent
            child.parent = this;
            //add new child to collection
            children.Add(child);
        }

        public void RemoveChild(SceneObject child)
        {
            if (children.Remove(child) == true)
            {
                child.parent = null;
            }
        }

        ~SceneObject()
        {
            if (parent != null)//if there is a parent
            {
                parent.RemoveChild(this);
            }

            foreach (SceneObject so in children)
            {
                so.parent = null;
            }
        }

    }
}
