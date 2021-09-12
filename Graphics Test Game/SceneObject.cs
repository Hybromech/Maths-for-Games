using AMath;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics_Test_Game
{
    class SceneObject
    {
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();

        protected Matrix3 localTransform = new Matrix3();
        protected Matrix3 globalTransform = new Matrix3();

        public Matrix3 LocalTransform
        {
            get { return LocalTransform; }
        }
        public Matrix3 GlobalTransform
        {
            get { return GlobalTransform; }
        }

        public SceneObject Parent
        {
            get { return parent; }
        }

        public SceneObject()
        { 
        
        }

        void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;
            foreach (SceneObject child in children)
                child.UpdateTransform();
        }

        //Functions to manipulate local transform

        public void SetPosition(Vector3 pos)
        {
            localTransform.SetPosition(pos);
            UpdateTransform();
        }
        public void Translate(Vector3 vec)
        {
            localTransform.Translate(vec);
        }
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }
        public void SetScale(float width, float height)
        {
            localTransform.SetScale(width, height);
            UpdateTransform();
        }
        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height);
            UpdateTransform();
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public virtual void OnUpdate(float deltaTime)
        { 
            
        }
        public virtual void OnDraw()
        { 
        
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
