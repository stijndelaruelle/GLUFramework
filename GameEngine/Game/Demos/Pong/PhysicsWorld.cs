using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface PhysicsObject
    {
        Rectanglef GetAABB();
        void OnCollisionEnter(PhysicsObject otherObj);
    }

    public class PhysicsWorld
    {
        private List<PhysicsObject> m_PhysicsObjects = new List<PhysicsObject>();

        public void SubscribeObject(PhysicsObject obj)
        {
            m_PhysicsObjects.Add(obj);
        }

        public void UnSubscribeObject(PhysicsObject obj)
        {
            m_PhysicsObjects.Remove(obj);
        }

        public void Update()
        {
            //Collision checks
            for (int i = 0; i < m_PhysicsObjects.Count; ++i)
            {
                for (int j = 0; j < m_PhysicsObjects.Count; ++j)
                {
                    if (i != j)
                    {
                        Rectanglef AABB = m_PhysicsObjects[i].GetAABB();
                        Rectanglef otherAABB = m_PhysicsObjects[j].GetAABB();

                        if (!(AABB.X > otherAABB.X + otherAABB.Width ||
                              AABB.X + AABB.Width < otherAABB.X ||
                              AABB.Y > otherAABB.Y + otherAABB.Height ||
                              AABB.Y + AABB.Height < otherAABB.Y))
                        {
                            m_PhysicsObjects[i].OnCollisionEnter(m_PhysicsObjects[j]);
                        }
                    }
                }
            }
        }
    }
}
