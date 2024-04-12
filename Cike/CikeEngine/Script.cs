using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.CikeEngine
{
    public abstract class Script : IComparable<Script>
    {
        public abstract void OnUpdate();

        public abstract void OnLoad();

        public abstract void OnDraw();

        public virtual void PassFunctionsToEngine()
        {
            CikeEngine.GetOnLoad(OnLoad);
            CikeEngine.GetOnUpdate(OnUpdate);
            CikeEngine.GetOnDraw(OnDraw);
        }

        public int CompareTo(Script other)
        {
            throw new NotImplementedException();
        }
    }
}
