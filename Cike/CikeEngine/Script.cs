using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public abstract class Script : IComparable<Script>
    {
        public GameObject gameObject;
        public abstract void OnUpdate();

        public abstract void OnLoad();

        public abstract void OnDraw();

        public void PassFunctionsToEngine()
        {
            CikeEngine.GetOnLoad(OnLoad);
            CikeEngine.GetOnUpdate(OnUpdate);
            CikeEngine.GetOnDraw(OnDraw);
        }

        public void RemoveFunctionsFromEngine()
        {
            CikeEngine.RemoveOnLoad(OnLoad);
            CikeEngine.RemoveOnUpdate(OnUpdate);
            CikeEngine.RemoveOnDraw(OnDraw);
        }

        public int CompareTo(Script other)
        {
            throw new NotImplementedException();
        }
    }
}
