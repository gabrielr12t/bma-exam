using System.Runtime.CompilerServices;

namespace Bma.Core.Infrastructure
{
   public class EngineContext
    {
        #region Methods

        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new BmaEngine());
        }

        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        public static IEngine Current
        {
            get
            {
                if(Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }
}