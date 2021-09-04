using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics_Test_Game
{
    class Scene
    {
        public void UpdateTransforms()
        {
            m_scene_root.UpdateTransforms();  
        }
        private SceneNode m_scene_root;
    }
}
