using Common.Interfaces;

namespace Odoo.Callbacks
{
    public class CallbackDelegates
    {
        public delegate void ProcessDataDelegate<T>(T[] models, string path, ILogger logger);
    }
}
