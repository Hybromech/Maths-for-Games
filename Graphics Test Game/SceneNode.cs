using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMath;

namespace Graphics_Test_Game
{
    class SceneNode
    {
        public SceneNode()
        {
            m_children = new List<SceneNode>();
        }
        public SceneNode(AMath.Matrix3 local)
        {
            m_children = new List<SceneNode>();
            m_global_transform = local;//set initial global transform
            m_local_transform = local;//set initial global transform
        }

        public void SetParent(ref SceneNode new_parent)
        {
            m_parent = new_parent;
        }
        public void AddChild(ref SceneNode new_child)
        {
            m_children.Add(new_child);
        }
        public void RemoveChild(ref SceneNode target_child)
        {
            m_children.Remove(target_child);
        }
        public void UpdateTransforms()
        {
            if (m_parent != null)
                m_global_transform = m_parent.m_global_transform * m_local_transform;//update global transform
            else
                m_global_transform = m_local_transform;
            for (int i = 0; i < m_children.Count ; ++i)
            {
                m_children[i].UpdateTransforms();
            }
        }
        public void SetTransform(AMath.Matrix3 new_transform)
        {
            //if (m_parent != null)
            //    m_local_transform = new_transform * m_parent.m_local_transform;
            //else
                m_local_transform = new_transform;
        }
        public AMath.Matrix3 GetGlobalTransform()
        {
            return m_global_transform;//not final
        }
        //list of children
        protected List<SceneNode> m_children;
        protected SceneNode m_parent;
        //transform relative to parent
        protected AMath.Matrix3 m_local_transform;
        //transform relative the the world origin
        protected AMath.Matrix3 m_global_transform;
        
    }
       
}
