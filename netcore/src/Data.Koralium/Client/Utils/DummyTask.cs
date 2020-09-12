using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Koralium.Utils
{
    public class DummyTask : Task
    {
        static Action dummy_method = () =>
        {
        };

        static Action<Task, bool> finishDelegate = GetFinishDelegate();
        static Action<Task, object, bool> addExceptionDelegate = GetAddExceptionDelegate();

        static Action<Task, bool> GetFinishDelegate()
        {
            var finishMethod = typeof(Task).GetMethod("Finish", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var finishDelegate = (Action<Task, bool>)Delegate.CreateDelegate(typeof(Action<Task, bool>), finishMethod);
            return finishDelegate;
        }

        static Action<Task, object, bool> GetAddExceptionDelegate()
        {
            var addExceptionMethod = typeof(Task).GetMethod("AddException", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(object), typeof(bool) }, null);
            var addExceptionDelegate = (Action<Task, object, bool>)Delegate.CreateDelegate(typeof(Action<Task, object, bool>), addExceptionMethod);
            return addExceptionDelegate;
        }

        private bool finished = false;

        public DummyTask() : base(dummy_method)
        {
        }

        public void Finish()
        {
            if (!finished)
                finishDelegate(this, false);
            finished = true;
        }

        public void Fail(Exception e)
        {
            if (finished)
                return;
            addExceptionDelegate(this, e, false);
            Finish();
            finished = true;
        }
    }
}
