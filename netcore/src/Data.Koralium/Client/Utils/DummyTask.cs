/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Reflection;
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
            var finishDelegateAction = (Action<Task, bool>)Delegate.CreateDelegate(typeof(Action<Task, bool>), finishMethod);
            return finishDelegateAction;
        }

        static Action<Task, object, bool> GetAddExceptionDelegate()
        {
            var addExceptionMethod = typeof(Task).GetMethod("AddException", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(object), typeof(bool) }, null);
            var addExceptionDelegateAction = (Action<Task, object, bool>)Delegate.CreateDelegate(typeof(Action<Task, object, bool>), addExceptionMethod);
            return addExceptionDelegateAction;
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
